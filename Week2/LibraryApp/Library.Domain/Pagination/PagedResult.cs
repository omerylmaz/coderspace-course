namespace Library.Domain.Pagination;

public record PagedResult<T>
{
    public PagedResult(List<T> items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
    public PagedResult()
    {
       
    }
    public List<T> Items { get; init; }

    public int PageNumber { get; init; }
                         
    public int PageSize { get; init; }
                         
    public int TotalCount{ get; init; }
}
