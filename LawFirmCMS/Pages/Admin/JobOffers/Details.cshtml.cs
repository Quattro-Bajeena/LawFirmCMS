using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.JobOffers
{
    public class DetailsModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public DetailsModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public JobOffer JobOffer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.JobOffer.FirstOrDefaultAsync(m => m.Id == id);
            if (joboffer == null)
            {
                return NotFound();
            }
            else
            {
                JobOffer = joboffer;
            }
            return Page();
        }
    }
}
