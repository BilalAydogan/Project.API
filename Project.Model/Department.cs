using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblDepartment")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
