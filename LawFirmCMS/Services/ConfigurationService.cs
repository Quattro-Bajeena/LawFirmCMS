using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Services
{
    public class ConfigurationService
    {
        private readonly ApplicationDbContext _context;
        public ConfigurationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsBlogVisible()
        {
            return Boolean.Parse(_context.Configurations.FirstOrDefault(conf => conf.Key == Configuration.POST_VISIBLE).Value);
        }
    }
}
