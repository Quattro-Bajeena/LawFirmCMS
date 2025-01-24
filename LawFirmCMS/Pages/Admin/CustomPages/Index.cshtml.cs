using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public IndexModel(Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        public IList<CustomPage> ParentlessPages { get; set; } = default!;

        [BindProperty]
        public string FooterValue { get; set; }

        [BindProperty]
        public bool PostVisibleValue { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }

            FooterValue = (await _context.Configurations.FirstOrDefaultAsync(conf => conf.Key == Configuration.FOOTER)).Value;
            PostVisibleValue = Boolean.Parse((await _context.Configurations.FirstOrDefaultAsync(conf => conf.Key == Configuration.POST_VISIBLE)).Value);

            ParentlessPages = await _context.CustomPages
                .Where(c => c.ParentId == null)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSaveFooter()
        {
            var footer = await _context.Configurations.FirstOrDefaultAsync(conf => conf.Key == Configuration.FOOTER);
            footer.Value = FooterValue;
            _context.Configurations.Update(footer);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSavePostVisible()
        {
            var postVisible = await _context.Configurations.FirstOrDefaultAsync(conf => conf.Key == Configuration.POST_VISIBLE);
            postVisible.Value = PostVisibleValue.ToString();
            _context.Configurations.Update(postVisible);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
