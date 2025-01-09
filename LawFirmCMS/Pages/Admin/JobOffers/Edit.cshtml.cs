using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.JobOffers
{
    public class EditModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public EditModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
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
            JobOffer = joboffer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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

            _context.Attach(JobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(JobOffer.Id))
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

        private bool JobOfferExists(int id)
        {
            return _context.JobOffer.Any(e => e.Id == id);
        }
    }
}
