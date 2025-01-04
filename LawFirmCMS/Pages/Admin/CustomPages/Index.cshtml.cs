using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<CustomPage> ParentlessPages { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ParentlessPages = await _context.CustomPages
                .Where(c => !c.IsDeleted && c.ParentId == null)
                .ToListAsync();
        }
    }
}
