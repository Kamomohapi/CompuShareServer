using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
       public int StudentId { get; set; }
       public int StudentNumber { get; set; }
       public string Email { get; set; } = string.Empty;
       public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public bool IsRegistered { get; set; } = true;
        public bool IsFunded { get; set; } = true;
        public int ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        Computer? Computer { get; set; }

        public string Password {  get; set; } = string.Empty;
    }
}
