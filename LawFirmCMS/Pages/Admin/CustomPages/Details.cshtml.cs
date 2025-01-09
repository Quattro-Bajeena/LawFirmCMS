using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public DetailsModel(ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public CustomPage CustomPage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            var custompage = await _context.CustomPages.FirstOrDefaultAsync(m => m.Id == id);
            if (custompage == null)
            {
                return NotFound();
            }
            else
            {
                CustomPage = custompage;
            }
            return Page();
        }
    }
}
