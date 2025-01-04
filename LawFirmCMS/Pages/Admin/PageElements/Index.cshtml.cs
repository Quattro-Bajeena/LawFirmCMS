using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PageElement> PageElement { get; set; } = default!;

        public async Task OnGetAsync()
        {
            PageElement = await _context.PageElements.OrderBy(pe => pe.Order)
                .Include(p => p.Page).ToListAsync();
        }
    }
}
