namespace OnTime.ViewModels
{
    //with this class i store information about pagination.
    public class PaginationInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }    
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

    }
}
