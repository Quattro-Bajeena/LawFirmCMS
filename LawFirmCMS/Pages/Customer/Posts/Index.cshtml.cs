using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class IndexModelFront : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModelFront(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.Where(post => !post.IsDeleted)
                .Include(p => p.Employee).ToListAsync();
        }
    }
}
