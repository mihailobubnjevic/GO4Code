namespace LibraryAPI.DTOs
{
    public class PagedQueryParams
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public PagedQueryParams(int pageIndex, int pageSize) 
        { 
            PageSize = pageSize > 10 ? 10 :
                       pageSize < 1 ? 1 :
                pageSize;

            PageIndex = pageIndex;
        }
    }
}
