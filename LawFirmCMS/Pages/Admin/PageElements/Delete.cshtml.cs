using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class DeleteModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public DeleteModel(LawFirmCMS.Data.ApplicationDbContext context)
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

            var pageelement = await _context.PageElements.FirstOrDefaultAsync(m => m.Id == id);

            if (pageelement == null)
            {
                return NotFound();
            }
            else
            {
                PageElement = pageelement;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageelement = await _context.PageElements.FindAsync(id);
            if (pageelement != null)
            {
                PageElement = pageelement;
                _context.PageElements.Remove(PageElement);
                await _context.SaveChangesAsync();
            }

			return RedirectToPage("ElementsListPerPage", new { id = PageElement.PageId });
		}
    }
}
