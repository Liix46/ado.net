using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class ContactsBranches
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string WebSite { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        public List<Branches> Branches { get; set; } = new List<Branches>();
    }
}
