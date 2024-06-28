using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookHeaven.Models;
using BookHeaven.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BookHeaven.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        private readonly IBranchService _branchService;

        public BooksController(IBookService bookService, IPublisherService publisherService, IAuthorService authorService, IBranchService branchService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _publisherService = publisherService ?? throw new ArgumentNullException(nameof(publisherService));
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));


        }

        public async Task<IActionResult> AllBooksAdded()
        {
            var books = await _bookService.GetBooksAsync();
            return View(books);
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();
            return View(books);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> IndexAdmin()
        {
            var books = await _bookService.GetBooksAsync();
            return View(books);
        }

        //public async Task<IActionResult> DetailsBook(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    // Fetch the book details based on the provided ID
        //    var book = await _bookService.GetBookByIdAsync(id.Value);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    // Pass the book details to the view
        //    return View(book);
        //}


        // GET: Books/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            List<Book> books;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                books = await _bookService.GetAllBooksAsync();
            }
            else
            {
                books = await _bookService.SearchBooksByTitleAsync(searchTerm);
            }

            if (books == null || books.Count == 0)
            {
                // No books found, display a message
                ViewBag.Message = "No books found.";
            }

            return View("Index", books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
         

            var publisherName = await _bookService.GetPublisherNameForBookAsync(book.BookId);
            ViewData["PublisherName"] = publisherName;

            var authorName = await _bookService.GetAuthorNameForBookAsync(book.BookId);
            ViewData["AuthorName"] = authorName;

            return View(book);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Books/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var publishers = await _publisherService.GetPublishers();
            var authors = await _authorService.GetAuthors();
            var branches = await _branchService.GetBranches();
            ViewData["PublisherId"] = new SelectList(publishers, "PublisherId", "Name");
            ViewData["AuthorId"] = new SelectList(authors, "AuthorId", "Name");
            ViewData["BranchId"] = new SelectList(branches, "BranchId", "Name");
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBookAsync(book);
                return RedirectToAction(nameof(Index));
            }

            var publishers = await _publisherService.GetPublishers();
            var authors = await _authorService.GetAuthors();
            var branches = await _branchService.GetBranches();
            ViewData["PublisherId"] = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);
            ViewData["AuthorId"] = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
            ViewData["BranchId"] = new SelectList(branches, "BranchId", "Name", book.BranchId);
            return View(book);
        }


        [Authorize(Roles = "Administrator")]
        //GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            var publishers = await _publisherService.GetPublishers();
            ViewBag.PublisherId = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);

            var authors = await _authorService.GetAuthors();

            ViewBag.AuthorId = new SelectList(authors, "AuthorId", "Name", book.AuthorId);

            var branches = await _branchService.GetBranches();
            
            ViewBag.BranchId = new SelectList(branches, "BranchId", "Name", book.BranchId);

            return View(book);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book, int[] authorIds)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var exists = await _bookService.BookExistsAsync(book.BookId);
                    if (!exists)
                    {
                        return NotFound();
                    }

                    //var selectedAuthors = await _authorService.GetAuthorsByIdsAsync(authorIds);
                    //book.BookAuthors = selectedAuthors.Select(author => new BookAuthor { BookId = book.BookId, AuthorId = author.AuthorId }).ToList();
                    await _bookService.UpdateBookAsync(book);
                    //await _bookAuthorService.UpdateBookAuthorsAsync(book.BookId, authorIds);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            var publishers = await _publisherService.GetPublishers();
            ViewBag.PublisherId = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);
            var authors = await _authorService.GetAuthors();
            ViewBag.AuthorIds = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }
        [Authorize(Roles = "Administrator")]
        //GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exists = await _bookService.BookExistsAsync(id);
            if (exists)
            {
                var book = await _bookService.GetBookByIdAsync(id);
                await _bookService.DeleteBookAsync(book);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}