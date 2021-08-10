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
    internal class Courses : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CountHours { get; set; }
        public string Describe { get; set; }


        //////////////////////////////////
        public int? NameCoursesId { get; set; }
        [ForeignKey("NameCoursesId")]
        public virtual NameCourses NameCourses { get; set; }
        /// 
        public int? SubjectsId { get; set; }
        [ForeignKey("SubjectsId")]
        public virtual Subjects Subjects { get; set; }
        //////////////////////////////////


        public override string ToString()
        {
            return Id + ";"+ CountHours + ";" + Describe + ";" + NameCoursesId + ";" + SubjectsId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
