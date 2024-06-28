using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookHeaven.Models;
using BookHeaven.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BookHeaven.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BranchesController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetBranches();
            return View(branches);
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branchService.GetBranchByIdAsync(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchId,Name,Location")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                await _branchService.AddBranchAsync(branch);
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branchService.GetBranchByIdAsync(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId,Name,Location")] Branch branch)
        {
            if (id != branch.BranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _branchService.UpdateBranchAsync(branch);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _branchService.GetBranchByIdAsync(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch != null)
            {
                await _branchService.DeleteBranchAsync(branch);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
