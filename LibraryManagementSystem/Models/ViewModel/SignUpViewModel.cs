using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class SignUpViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))] //Password ile karşılaştırması istenildi
        public string PasswordConfirm { get; set; }
    }
}
