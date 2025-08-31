using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookService.Instance.GetBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, return the form again with errors
                return View(model);
            }

            BookService.Instance.AddBook(model);
            return RedirectToAction("Index");
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = BookService.Instance.GetBookById(id);
            if (editBookViewModel == null) return NotFound();

            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var editBookViewModel = BookService.Instance.GetBookById(id);
            if (editBookViewModel == null) return NotFound();

            return View(editBookViewModel); // regular view for editing/managing copies
        }
        // GET: Open modal to add a new copy
        public IActionResult AddCopyModal(Guid bookId)
        {
            var book = BookService.Instance.GetBookById(bookId);
            if (book == null) return NotFound();

            var model = new AddBookCopyViewModel
            {
                BookId = bookId
            };

            return PartialView("_AddBookCopyPartial", model);
        }

        [HttpPost]
        public IActionResult AddCopy(AddBookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService.Instance.AddBookCopy(vm.BookId, vm); // service handles copy creation
            return Ok(); // JS will close modal & refresh
        }




        public IActionResult DeleteModal(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null) return NotFound();

            return PartialView("_DeleteBookPartial", book); // ✅ match file name
        }

        [HttpGet]
        public IActionResult DeleteConfirm(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null) return NotFound();

            // Return the same modal partial view
            return PartialView("_DeleteBookPartial", book);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            BookService.Instance.DeleteBook(id);
            return RedirectToAction("Index"); // ✅ redirect to list after delete
        }


        public IActionResult Details(Guid id)
        {
            var book = BookService.Instance.GetBooks().FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult AddBookCopy(Guid bookId, AddBookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                BookService.Instance.AddBookCopy(bookId, vm);
                return RedirectToAction("Details", new { id = bookId });
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Book not found");
            }
        }
    }
}
