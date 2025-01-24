using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public DeleteModel(Data.ApplicationDbContext context, AccountService accountService)
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
            if (id == null || !_accountService.IsBoss())
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
