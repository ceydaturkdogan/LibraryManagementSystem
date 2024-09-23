using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookCreateViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Kitap Adını Giriniz")]
        [MinLength(2, ErrorMessage ="En az iki karakter olmalıdır")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Kitap Türünü Giriniz")]
        [MinLength(2, ErrorMessage = "En az iki karakter olmalıdır")]
        public string Genre { get; set; }

        public DateTime? PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
