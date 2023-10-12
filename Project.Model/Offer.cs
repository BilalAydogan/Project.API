using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblOffer")]
    public class Offer
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string UserName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public DateTime OfferDate { get; set; }
        
    }
}
