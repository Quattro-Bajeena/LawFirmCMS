using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public IndexModel(Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public IList<Post> Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_accountService.IsLoggedIn())
            {
                return NotFound();
            }
            Post = await _context.Posts
                .Include(p => p.Employee)
                .Where(p => _accountService.IsBoss() || p.EmployeeId == _accountService.LoggedId())
                .ToListAsync();
            return Page();
        }
    }
}
