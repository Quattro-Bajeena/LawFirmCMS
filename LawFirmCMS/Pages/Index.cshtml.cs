using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LawFirmCMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            RedirectToPage();
        }

        public void OnGet()
        {

        }
    }
}
