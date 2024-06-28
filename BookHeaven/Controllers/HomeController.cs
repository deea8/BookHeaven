using BookHeaven.Models;
using BookHeaven.Models.ViewModels;
using BookHeaven.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BookHeaven.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;


        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

		// GET: Books
		public async Task<IActionResult> Index()
		{
			var books = await _bookService.GetBooksAsync();
			var popularBooks = books.Take(5).ToList();
			return View(popularBooks);
		}


        public IActionResult Details()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            var viewModel = new AdminDashboardViewModel
            {
                Publisher = new Publisher(),
                Author = new Author(),
                Branch = new Branch(),
                Book = new Book(),
                Borrow = new Borrow(),
            };

            return View(viewModel);
        }

        //public IActionResult DetailsBook()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
