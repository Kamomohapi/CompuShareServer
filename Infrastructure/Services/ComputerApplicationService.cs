using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ComputerApplicationService : IComputerApplication
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComputerApplicationService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        /*public async Task<ResponseHandler> CreateApplication(ComputerApplication application)
        {
            if (application == null)
                return new ResponseHandler(false, "Application cannot be empty");


            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            var role = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);

            if (userIdClaim != null)
            {
                int studentId = Convert.ToInt32(userIdClaim.Value);

                var studentExists = await _appDbContext.Students.AnyAsync(s => s.StudentId == studentId);
                if (!studentExists)
                    return new ResponseHandler(false, "Student record not found.");


                var studentInfo = _appDbContext.Students.FirstOrDefault(s => s.StudentId == studentId);

                var pcApplication = new ComputerApplication
                {
                    StudentId = studentId,
                    StudentName = studentInfo?.Name,
                    StudentSurname = studentInfo?.Surname,
                    StudentNumber = studentInfo!.StudentNumber,
                    ApplicationStatus = "pending",
                    IsCollected = false,
                };

                var applicationExists = await _appDbContext.Applications
                    .AsTracking()
                    .FirstOrDefaultAsync(s => s.StudentId == pcApplication.StudentId);
                if (applicationExists != null)
                {
                    return new ResponseHandler(false, "Already applied, please check your email for more information");
                }
                _appDbContext.Applications.Add(pcApplication);
                _appDbContext.SaveChanges();
            }
            return new ResponseHandler(true, "Application successful");
        }

        public async Task<ResponseHandler> SaveDocumentAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return new ResponseHandler(false, "Invalid file.");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var document = new Document
            {
                FileName = file.FileName,
                FileData = memoryStream.ToArray(),
                ContentType = file.ContentType
            };

            _appDbContext.Documents.Add(document);
            await _appDbContext.SaveChangesAsync();
            return new ResponseHandler(true, "file uploaded successfully");
        }*/

        public async Task<ResponseHandler> CreateApplication(ComputerApplicationDTO application)
        {
            if (application == null)
                return new ResponseHandler(false, "Application cannot be empty.");

            if (application.File == null || (application.File.Length == 0))
                return new ResponseHandler(false, "Invalid file.");

            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return new ResponseHandler(false, "User not authenticated.");

            int studentId = Convert.ToInt32(userIdClaim.Value);

            int studentNum = await _appDbContext.Students.Where(s => s.StudentId == studentId).Select(s => s.StudentNumber).FirstOrDefaultAsync();

            if (Convert.ToInt32(application.StudentNumber) != studentNum)
            {
                return new ResponseHandler(false, "Student number does not match.");
            }

            using var transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var studentExists = await _appDbContext.Students.AnyAsync(s => s.StudentId == studentId);
                if (!studentExists)
                    return new ResponseHandler(false, "Student record not found.");

                var studentInfo = await _appDbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);

                 if (studentInfo!.IsRegistered == false)
                {
                    return new ResponseHandler(false, "Cannot proceed with the application, you are not registered.");
                }
                else if (studentInfo.IsFunded == true)
                {
                    return new ResponseHandler(false, "Cannot proceed with the application, you already have funding.");
                }

                var applicationExists = await _appDbContext.Applications
                    .AsTracking()
                    .FirstOrDefaultAsync(s => s.StudentId == studentId);
                if (applicationExists != null)
                {
                    return new ResponseHandler(false, "Already applied, please check your email for more information.");
                }

                if (studentInfo.IsRegistered == true && studentInfo.IsFunded == false)
                {
                    var pcApplication = new ComputerApplication
                    {
                        StudentId = studentId,
                        StudentName = studentInfo?.Name,
                        StudentSurname = studentInfo?.Surname,
                        StudentNumber = studentInfo!.StudentNumber,
                        ApplicationStatus = "Approved",
                    };

                    _appDbContext.Applications.Add(pcApplication);
                    await _appDbContext.SaveChangesAsync();

                    using var memoryStream = new MemoryStream();
                    await application.File.CopyToAsync(memoryStream);

                    var document = new Document
                    {
                        FileName = application.File.FileName,
                        FileData = memoryStream.ToArray(),
                        ContentType = application.File.ContentType,
                        ApplicationId = pcApplication.ApplicationId // Assuming the application has an ID property
                    };

                    _appDbContext.Documents.Add(document);
                    await _appDbContext.SaveChangesAsync();

                }
             
                await transaction.CommitAsync();

                return new ResponseHandler(true, "Application and file uploaded successfully.");

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ResponseHandler(false, $"An error occurred: {ex.Message}");
            }
        }


        public async Task<List<ComputerApplication>> GetAllApplication()
        {
            var applications = await _appDbContext.Applications.ToListAsync();

            return applications;
        }

        public async Task<List<ComputerApplication>> GetApprovedApplication()
        {
            var approvedApplications = await (from application in _appDbContext.Applications
                                              join student in _appDbContext.Students
                                              on application.StudentId equals student.StudentId
                                              where application.ApplicationStatus == "Approved"
                                              && student.ComputerId == 0
                                              select application) // <-- We're selecting applications here
                                  .ToListAsync();

            return approvedApplications!;
        }

        public async Task<List<ComputerApplication>> GetPendingApplication()
        {
            var pendingApplications = await _appDbContext.Applications
                .Where(a => a.ApplicationStatus == "Pending")
                .ToListAsync();

            return pendingApplications!;
        }

        public async Task<List<ComputerApplication>> GetRejectedApplication()
        {
            var rejectedApplications = await _appDbContext.Applications
                .Where(a => a.ApplicationStatus == "Rejected")
                .ToListAsync();

            return rejectedApplications!;
        }

        public async Task<ResponseHandler> UpdateApplicationStatus(string applicationStatus, int applicationId)
        {
            var application = await _appDbContext.Applications.FirstOrDefaultAsync(s => s.ApplicationId == applicationId);

            if (application != null)
            {
                application.ApplicationStatus = applicationStatus;
                _appDbContext.SaveChanges();
            }

            else
                return new ResponseHandler(false, "Something went wrong! Please try again");


            return new ResponseHandler(true, "Update successful");
        }

        public async Task<int> AllApplicationsCount()
        {
            return await _appDbContext.Applications.CountAsync();
        }

        public async Task<int> AllApprovedApplicationsCount()
        {
            return await _appDbContext.Applications.Where(a => a.ApplicationStatus == "Approved")
                 .CountAsync();
        }

        public async Task<int> AllRejectedApplicationsCount()
        {
            return await _appDbContext.Applications.Where(a => a.ApplicationStatus == "Rejected")
                .CountAsync();
        }

        public async Task<List<MonthlyRequestDTO>> GetMonthlyApplicationsCount()
        {
            var monthlyRequests = await _appDbContext.Applications.GroupBy(a => new { Year = a.TimeApplied.Year, Month = a.TimeApplied.Month })
                 .Select(g => new MonthlyRequestDTO
                 {
                     Month = $"{g.Key.Year} - {g.Key.Month:D2}",
                     Requests = g.Count()
                 }).OrderBy(x => x.Month)
                 .ToListAsync();

            return monthlyRequests;
        }

        
    } 
}
