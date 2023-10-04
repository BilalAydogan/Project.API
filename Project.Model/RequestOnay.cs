using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblRequestOnay")]
    public class RequestOnay
    {
        public int Id { get; set; }
        public bool Onay { get; set; }
        public virtual User User { get; set; }
        public virtual Request Product { get; set; }
    }
}
