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
    internal class Specialists : INotifyPropertyChanged
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //////////////////////
        public int? BranchesId { get; set; }
        [ForeignKey("BranchesId")]
        public virtual Branches Branches { get; set; }
        ///
        public int? WorkersId { get; set; }
        [ForeignKey("WorkersId")]
        public virtual Workers Workers { get; set; }
        /// 
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        //////////////////////
        //////////////////////
        public List<ProgressStudy> ProgressStudy { get; set; } = new List<ProgressStudy>();
        //////////////////////

        public override string ToString()
        {
            return Id + ";" + BranchesId + ";" + WorkersId + ";" + PositionId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
