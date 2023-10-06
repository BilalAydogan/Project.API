using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblUserDepartment")]
    public class UserDepartment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
    }
}
