using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Views
{
    [Table("V_DepartmentCompany")]
    public class V_DepartmentCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}
