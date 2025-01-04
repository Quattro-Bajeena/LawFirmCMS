using LawFirmCMS.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Pages.Admin.Employees
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.Where(e => !e.IsDeleted).ToListAsync();
        }
    }
}
