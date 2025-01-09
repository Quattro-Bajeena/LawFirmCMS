using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public DeleteModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                Employee = employee;
                Employee.IsDeleted = true;
                _context.Update(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
