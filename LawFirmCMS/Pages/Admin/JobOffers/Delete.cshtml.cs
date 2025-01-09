using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.JobOffers
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
        public JobOffer JobOffer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var joboffer = await _context.JobOffer.FirstOrDefaultAsync(m => m.Id == id);

            if (joboffer == null)
            {
                return NotFound();
            }
            else
            {
                JobOffer = joboffer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var joboffer = await _context.JobOffer.FindAsync(id);
            if (joboffer != null)
            {
                JobOffer = joboffer;
                JobOffer.IsDeleted = true;
                _context.Update(JobOffer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
