using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Services.Interfaces;
using FilmReviewAPI.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmReviewAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var user = await _unitOfWork.UserRepository.GetUserWithRolesByUsernameAsync(username);

            if (user == null || !PasswordHashUtils.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Wrong username or password");
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
            if (await _unitOfWork.UserRepository.GetUserWithRolesByUsernameAsync(username) != null)
            {
                throw new ArgumentException("Username \"" + username + "\" is already taken");
            }

            PasswordHashUtils.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var userRole = await _unitOfWork.RoleRepository.GetRoleByNameAsync("User");
            if (userRole != null)
            {
                user.Roles = new List<Role>() { userRole };
            }

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return user;
        }

        public async Task GrantRole(int userId, int roleId)
        {
            var user = await _unitOfWork.UserRepository.GetUserWithRolesByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("Username doesn't exist");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                throw new ArgumentException("Role doesn't exist");
            }

            if (user.Roles.FirstOrDefault(x => x.Id == roleId) != null)
            {
                throw new ArgumentException("Role already granted");
            }

            user.Roles.Add(role);

            await _unitOfWork.SaveAsync();
        }
    }
}
