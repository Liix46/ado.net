using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class Branches
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get;set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        public int? ContactsBranchesId { get; set; }
        public virtual ContactsBranches ContactsBranches { get; set; }

        public int? SpecialistsId { get; set; }
        public virtual Specialists Specialists { get; set; }
    }
}
