using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminService : IAdmin
    {

        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public AdminService(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration; 
            _appDbContext = appDbContext;
        }
        public async Task<LoginResponse> LoginAdmin(AdminDTO adminDTO)
        {
           var findAdmin = _appDbContext.Admins.FirstOrDefault(a=>a.Email == adminDTO.Email);

            if (findAdmin == null)
            {
                return new LoginResponse(false, "User not found!");
            }

            bool checkPassword = BCrypt.Net.BCrypt.Verify(adminDTO.Password, findAdmin.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login successful",GenerateJWTToken(findAdmin));
            else
                return new LoginResponse(false, "Invalid credentials");
            
        }


        private string GenerateJWTToken(Admin admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, admin.Name),
                new Claim(ClaimTypes.Email, admin.Email!),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
