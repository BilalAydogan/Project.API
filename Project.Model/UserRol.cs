using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblUserRol")]
    public class UserRol
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }
    }
}
