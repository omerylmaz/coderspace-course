using AutoMapper;
using Azure;
using Library.Application.Abstractions.Services;
using Library.Application.DTOs.Book;
using Library.Application.Result;
using Library.Domain.Pagination;
using Library.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static StackExchange.Redis.Role;

namespace Library.Web.Controllers
{
    public class BooksController(IBookService bookService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            Result<GetPagedBooksResponseDto> response = await bookService.GetPagedBooksAsync(pageNumber, pageSize, CancellationToken.None);
            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = "Could not fetch the books.";
                return View("Error");
            }

            return View(response.Value);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await bookService.CreateBookAsync(request, CancellationToken.None);
            if (!result.IsSuccess)
            {
                ViewBag.ErrorMessage = result.ProblemDetails.Detail;
                return View("Error");
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Result<GetBookByIdResponseDto> response = await bookService.GetBookByIdAsync(id, CancellationToken.None);

            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.ProblemDetails.Detail;
                return View("Error");
            }

            GetBookDetailVM bookDetails = mapper.Map<GetBookDetailVM>(response.Value);

            return View(bookDetails);
        }

    }
}
