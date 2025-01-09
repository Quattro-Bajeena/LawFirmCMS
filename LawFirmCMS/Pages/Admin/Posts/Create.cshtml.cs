using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class CreateModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public CreateModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Login");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!_accountService.IsLoggedIn())
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.PublishDate = DateTime.Now;
            Post.EmployeeId = (int)_accountService.LoggedId();
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
