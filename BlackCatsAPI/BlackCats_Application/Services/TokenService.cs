using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWToken(LoginResponse loginResponse)
        {
            SymmetricSecurityKey secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            SigningCredentials credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim("Id",loginResponse.Id.ToString()),
                new Claim("Email", loginResponse.Email),
                new Claim("Roles", loginResponse.UserRole.ToString())
            });

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddDays(7),
                TokenType = "JWT"
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
