using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string ComputerName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? ComputerVersion { get; set; }

        public string? SerialNumber { get; set; }

        
    }
}
