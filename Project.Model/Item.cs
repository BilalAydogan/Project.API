using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblItem")]
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }
    }
}
