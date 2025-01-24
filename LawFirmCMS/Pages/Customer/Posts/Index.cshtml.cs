using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class IndexModelFront : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ConfigurationService _configurationService;

        public IndexModelFront(Data.ApplicationDbContext context, ConfigurationService configurationService)
        {
            _context = context;
            _configurationService = configurationService;
        }

        public IList<Post> Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_configurationService.IsBlogVisible())
            {
                return NotFound();
            }

            Post = await _context.Posts.Where(post => !post.IsDeleted)
                .Include(p => p.Employee).ToListAsync();

            return Page();
        }
    }
}
