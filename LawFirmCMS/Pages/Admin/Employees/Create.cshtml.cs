using LawFirmCMS.Data.Models;
using LawFirmCMS.Helpers;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Pages.Admin.Employees
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public CreateModel(Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        [BindProperty]
        [Required]
        public string Password { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
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

            Employee.PasswordHash = AccountService.HashPasword(Password);
            Employee.Picture = await DataHelper.GetImageFromForm(Request.Form, ModelState);
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
