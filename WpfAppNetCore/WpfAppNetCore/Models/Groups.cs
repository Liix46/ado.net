using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNetCore.Models
{
    internal class Groups : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        //////////////////////////////////////
        public int? ClientsId { get; set; }
        [ForeignKey("ClientsId")]
        public Clients Clients { get; set; }
        ///
        public int? NameCoursesId { get; set; }
        [ForeignKey("NameCoursesId")]
        public NameCourses NameCourses { get; set; }
        ///
        public int? NameGroupsId { get; set; }
        [ForeignKey("NameGroupsId")]
        public NameGroups NameGroups { get; set; }
        //////////////////////////////////////// 
        public List<ProgressStudy> ProgressStudy { get; set; } = new List<ProgressStudy>();
        //////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Id + ";" + ClientsId + ";" + NameCoursesId + ";" + NameGroupsId;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
