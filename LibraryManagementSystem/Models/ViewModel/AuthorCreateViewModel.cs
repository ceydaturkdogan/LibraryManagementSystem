using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class AuthorCreateViewModel
    {
        [Required(ErrorMessage =("Yazarın Adını Giriniz"))]
        [MinLength(2,ErrorMessage =("En az iki karakter girilmelidir"))]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Yazarın Soyadını Giriniz")]
        [MinLength(2, ErrorMessage = "En az iki karakter girilmelidir")]
        public string LastName { get; set; }

        public  DateTime? DateOfBirth { get; set; }

        public bool IsDeleted { get; set; }

        public int Id { get; set; }
    }
}
