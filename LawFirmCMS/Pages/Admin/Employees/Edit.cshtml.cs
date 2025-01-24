using LawFirmCMS.Data.Models;
using LawFirmCMS.Helpers;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Employees
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public EditModel(Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsLoggedIn())
            {
                return NotFound();
            }

            if (_accountService.State() == Data.Enums.SessionState.Employee && _accountService.LoggedId() != id)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            Employee = employee;
            return Page();
        }
        [BindProperty]
        public string? Password { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!_accountService.IsLoggedIn())
            {
                return NotFound();
            }

            if (_accountService.State() == Data.Enums.SessionState.Employee && _accountService.LoggedId() != Employee.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Employee.Id);
            if (!string.IsNullOrEmpty(Password))
            {
                Employee.PasswordHash = AccountService.HashPasword(Password);
            }
            else
            {
                Employee.PasswordHash = employee.PasswordHash;
            }
            if (Request.Form.Files["fileInput"] != null)
            {
                Employee.Picture = await DataHelper.GetImageFromForm(Request.Form, ModelState);
            }
            else
            {
                Employee.Picture = employee.Picture;
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
