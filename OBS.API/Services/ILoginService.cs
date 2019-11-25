using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OBS.API.Contexts;
using OBS.API.Model;

namespace OBS.API.Services
{
    public interface ILoginService
    {
        Task<ApplicationUser> GetUserByPhoneNumber(string phoneNumber);
        Task<bool> EmailExists(string email, CancellationToken token);
        Task<bool> PhoneNumberExists(string phoneNumber, CancellationToken token);
    }
    
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginService(ApplicationDbContext context, IConfiguration configuration
            , UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetUserByPhoneNumber(string phoneNumber)
        {
            var info = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            return info;
        }

        public async Task<bool> EmailExists(string email, CancellationToken token)
        {
            if (String.IsNullOrEmpty(email))
            {
                return true;
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> PhoneNumberExists(string phoneNumber, CancellationToken token)
        {
            if (String.IsNullOrEmpty(phoneNumber))
            {
                return true;
            }

            var user = await GetUserByPhoneNumber(phoneNumber);
            if (user == null)
            {
                return true;
            }

            return false;
        }
    }
}