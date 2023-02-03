using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Utils;
using Products.Domain.ViewModel;
using Products.Repository.Interface;
using Products.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Products.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }

        public string SignUp(UserViewmodel user)
        {
            var userExists = _user.GetUserByUsername(user.Username);

            if (userExists != null) throw new Exception("User already exists");

            var encryptedPassword = Convert.ToBase64String(Criptography.Encrypt(user.Password));

            var newUser = new User(user.Username, encryptedPassword);

            _user.AddUser(newUser);

            return $"User account {user.Username} was created successfully. Login to get the access Token to the Product endpoints.";
        }

        public string Login(UserViewmodel user)
        {
            var loggedUser = _user.GetUserByUsername(user.Username);

            if (loggedUser == null) throw new ProductException("User not found");

            var encryptedPassword = Convert.ToBase64String(Criptography.Encrypt(user.Password));

            if (loggedUser.Password != encryptedPassword) throw new ProductException("User not found");

            return GenerateToken(loggedUser.Username);
        }

        private string GenerateToken(string username)
        {
            var authSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, username),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            expires: DateTime.Now.AddYears(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
