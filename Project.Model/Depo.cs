using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblDepo")]
    public class Depo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual Department Department { get; set; }
        public virtual Item Item { get; set; }
    }
}
