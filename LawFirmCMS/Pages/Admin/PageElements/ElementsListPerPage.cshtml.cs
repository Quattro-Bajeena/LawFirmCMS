using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class ElementsListPerPageModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public ElementsListPerPageModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [BindProperty]
        public List<PageElement> PageElements { get; set; } = default!;
        public string PageName { get; set; }
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }
            Id = (int)id;
            PageName = await _context.CustomPages.Where(m => m.Id == id).Select(m => m.Title).FirstOrDefaultAsync();
            PageElements = await _context.PageElements
                .Where(m => m.PageId == id && !m.IsDeleted)
                .OrderBy(pe => pe.Order)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostChangeOrder(int page, int id, string direction)
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }
            var element = _context.PageElements.FirstOrDefault(pe => pe.Id == id);
            if (element != null)
            {
                PageElement? otherElement = null;
                if (direction == "up")
                {
                    otherElement = _context.PageElements
                        .Where(pe => pe.PageId == page && !pe.IsDeleted && pe.Order < element.Order)
                        .OrderByDescending(pe => pe.Order)
                        .FirstOrDefault();

                }
                else if (direction == "down")
                {
                    otherElement = _context.PageElements
                        .Where(pe => pe.PageId == page && !pe.IsDeleted && pe.Order > element.Order)
                        .OrderBy(pe => pe.Order)
                        .FirstOrDefault();
                }

                if (otherElement != null)
                {
                    (otherElement.Order, element.Order) = (element.Order, otherElement.Order);
                    _context.Update(otherElement);
                    _context.Update(element);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("ElementsListPerPage", new { id = page });
        }
    }
}
