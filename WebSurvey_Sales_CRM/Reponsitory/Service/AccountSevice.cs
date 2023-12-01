using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;
namespace WebSurvey_Sales_CRM.Reponsitory.Service
{
    public class AccountSevice : IAccount
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountSevice(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //Register
        public async Task<IEnumerable<User>> Register(User user)
        {
            try
            {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return _context.Users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }

        //create a string MD5
        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        //Login
        public async Task<User> LoginAsync(string userName, string password)
        {
            try
            {
                var hashedPassword = HashPassword(password);
                var user = await _context.Users
                    .FirstOrDefaultAsync(s => s.UserName.Equals(userName) && s.Password.Equals(hashedPassword));

                if (user != null)
                {
                    _httpContextAccessor.HttpContext?.Session.SetString("DisplayName", user.DisplayName);
                    _httpContextAccessor.HttpContext?.Session.SetString("UserName", user.UserName);
                    _httpContextAccessor.HttpContext?.Session.SetInt32("idUser", user.Id);

                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

            return null;
        }


    }
}
