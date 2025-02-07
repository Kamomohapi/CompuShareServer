using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;

namespace Infrastructure.Services
{

    public class StudentService:IStudent
    {
       private readonly AppDbContext _appDbContext;
       private readonly IConfiguration _configuration;
       //private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentService(AppDbContext appDbContext, IConfiguration configuration)
        {
            this._appDbContext = appDbContext;
            this._configuration = configuration;
            //this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> LoginStudent(StudentLoginDTO studentLogin)
        {
            var getStudent = await FindStudentByEmail(studentLogin.StudentEmail!);

            if (getStudent == null)
            {
                return new LoginResponse(false, "User not found!");
            }
            bool checkPassword = BCrypt.Net.BCrypt.Verify(studentLogin.Password, getStudent.Password);

            if (checkPassword)
                return new LoginResponse(true, "Login successful", GenerateJWTToken(getStudent));
            else
                return new LoginResponse(false, "Invalid credentials");


        }

        private string GenerateJWTToken(Student student)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.StudentNumber.ToString()),
                new Claim(ClaimTypes.Name, student.Name),
                new Claim(ClaimTypes.Email, student.StudentEmail),
                new Claim(ClaimTypes.Role,"Student")
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

        public async Task<Student?>FindStudentByEmail(string email)
        {
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.StudentEmail == email);
            return student;
        }
    }
}
