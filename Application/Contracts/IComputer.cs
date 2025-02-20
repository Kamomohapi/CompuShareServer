using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IComputer
    {
        Task <String> StorePC (ComputerDTO computerDTO);
        Task<List<Computer>> GetPCs();
        Task<ResponseHandler> AssignComputer(int studentNum);
    }
}
