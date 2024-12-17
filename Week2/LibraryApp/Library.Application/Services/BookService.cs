using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.DTOs.Book;
using Library.Application.Result;
using Library.Domain.Entities;
using Library.Domain.Pagination;
using Microsoft.VisualBasic;

namespace Library.Application.Services;

internal class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

    public BookService(IMapper mapper, IBookRepository bookRepository, IUnitOfWork unitOfWork, ICacheService cacheService)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
    }

    public async Task<Result<CreateBookResponseDto>> CreateBookAsync(CreateBookRequestDto request, CancellationToken cancellationToken)
    {
        Book bookDomain = _mapper.Map<Book>(request);

        bool isExists = await _bookRepository.IsExistsAsync(x => x.Title.Equals(request.Title), cancellationToken);

        if (isExists)
            return Result<CreateBookResponseDto>.Conflict("Book already exists");

        _bookRepository.CreateBook(bookDomain);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cacheService.RemoveByPatternAsync(Constants.BOOKS_PAGED, cancellationToken);

        return Result<CreateBookResponseDto>.Success(new CreateBookResponseDto(bookDomain.Id));
    }

    public async Task<Result<GetBookByIdResponseDto>> GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Book bookDomain = await _bookRepository.GetBookByIdAsync(id, cancellationToken);

        if (bookDomain == null)
            return Result<GetBookByIdResponseDto>.NotFound($"Book with {id} id not found");

        GetBookByIdResponseDto bookResponse = _mapper.Map<GetBookByIdResponseDto>(bookDomain);
        return Result<GetBookByIdResponseDto>.Success(bookResponse);
    }

    public async Task<Result<GetPagedBooksResponseDto>> GetPagedBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        string cacheKey = $"{Constants.BOOKS_PAGED}-{pageNumber}-{pageSize}";
        PagedResult<Book> pagedBooks = await _cacheService.GetAsync<PagedResult<Book>>(cacheKey, cancellationToken);

        if (pagedBooks == null)
        {
            pagedBooks = await _bookRepository.GetPagedBooksAsync(pageNumber, pageSize, cancellationToken);
            await _cacheService.SetAsync(cacheKey, pagedBooks, cancellationToken: cancellationToken);
        }

        PagedResult<GetBookResponse> pagedResult = _mapper.Map<PagedResult<GetBookResponse>>(pagedBooks);
        return Result<GetPagedBooksResponseDto>.Success(new GetPagedBooksResponseDto(pagedResult));
    }
}
