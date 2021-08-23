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
    internal class ContactsBranches : INotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string WebSite { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        ////////////////////////////
        public int? BranchesId { get; set; }
        [ForeignKey("BranchesId")]
        public virtual Branches Branches { get; set; }
        ////////////////////////////
        
        public override string ToString()
        {
            return Id + ";" + WebSite + ";" + Phone + ";" + BranchesId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
