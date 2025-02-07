using System;
using System.Collections.Generic;
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
       public string StudentEmail { get; set; } = string.Empty;
       public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Password {  get; set; } = string.Empty;
    }
}
