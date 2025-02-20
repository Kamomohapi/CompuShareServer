using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComputerApplication
    {
        [Key]
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public string? StudentName { get; set; }
        public int StudentNumber { get; set; }
        public string? StudentSurname { get; set; }
        public string? ApplicationStatus { get; set; }
        public DateTime TimeApplied { get; set; } = DateTime.Now;
    
        

    }
}
