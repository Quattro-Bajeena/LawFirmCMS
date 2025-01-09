using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Posts
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
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsLoggedIn())
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || !_accountService.IsLoggedIn())
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                Post = post;
                Post.IsDeleted = true;
                _context.Update(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
