using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
{
    public class DetailsModelFront : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public DetailsModelFront(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
