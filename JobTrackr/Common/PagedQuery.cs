namespace JobTrackr.Common
{
    // Template when the front end search the page. filter the info backend need.
    public class PagedQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public bool SortDesc { get; set; } = true;
    }
}