using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class NameCourses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int? CoursesId { get; set; }
        public virtual Courses Courses { get; set; }
        public int? GroupsId { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
