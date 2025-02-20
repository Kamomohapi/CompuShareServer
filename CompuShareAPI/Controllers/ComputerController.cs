using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputer _computer;

        public ComputerController(IComputer computer)
        {
            _computer = computer;
        }


        [HttpPost("Add-Computer")]
        public async Task<ActionResult<ComputerDTO>> StorePC(ComputerDTO computerDTO)
        {
            var pcStore = await _computer.StorePC(computerDTO);

            return Ok(pcStore);
        }

        [HttpGet("veiw-computers")]
        public async Task<ActionResult<Computer>> GetPcs()
        {
            var computers = await _computer.GetPCs();
            return Ok(computers);
        }
        [HttpPut("assign-computer/{studentnumber}")]
        public async Task<ActionResult> AssignPc(int studentnumber)
        {
            var assignPc = await _computer.AssignComputer(studentnumber);
            return Ok(assignPc);
        }
    }
}
