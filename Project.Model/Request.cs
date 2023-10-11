using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblRequest")]
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ApproveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public int? Status { get; set; }
        public DateTime? ApproveDate { get; set; }

    }
}
