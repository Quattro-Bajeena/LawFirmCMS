using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class DetailsModelFront : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ConfigurationService _configurationService;

        public DetailsModelFront(Data.ApplicationDbContext context, ConfigurationService configurationService)
        {
            _context = context;
            _configurationService = configurationService;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_configurationService.IsBlogVisible())
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Employee).FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }
    }
}
