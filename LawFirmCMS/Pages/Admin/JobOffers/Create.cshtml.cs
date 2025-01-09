using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LawFirmCMS.Pages.Admin.JobOffers
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
            return Page();
        }

        [BindProperty]
        public JobOffer JobOffer { get; set; } = default!;

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

            _context.JobOffer.Add(JobOffer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
