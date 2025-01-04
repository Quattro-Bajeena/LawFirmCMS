using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.JobOffers
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<JobOffer> JobOffer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            JobOffer = await _context.JobOffer.Where(jo => !jo.IsDeleted).ToListAsync();
        }
    }
}
