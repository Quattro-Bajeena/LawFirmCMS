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
    public class DetailsModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public DetailsModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
