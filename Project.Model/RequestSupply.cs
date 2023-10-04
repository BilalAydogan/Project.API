using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblRequestSupply")]
    public class RequestSupply
    {
        public int Id { get; set; }
        public virtual Request Product { get; set; }
        public virtual Supply  Supply { get; set; }
    }
}
