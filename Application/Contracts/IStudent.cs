﻿using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IStudent
    {
        Task<LoginResponse> LoginStudent(StudentLoginDTO studentLogin);
        Task<StudentStatusDTO> StudentApplicationStatus();
    }
}
