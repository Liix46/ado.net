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
    internal class Branches : INotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        /////////////////////////////////////
        public List<ContactsBranches> ContactsBranches { get; set; } = new List<ContactsBranches>();
        public List<Specialists> Specialists { get; set; } = new List<Specialists>();
        /////////////////////////////////////

        public override string ToString()
        {
            return Id + ";" + Country + ";" + City + ";" + Street;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
