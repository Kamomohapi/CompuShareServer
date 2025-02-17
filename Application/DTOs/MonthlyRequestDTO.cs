using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MonthlyRequestDTO
    {
        public string? Month { get; set; } 
        public int Requests { get; set; }
    }
}
