using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services;
using BCrypt.Net;

namespace Application.Features.Auth
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IConfiguration _configuration;

        public LoginHandler(IUnitOfWorks unitOfWorks, IConfiguration configuration)
        {
            _unitOfWorks = unitOfWorks;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWorks.Users.GetByEmailAsync(request.Email, cancellationToken);
            
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            var token = GenerateJwtToken(user);

            return new LoginResponse
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(15)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = new JwtSettings
            {
                SecretKey = _configuration["JwtSettings:SecretKey"],
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("email", user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 