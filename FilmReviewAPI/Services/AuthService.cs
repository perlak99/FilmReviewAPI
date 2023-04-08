using FilmReviewAPI.DAL;
using FilmReviewAPI.Interfaces;
using FilmReviewAPI.Models;
using FilmReviewAPI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FilmReviewAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly FilmReviewDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(FilmReviewDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var user = await _dbContext.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Username == username);

            if (user == null || !PasswordHashUtils.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Wrong username or password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim> {                       
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) 
            };

            var userRoles = user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Name)).ToList();
            if (userRoles != null && userRoles.Any())
            {
                claims.AddRange(userRoles);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> RegisterUserAsync(string username, string password)
        {
            if (await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username) != null)
            {
                throw new Exception("Username \"" + username + "\" is already taken");
            }

            PasswordHashUtils.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var userRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == "User");
            if (userRole != null)
            {
                user.Roles = new List<Role>() { userRole };
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task GrantRole(int userId, int roleId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("Username doesn't exist");
            }

            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            if (role == null)
            {
                throw new Exception("Role doesn't exist");
            }

            user.Roles.Add(role);

            await _dbContext.SaveChangesAsync();
        }
    }
}
