using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Customer

{
    public class DynamicPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DynamicPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomPage PageData { get; set; }
        public List<PageElement> PageElements { get; set; }
        public List<string> FinalHTML { get; set; } = new List<string>();


        public async Task<IActionResult> OnGetAsync(string slug, string subSlug)
        {
            if (slug != null && subSlug == null)
            {
                PageData = await _context.CustomPages
                    .FirstOrDefaultAsync(p => p.Path == slug && !p.IsGroup && !p.IsDeleted);
            }
            else if (slug != null && subSlug != null)
            {
                var pageGroup = await _context.CustomPages.FirstOrDefaultAsync(p => p.Path == slug && p.IsGroup && !p.IsDeleted);
                PageData = pageGroup.Children.FirstOrDefault(child => child.Path == subSlug && !child.IsDeleted);
            }



            PageElements = await _context.PageElements
                .Where(pe => pe.PageId == PageData.Id && !pe.IsDeleted)
                .OrderBy(pe => pe.Order)
                .ToListAsync();

            if (PageData == null)
            {
                return NotFound();
            }

            return Page();
        }


    }
}
