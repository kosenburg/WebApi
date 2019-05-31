namespace Library.API.Helpers
{
    public class AuthorsResourceParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        public string Genre { get; set; }
        public string SearchQuery { get; set; }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
