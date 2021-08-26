namespace StackOverflow.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, long totalItems)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
