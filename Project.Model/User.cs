using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblUser")]
    public class User
    {
        public User() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public int RolId { get; set; }
        public int DepartmentId { get; set; }
        public int? SupervisorId { get; set; }

        public virtual User? Supervisor  { get; set; }//Bunu Kontrol Et V.Aka Mehmet...

    }
}