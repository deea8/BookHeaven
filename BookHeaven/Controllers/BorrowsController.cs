using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookHeaven.Models;
using BookHeaven.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BookHeaven.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBorrowService _borrowService;
        private readonly IUserService _userService;

        public BorrowsController(IBorrowService borrowService, IUserService userService, IBookService bookService)
        {
            _borrowService = borrowService ?? throw new ArgumentNullException(nameof(borrowService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            var borrows = await _borrowService.GetAllBorrowsAsync();
            return View(borrows);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> IndexAdmin()
        {
            var borrows = await _borrowService.GetAllBorrowsAsync();
            return View(borrows);
        }


        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _borrowService.GetBorrowByIdAsync(id.Value);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }
        [Authorize]
        // GET: Borrows/Create
        public async Task<IActionResult> Create(int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existingBorrow = await _borrowService.GetBorrowByBookAndUserAsync(bookId, userId);
            if (existingBorrow != null)
            {
                TempData["ErrorMessage"] = "You have already borrowed this book.";
                return RedirectToAction(nameof(Index));
            }

            var borrow = new Borrow
            {
                BookId = bookId,
                UserId = userId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14) 
            };

            return View("Create", borrow);
        }
        [Authorize]
        // POST: Borrows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                borrow.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var bookId = borrow.BookId;

                var book = await _bookService.GetBookByIdAsync(bookId);
                if (book == null)
                {
                    return NotFound();
                }

                borrow.BookId = bookId;
                borrow.BorrowDate = DateTime.Now;
                borrow.DueDate = DateTime.Now.AddDays(14);

                await _borrowService.CreateBorrowAsync(borrow);
                return RedirectToAction(nameof(Index));
            }
            return View(borrow);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _borrowService.GetBorrowByIdAsync(id.Value);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _borrowService.GetBorrowByIdAsync(id);
            if (borrow != null)
            {
                await _borrowService.DeleteBorrowAsync(borrow);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
