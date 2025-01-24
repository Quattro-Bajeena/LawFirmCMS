using LawFirmCMS.Data;
using LawFirmCMS.Data.Enums;
using LawFirmCMS.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace LawFirmCMS.Services
{
    public class AccountService
    {
        static byte[] salt = Encoding.UTF8.GetBytes("we are not salting");
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public static byte[] HashPasword(string password)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA512, keySize);
            return hash;
        }

        public bool VerifyPassword(string password, byte[] hash)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, hash);
        }

        static string SessionStateKey = "SessionState";
        static string EmployeeIdKey = "EmployeeId";
        static string EmployeeLoginKey = "EmployeLogin";
        public SessionState State()
        {
            if (_httpContextAccessor.HttpContext.Session.GetInt32(SessionStateKey) == null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32(SessionStateKey, (int)SessionState.Anonymous);
            }
            return (SessionState)_httpContextAccessor.HttpContext.Session.GetInt32(SessionStateKey);
        }

        public int? LoggedId()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32(EmployeeIdKey) ?? null;
        }

        public string CurrentLogin()
        {
            return _httpContextAccessor.HttpContext.Session.GetString(EmployeeLoginKey) ?? null;
        }

        public bool IsBoss()
        {
            return State() == SessionState.Boss;
        }

        public bool IsLoggedIn()
        {
            return State() != SessionState.Anonymous;
        }

        public Employee CurrentEmployee()
        {
            return _context.Employees.FirstOrDefault(e => e.Id == LoggedId());
        }

        public bool Login(string login, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Login == login);
            if (employee == null)
            {
                return false;
            }
            if (VerifyPassword(password, employee.PasswordHash))
            {
                SessionState state = employee.Boss ? SessionState.Boss : SessionState.Employee;
                _httpContextAccessor.HttpContext.Session.SetInt32(SessionStateKey, (int)state);
                _httpContextAccessor.HttpContext.Session.SetInt32(EmployeeIdKey, employee.Id);
                _httpContextAccessor.HttpContext.Session.SetString(EmployeeLoginKey, employee.Login);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Session.SetInt32(SessionStateKey, (int)SessionState.Anonymous);
            _httpContextAccessor.HttpContext.Session.Remove(EmployeeIdKey);
            _httpContextAccessor.HttpContext.Session.Remove(EmployeeLoginKey);
        }
    }
}
