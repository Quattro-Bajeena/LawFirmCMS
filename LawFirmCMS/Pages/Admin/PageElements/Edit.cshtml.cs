﻿using LawFirmCMS.Data.Enums;
using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public EditModel(Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public PageElement PageElement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var pageElement = await _context.PageElements.FirstOrDefaultAsync(m => m.Id == id);
            if (pageElement == null)
            {
                return NotFound();
            }
            PageElement = pageElement;
            ViewData["PageId"] = new SelectList(_context.CustomPages.Where(page => page.Id == pageElement.PageId), "Id", "Title", pageElement.PageId);
            ViewData["Type"] = new SelectList(Enum.GetValues(typeof(PageElementType)));
            ViewData["Employees"] = new SelectList(_context.Employees, "Id", "Login");
            ViewData["JobOffers"] = new SelectList(_context.JobOffer, "Id", "Position");

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }

            PageElement.Page = _context.CustomPages.Where(p => p.Id == PageElement.PageId).First();

            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    Console.WriteLine($"Key: {state.Key}, value: {state.Value.ToString()}");

                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
                ViewData["Type"] = new SelectList(Enum.GetValues(typeof(PageElementType)));
                ViewData["PageId"] = new SelectList(_context.CustomPages, "Id", "Title");
                return Page();
            }

            var file = Request.Form.Files["fileInput"];
            if (file != null && file.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("File", "Only image files (.jpg, .jpeg, .png, .gif) are allowed.");
                }

                if (file.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    ModelState.AddModelError("File", "File size must be less than 5 MB.");
                }

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                PageElement.BinaryData = memoryStream.ToArray();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PageElement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageElementExists(PageElement.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("ElementsListPerPage", new { id = PageElement.PageId });
        }

        private bool PageElementExists(int id)
        {
            return _context.PageElements.Any(e => e.Id == id);
        }
    }
}
