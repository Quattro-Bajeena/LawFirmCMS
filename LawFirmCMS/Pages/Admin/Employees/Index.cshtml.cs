using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Employees
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

        public IList<Employee> Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_accountService.IsLoggedIn())
            {
                return NotFound();
            }
            Employee = await _context.Employees.Where(e => !e.IsDeleted).ToListAsync();
            return Page();
        }
    }
}
