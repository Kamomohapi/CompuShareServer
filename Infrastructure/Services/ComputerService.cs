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
                    $"{computerDTO.ComputerVerison} already exists.");
            }

            var computer = new Computer
            {
                ComputerName = computerDTO.ComputerName!,
                ComputerVersion = computerDTO.ComputerVerison,
                SerialNumber = computerDTO.SerialNumber
            };

            _appDbContext.Add(computer);
            _appDbContext.SaveChanges();

            return message;
        }


        
    }
}