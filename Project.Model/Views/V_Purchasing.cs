using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Views
{
    [Table("V_Purchasing")]
    public class V_Purchasing
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
        public string RequestName { get; set; }
        public string RequestDescription { get; set; }
        public int Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public int RequestId { get; set; }
        public string OfferName { get; set; }
        public decimal Price { get; set; }
        public string OfferDescription { get; set; }
        public int? Status { get; set; }
        public DateTime OfferDate { get; set; }
        public int OfferId { get; set; }
        public string DepName { get; set; }
    }
}
