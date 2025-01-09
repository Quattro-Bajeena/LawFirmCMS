using LawFirmCMS.Data;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LawFirmCMS.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {

        private ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public AdminIndexModel(ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public string Login { get; set; }
        [BindProperty]
        public string Password { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            if (_accountService.IsLoggedIn())
            {
                if (_accountService.IsBoss())
                {
                    return RedirectToPage("./CustomPages/Index");
                }
                else
                {
                    return RedirectToPage("./Posts/Index");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_accountService.Login(Login, Password))
            {
                if (_accountService.IsBoss())
                {
                    return RedirectToPage("./CustomPages/Index");
                }
                else
                {
                    return RedirectToPage("./Posts/Index");
                }
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostLogout()
        {
            if (!_accountService.IsLoggedIn())
            {
                return NotFound();
            }
            _accountService.Logout();
            return RedirectToPage("./Index");
        }
    }
}
