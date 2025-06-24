using Microsoft.IdentityModel.Tokens;
using ProdutosApiReact.Context;
using ProdutosApiReact.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProdutosApiReact.Models;

namespace ProdutosApiReact.Services
{
    public class AuthenticateService
    {

        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public AuthenticateService(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        public UserToken? Authenticate(LoginModel login)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            if (user == null) return null;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Usuario = user.Email
            };
        }
    }
}
