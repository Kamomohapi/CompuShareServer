using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ComputerService : IComputer
    {

        private readonly AppDbContext _appDbContext;
        public ComputerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseHandler> AssignComputer(int studentNum)
        {
            // Get the student from the database
            var student = await _appDbContext.Students.Where(s => s.StudentNumber == studentNum).FirstOrDefaultAsync();
            int countPcs = await _appDbContext.Computers.Where(a => a.IsAssigned == false).CountAsync();
            
            if (student == null)
            {
                return new ResponseHandler(false, "Student not found.");
            }

            // Check if the student already has an assigned computer
            if (student.ComputerId == 0)
            {
                ///return new ResponseHandler(false, "Student already has a computer assigned.");
                var availablePc = await _appDbContext.Computers.FirstOrDefaultAsync(pc => !pc.IsAssigned);
                if (availablePc == null)
                {
                    return new ResponseHandler(false, "No available computers.");
                }
                student.ComputerId = availablePc.ComputerId;
                availablePc.IsAssigned = true;
                await _appDbContext.SaveChangesAsync();
            }

            return new ResponseHandler(true, $"Computer assigned to student {studentNum}.");
        }


        public async Task<List<Computer>> GetPCs()
        {
            var computers = await _appDbContext.Computers.ToListAsync();
            return computers;
        }

        public async Task<String> StorePC(ComputerDTO computerDTO)
        {
            string message = "Computer added sucessfully"; 

            var existingComputer = _appDbContext.Computers.
                FirstOrDefault(c => c.SerialNumber == computerDTO.SerialNumber);

            if (existingComputer != null)
            {
                throw new Exception($"A computer with serial number {computerDTO.SerialNumber}, {computerDTO.ComputerName}, " +
                    $"{computerDTO.ComputerVersion} already exists.");
            }

            var computer = new Computer
            {
                ComputerName = computerDTO.ComputerName!,
                ComputerVersion = computerDTO.ComputerVersion,
                SerialNumber = computerDTO.SerialNumber
            };

            _appDbContext.Add(computer);
            _appDbContext.SaveChanges();

            return message;
        }


        
    }
}