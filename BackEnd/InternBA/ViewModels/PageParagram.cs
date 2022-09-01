namespace InternBA.ViewModels
{
    public class PageParagram
    {
        const int maxPageSize = 10;
        private int _pageNumber { get; set; } = 1;
        private int _pageSize { get; set; } = 5;

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value < 0? 1: value; }
        }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize || value < 0)? maxPageSize: value; }
        }
    }
}
