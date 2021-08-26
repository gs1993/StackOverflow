namespace StackOverflow.Application.Filters
{
    public record RequestParameter
    {
        public int PageIndex { get; init; }
        public int PageSize { get; init; }

        public RequestParameter()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public RequestParameter(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex < 0 ? 0 : pageIndex;
            PageSize = pageSize < 1 ? 1 : pageSize;
        }
    }
}
