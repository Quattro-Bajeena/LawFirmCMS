using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class DetailsModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public DetailsModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

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
    }
}
