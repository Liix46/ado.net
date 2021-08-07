using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int RateHour { get; set; }

        public int? SpecialistsId { get; set; }
        public virtual Specialists Specialists { get; set; }
    }
}
