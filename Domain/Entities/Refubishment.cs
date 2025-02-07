using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Refubishment
    {
        [Key]
        public int RebubishmentId { get; set; }

        public int ComputerId { get; set; }

        [ForeignKey("ComputerId")]
        public Computer? Computer { get; set; }

        public DateTime? DateRefubished { get; set; }
        public DateTime DateReleased { get; set; }

    }
}
