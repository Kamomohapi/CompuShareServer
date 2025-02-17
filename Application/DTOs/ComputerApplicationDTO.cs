using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ComputerApplicationDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? StudentNumber { get; set; }
        public string? Reason { get; set; }
        public string? AcademicYear { get; set; }
        public IFormFile? File { get; set; }


    }
}
