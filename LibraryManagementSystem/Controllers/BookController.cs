using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {

        static List<Book> _books = new List<Book>
        {
            new Book {Id=1, AuthorId="1", Genre="Novel", ISBN="123456", Title="İçimizdeki Şeytan", CopiesAvailable=5000},
            new Book {Id=2, AuthorId="1", Genre="Novel", ISBN="456789", Title="Kürk Mantolu Madonna", CopiesAvailable=5000},
            new Book {Id=3, AuthorId="1", Genre="Novel", ISBN="486925", Title="Kuyucaklı Yusuf", CopiesAvailable=5000},
            new Book {Id=4, AuthorId="2", Genre="Novel", ISBN="533698", Title="Çalıkuşu", CopiesAvailable=5000},
            new Book {Id=5, AuthorId="3", Genre="Novel", ISBN="475896", Title="İnsan Neyle Yaşar", CopiesAvailable=5000},
            new Book {Id=6, AuthorId="4", Genre="Novel", ISBN="475896", Title="Olağanüstü Bir Gece", CopiesAvailable=5000},
        };
        public IActionResult List()
        {
            var bookViewModel = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                Title = x.Title,
            }).ToList();

            return View(bookViewModel);
        }

        public IActionResult Detail()
        {
            var detailViewModel = _books.Where(x => x.IsDeleted == false).Select(x => new BookDetailViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                ISBN = x.ISBN,
                //PublishDate=(DateTime)x.PublishDate,

            }).ToList();


        return View(detailViewModel); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                    return View(formData); 
                }

            int maxId=_books.Max(x => x.Id);
            var newBook = new Book()
            {
                Id = maxId + 1,
                Title = formData.Title,
                Genre = formData.Genre,
                //PublishDate= (DateTime)formData.PublishDate,

            };

            _books.Add(newBook);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book=_books.Find(x => x.Id == id);

            var editViewModel = new BookEditViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                //PublishDate = (DateTime)book.PublishDate,
                ISBN = book.ISBN,
            };
            return View(editViewModel);
        }
        [HttpPost]

        public IActionResult Edit(BookEditViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var book =_books.Find(x=>x.Id == formData.Id);

            book.Title= formData.Title;
            book.Genre= formData.Genre;
            book.ISBN= formData.ISBN;
            book.PublishDate= formData.PublishDate;

             

            return RedirectToAction("List");
        }


        public IActionResult Delete(int id) {

            var books =_books.Find(x=> x.Id == id);



            books.IsDeleted = true;


            return RedirectToAction("List"); 
        }

    }
}
