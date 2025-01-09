using LawFirmCMS.Data.Enums;
using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawFirmCMS.Pages.Admin.PageElements
{
    public class CreateModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;
        private readonly AccountService _accountService;

        public CreateModel(LawFirmCMS.Data.ApplicationDbContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public int ParentPageId { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null || !_accountService.IsBoss())
            {
                return NotFound();
            }

            ParentPageId = (int)id;

            ViewData["PageId"] = new SelectList(_context.CustomPages.Where(page => page.Id == ParentPageId), "Id", "Title", ParentPageId);
            ViewData["Type"] = new SelectList(Enum.GetValues(typeof(PageElementType)), PageElementType.RichText);
            ViewData["Employees"] = new SelectList(_context.Employees, "Id", "Login");
            return Page();
        }

        [BindProperty]
        public PageElement PageElement { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!_accountService.IsBoss())
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    Console.WriteLine($"Key: {state.Key}, value: {state.Value.ToString()}");

                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
                ViewData["Type"] = new SelectList(Enum.GetValues(typeof(PageElementType)));
                ViewData["PageId"] = new SelectList(_context.CustomPages, "Id", "Title");
                return Page();
            }

            var file = Request.Form.Files["fileInput"];
            if (file != null && file.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("File", "Only image files (.jpg, .jpeg, .png, .gif) are allowed.");
                }

                if (file.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    ModelState.AddModelError("File", "File size must be less than 5 MB.");
                }

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                PageElement.BinaryData = memoryStream.ToArray();
            }

            var page = _context.CustomPages.Single(p => p.Id == PageElement.PageId);
            PageElement.Order = page.Elements.Count > 0 ? page.Elements.Max(pe => pe.Order) + 1 : 0;

            _context.PageElements.Add(PageElement);
            await _context.SaveChangesAsync();

            return RedirectToPage("ElementsListPerPage", new { id = PageElement.PageId });

        }
    }
}
