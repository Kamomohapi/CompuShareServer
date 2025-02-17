using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IComputerApplication
    {
        Task<ResponseHandler> CreateApplication(ComputerApplicationDTO application);
        Task<List<ComputerApplication>>GetAllApplication();
        Task <ResponseHandler> UpdateApplicationStatus(string applicationStatus, int applicationId);
        Task <List<ComputerApplication>> GetPendingApplication();
        Task<List<ComputerApplication>> GetApprovedApplication();
        Task<List<ComputerApplication>> GetRejectedApplication();
        Task <int> AllApplicationsCount();
        Task<int> AllApprovedApplicationsCount();
        Task<int> AllRejectedApplicationsCount();
        Task<List<MonthlyRequestDTO>> GetMonthlyApplicationsCount();
        //Task<ResponseHandler> SaveDocumentAsync(IFormFile file);

    }
}
