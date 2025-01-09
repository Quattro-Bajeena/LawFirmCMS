using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        public IList<CustomPage> ParentlessPages { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }

            ParentlessPages = await _context.CustomPages
                .Where(c => !c.IsDeleted && c.ParentId == null)
                .ToListAsync();

            return Page();
        }
    }
}
