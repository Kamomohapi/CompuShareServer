using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        private readonly IComputerApplication _computerApplication;

        public ApplicationController(IComputerApplication computerApplication)
        {
            _computerApplication = computerApplication;
        }

        [HttpPost("Computer-Application")]
       
        public async Task<ActionResult<ResponseHandler>> CreateApplication([FromForm] ComputerApplicationDTO computerApplication)
        {
            var application = await _computerApplication.CreateApplication(computerApplication);

            return new JsonResult(application);
        }


        [HttpGet("Get-All-Applications")]

        public async Task<ActionResult<ComputerApplication>> GetAllApplications()
        {
            var pcApplications = await _computerApplication.GetAllApplication();

            return Ok(pcApplications);
        }
        [HttpPut("Update-ApplicationStatus/{applicationId}")]

        public async Task<ActionResult<ResponseHandler>> UpdateApplicationStatus(string applicationStatus, int applicationId)
        {
            var result = await _computerApplication.UpdateApplicationStatus(applicationStatus, applicationId);

            return Ok(result);
        }

        [HttpGet("get-pending-applications")]
        public async Task<ActionResult<ComputerApplication>> GetPendingApplications()
        {
            var pendingApplications = await _computerApplication.GetPendingApplication();
            return Ok(pendingApplications);
        }

        [HttpGet("get-approved-applications")]
        public async Task<ActionResult<ComputerApplication>> GetApprovedApplications()
        {
            var approvedApplications = await _computerApplication.GetApprovedApplication();
            return Ok(approvedApplications);
        }
        [HttpGet("get-rejected-applications")]
        public async Task<ActionResult<ComputerApplication>> GetRejectedApplications()
        {
            var rejectedApplications = await _computerApplication.GetRejectedApplication();
            return Ok(rejectedApplications);
        }

        [HttpGet("applications-count")]

        public async Task<ActionResult<int>> GetApplicationsCount()
        {
            var countApplications = await _computerApplication.AllApplicationsCount();
            return Ok(countApplications);
        }
        [HttpGet("approved-applications-count")]
        public async Task<ActionResult<int>> GetApprovedApplicationsCount()
        {
            var approvedApplications = await _computerApplication.AllApprovedApplicationsCount();
            return Ok(approvedApplications);
        }
        [HttpGet("rejected-applications-count")]
        public async Task<ActionResult<int>> GetRejectedApplicationsCount()
        {
            var rejectedApplications = await _computerApplication.AllRejectedApplicationsCount();
            return Ok(rejectedApplications);
        }

        /*[HttpPost("upload-document")]
        public async Task<ActionResult> SaveDocumentAsync([FromForm] IFormFile file)
        {


            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                await _computerApplication.SaveDocumentAsync(file);
                return Ok(new { message = "File uploaded and saved successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }*/
    }
}
