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
    internal class Workers : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }
        public DateTime DismissalDate { get; set; }

        
        /////////////////////////////////////
        public List<Specialists> Specialists { get; set; } = new List<Specialists>();
        /////////////////////////////////////
        
        public override string ToString()
        {
            return Id + ";" + FirstName + ";" + LastName + ";" + DateBirth.ToString() + ";" + EmploymentDate.ToString() + ";"  + DismissalDate.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
