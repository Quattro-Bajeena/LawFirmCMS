using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class CreateModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public CreateModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GroupPages = _context.CustomPages.Where(page => page.IsGroup).ToList();

            ViewData["ParentId"] = new SelectList(GroupPages, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public CustomPage CustomPage { get; set; } = default!;

        public IEnumerable<CustomPage> GroupPages { get; set; } = new List<CustomPage>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CustomPage.IsGroup == true)
                CustomPage.ParentId = null;

            _context.CustomPages.Add(CustomPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
