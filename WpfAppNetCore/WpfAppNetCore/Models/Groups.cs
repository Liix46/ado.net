using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class Groups
    {
        [Key]
        public int Id { get; set; }
        public List<Clients> Clients { get; set; } = new List<Clients>();
        public List<NameCourses> NameCourses { get; set; } = new List<NameCourses>();
        public List<NameGroups> NameGroups { get; set; } = new List<NameGroups>();

        public int? ProgressStudyId { get; set; }
        public ProgressStudy ProgressStudy { get; set; }
    }
}
