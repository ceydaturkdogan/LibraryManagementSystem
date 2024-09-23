using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagementSystem.Controllers
{
    //Burada Authentication ve Authorization  actionları bulunur
    public class AuthController : Controller
    {

        static List<User> _users = new List<User>()
        {
            new User {Id=1, Email="user1@gmail.com", FullName="First User", JoinDate=DateTime.Now, Password="123456", PhoneNumber="123456789"},
            new User {Id=2, Email="user2@gmail.com", FullName="Second User", JoinDate=DateTime.Now, Password="123456", PhoneNumber="123456789"},
            new User {Id=3, Email="user3@gmail.com", FullName="Third User", JoinDate=DateTime.Now, Password="123456", PhoneNumber="123456789"},
            new User {Id=4, Email="user4@gmail.com", FullName="Fourth User", JoinDate=DateTime.Now, Password="123456", PhoneNumber="123456789"},

        };

        private readonly IDataProtector _dataProtector;


        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }



        [HttpPost]
        public IActionResult SignUp(SignUpViewModel formData)
        {

            if (!ModelState.IsValid)
            {

                return View(formData);
            }


            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

            if (user is not null)
            {
                ViewBag.Error = "Kullanıcı Mevcut";
                return View(formData);

            }

            var newUser = new User()
            {
                Id = _users.Max(x => x.Id) + 1,
                Email = formData.Email,
                Password = _dataProtector.Protect(formData.Password),
            };

            _users.Add(newUser);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(SignInViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var user = _users.FirstOrDefault(x=>x.Email.ToLower()==formData.Email.ToLower());

            if(user is not null)
            {
                ViewBag.Error = "Kullanıcı Adı veya şifre hatalı";
                return View(formData);
            }

            var rawPassword=_dataProtector.Unprotect(formData.Password);

            if (rawPassword == formData.Password) //oturum açma işlemleri
            {
                // Oturum Açma işlemleri.

                var claims = new List<Claim>();

                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("id", user.Id.ToString()));

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // Claims içerisindeki verilerle bir oturum açılacağı için yukarıdaki identity nesnesi tanımlandı.

                var autProperties = new AuthenticationProperties
                {
                    AllowRefresh = true, // yenilenebilir oturum
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(72)) // oturum açıldıktan sonra 72 saat geçerli.
                };


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);



            }


        
            else
            {
                ViewBag.Error = "Kullanıcı Adı veya şifre hatalı";
                return View(formData);
            }


                return View();
        }

    }
}
