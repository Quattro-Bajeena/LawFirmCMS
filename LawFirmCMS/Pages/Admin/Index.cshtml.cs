using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {

        private ApplicationDbContext _context;

        public List<CustomPage> TopPages { get; set; }

        public AdminIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            TopPages = _context.CustomPages.Include(p => p.Children).Where(page => page.IsGroup && !page.IsDeleted).ToList();
        }

        public async Task OnGetDelete(int id)
        {
            var pageToDelete = _context.CustomPages.FirstOrDefault(page => page.Id == id);
            if (pageToDelete != null)
            {
                pageToDelete.IsDeleted = true;
                _context.CustomPages.Update(pageToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
