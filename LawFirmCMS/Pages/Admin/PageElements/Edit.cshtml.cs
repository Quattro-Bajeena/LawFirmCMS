using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using LawFirmCMS.Data.Enums;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class EditModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public EditModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PageElement PageElement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageelement =  await _context.PageElements.FirstOrDefaultAsync(m => m.Id == id);
            if (pageelement == null)
            {
                return NotFound();
            }
            PageElement = pageelement;
			ViewData["PageId"] = new SelectList(_context.CustomPages, "Id", "Title");
			ViewData["Type"] = new SelectList(Enum.GetValues(typeof(PageElementType)));
			return Page();
		}


		public async Task<IActionResult> OnPostAsync()
		{

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
