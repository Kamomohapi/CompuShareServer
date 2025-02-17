using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public ComputerApplication? ComputerApplication { get; set; }
        public string? FileName { get; set; }
        public byte[] FileData { get; set; } = new byte[0];
        public string? ContentType { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;

    }
}
