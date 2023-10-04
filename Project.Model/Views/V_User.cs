using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Views
{
    [Table("V_User")]
    public class V_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public string RolName { get; set; }
        public int DepId { get; set; }
        public string DepName { get; set; }
        public int? CompId { get; set; }
        public string? CompName { get; set; }
    }
}
