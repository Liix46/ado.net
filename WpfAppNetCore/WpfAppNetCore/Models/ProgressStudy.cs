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
    internal class ProgressStudy : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Subject { get; set; }
        public int CountHours { get; set; }

        ///////////////////////////////////
        public int? SpecialistsId { get; set; }
        [ForeignKey("SpecialistsId")]
        public Specialists Specialists { get; set; }
        /// 
        public int? GroupsId { get; set; }
        [ForeignKey("GroupsId")]
        public Groups Groups { get; set; }
        ///////////////////////////////////
        public override string ToString()
        {
            return Id + ";" + Subject + ";" + CountHours + ";" + SpecialistsId + ";" + GroupsId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
