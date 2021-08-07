using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CountHours { get; set; }
        public string Describe { get; set; }

        public List<NameCourses> NameCourses { get; set; } = new List<NameCourses>();
        public List<Subjects> Subjects { get; set; } = new List<Subjects>();
    }
}
