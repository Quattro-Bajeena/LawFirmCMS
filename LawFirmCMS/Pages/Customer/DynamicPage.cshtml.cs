using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;
using System.Threading.Tasks;

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

		public async Task<IActionResult> OnGetAsync(string slug)
		{
			// Pobierz stron� z bazy danych na podstawie slug
			PageData = await _context.CustomPages
				.FirstOrDefaultAsync(p => p.Title == slug);

			// Je�li nie znaleziono strony, zwr�� 404
			if (PageData == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
