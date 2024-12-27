using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class IndexModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public IndexModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CustomPage> CustomPage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CustomPage = await _context.CustomPages
                .Include(c => c.Parent).ToListAsync();
        }
    }
}
