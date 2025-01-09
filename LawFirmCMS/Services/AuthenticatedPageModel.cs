using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LawFirmCMS.Services
{
    public abstract class AuthenticatedPageModel : PageModel
    {
        private readonly AccountService _accountService;
        public AuthenticatedPageModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return await OnGetAsyncAuthenticated();
        }

        protected abstract Task<IActionResult> OnGetAsyncAuthenticated();


        public async Task<IActionResult> OnPostAsync()
        {
            return await OnPostAsyncAuthenticated();
        }

        protected abstract Task<IActionResult> OnPostAsyncAuthenticated();
    }
}
