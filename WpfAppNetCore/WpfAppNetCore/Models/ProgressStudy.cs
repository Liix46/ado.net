using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class ProgressStudy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Subject { get; set; }
        public int CountHours { get; set; }

        public List<Specialists> Specialists { get; set; } = new List<Specialists>();
        public List<Groups> Groups { get; set; } = new List<Groups>();
    }
}
