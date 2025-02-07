using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompuShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        private readonly IStudent _student;

        public StudentController( IStudent student)
        {
           // _configuration = configuration;
            _student = student;
        }

        [HttpPost("Login")]
        public async Task <ActionResult<LoginResponse>> LoginStudent(StudentLoginDTO student)
        {
            var login = await _student.LoginStudent(student);
            
            return Ok(login);
        }
    }
}
