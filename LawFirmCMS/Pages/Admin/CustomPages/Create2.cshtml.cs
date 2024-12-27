using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LawFirmCMS.Pages.Admin.Pages
{
    public class CreateModel : PageModel
    {


        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int? parentId)
        {
            GroupPages = _context.CustomPages.Where(page => page.IsGroup).ToList();
            if (parentId != null)
            {
                Page = new CustomPage
                {
                    ParentId = parentId,
                    IsGroup = false,
                };
            }
            else
            {
                Page = new CustomPage
                {
                    IsGroup = true,
                };
            }

        }

        [BindProperty]
        public CustomPage? Page { get; set; }

        public IEnumerable<CustomPage> GroupPages { get; set; } = new List<CustomPage>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Request.GetEncodedUrl());
            }

            if (Page != null) _context.CustomPages.Add(Page);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Index");
        }


    }
}
