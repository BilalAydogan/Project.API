using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Views
{
    [Table("V_Offer")]
    public class V_Offer
    {
        public int? RequestId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? DepName { get; set; }
        public string? ReqName { get; set; }
        public string? Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? Status { get; set; }
        public DateTime? ApproveDate { get; set; }
    }
}
