namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookDetailViewModel
    {
        public  int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Genre { get; set; }

    }
}
