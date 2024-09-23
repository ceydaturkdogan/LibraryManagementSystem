using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        static List<Author> _authors = new List<Author>
        {
            new Author{ Id=1,FirstName="Sabahattin",  LastName="Ali", DateOfBirth=new DateTime(1907,02,25)},
            new Author{ Id=2,FirstName="Reşat Nuri",  LastName="Güntekin", DateOfBirth=new DateTime(1889,11,25)},
            new Author{ Id=3,FirstName="Lev Nikolayeviç",  LastName="Tolstoy", DateOfBirth=new DateTime(1910,11,20)},
            new Author{ Id=4,FirstName="Stefan",  LastName="Zweig", DateOfBirth=new DateTime(1881,11,28)}
        };

        public IActionResult List() {

            var authorViewModel = _authors.Where(x => x.IsDeleted == false).Select(x => new AuthorListViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();
            return View(authorViewModel);
        }

        public IActionResult Details() {

            var detailViewModel = _authors.Where(x => x.IsDeleted == false).Select(x => new AuthorDetailViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                //DateOfBirth = x.DateOfBirth,
            }).ToList();

            return View(detailViewModel);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var maxId=_authors.Max(x => x.Id);

            var newAuthor = new Author()
            {
                Id = maxId + 1,
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                //DateOfBirth = (DateTime)formData.DateOfBirth,
            };

            _authors.Add(newAuthor);

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id) {
        
        
            var authors=_authors.Find(x => x.Id == id);

            var editViewModel = new AuthorEditViewModel()
            {
                Id = authors.Id,
                FirstName = authors.FirstName,
                LastName = authors.LastName,
            };

            return View(editViewModel);
        
        }
        [HttpPost]

        public IActionResult Edit(AuthorEditViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var author = _authors.Find(x => x.Id == formData.Id);

            author.FirstName = formData.FirstName;
            author.LastName = formData.LastName;


            return RedirectToAction("List");
        }


        public IActionResult Delete(int id) {

            var authors = _authors.Find(x => x.Id == id);

            authors.IsDeleted = true;
            return RedirectToAction("List");
        }
    }
}
