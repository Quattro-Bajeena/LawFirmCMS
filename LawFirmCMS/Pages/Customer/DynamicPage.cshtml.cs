using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using System.Threading.Tasks;
using LawFirmCMS.Data.Enums;
using System.Net;

namespace LawFirmCMS.Pages.Customer

{
	public class DynamicPageModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public DynamicPageModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public CustomPage PageData { get; set; }
		public List<PageElement> PageElements { get; set; }
		public List<string> FinalHTML { get; set; } = new List<string>();


		public async Task<IActionResult> OnGetAsync(string slug)
		{
			PageData = await _context.CustomPages
				.FirstOrDefaultAsync(p => p.Title == slug && !p.IsDeleted);

			PageElements = await _context.PageElements
				.Where(pe => pe.PageId == PageData.Id && !pe.IsDeleted) 
				.OrderBy(pe => pe.Order)                              
				.ToListAsync();

			if (PageData == null)
			{
				return NotFound();
			}

			return Page();
		}


	}
}
