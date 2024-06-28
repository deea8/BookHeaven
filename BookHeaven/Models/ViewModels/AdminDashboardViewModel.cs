using System.Collections.Generic;
using BookHeaven.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookHeaven.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int BorrowId { get; set; }
        public Borrow Borrow { get; set; }
    }
}
