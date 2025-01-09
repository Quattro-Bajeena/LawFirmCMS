using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly AccountService _accountService;


        public CreateModel(ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public CustomPage CustomPage { get; set; } = default!;

        public IEnumerable<CustomPage> GroupPages { get; set; } = new List<CustomPage>();


        public async Task<IActionResult> OnGetAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }
            GroupPages = _context.CustomPages.Where(page => page.IsGroup).ToList();

            ViewData["ParentId"] = new SelectList(GroupPages, "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }
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
