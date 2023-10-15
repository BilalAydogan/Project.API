using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Views
{
    [Table("V_Storage")]
    public class V_Storage
    {
        public int StorageId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public string DepName { get; set; }
        public int DepId { get; set; }
    }
}
