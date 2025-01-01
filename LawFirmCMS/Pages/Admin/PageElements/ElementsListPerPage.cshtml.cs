using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.PageElements
{
	public class ElementsListPerPageModel : PageModel
	{
		private readonly LawFirmCMS.Data.ApplicationDbContext _context;

		public ElementsListPerPageModel(LawFirmCMS.Data.ApplicationDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public List<PageElement> PageElements { get; set; } = default!;
		public string PageName { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				Console.WriteLine("Null");
				return NotFound();
			}

			PageName = await _context.CustomPages.Where(m => m.Id == id).Select(m => m.Title).FirstOrDefaultAsync();
			PageElements = await _context.PageElements.Where(m => m.PageId == id).ToListAsync();

			return Page();
		}
	}
}
