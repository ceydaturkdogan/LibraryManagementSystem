namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookListViewModel
    {
        public string Title { get; set; }

        public int Id  { get; set; }

        public string Genre { get; set; }

        public DateTime? PublishDate { get; set; }
        public bool IsDeleted { get; set; }

        public  string AuthorId { get; set; }

    }
}
