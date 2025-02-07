using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpPost("Admin-Login")]
        public async Task <ActionResult<LoginResponse>> AdminLogin(AdminDTO adminDTO)
        {
            var loginAdmin = await _admin.LoginAdmin(adminDTO);
            return Ok(loginAdmin);
        }

    }
}
