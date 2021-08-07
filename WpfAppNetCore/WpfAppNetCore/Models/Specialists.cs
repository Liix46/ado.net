using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    class Specialists
    {
        public int Id { get; set; }

        public List<Branches> Branches { get; set; } = new List<Branches>();
        public List<Workers> Workers { get; set; } = new List<Workers>();
        public List<Position> Positions { get; set; } = new List<Position>();

        public int? ProgressStudyId { get; set; }
        public ProgressStudy ProgressStudy { get; set; }
    }
}
