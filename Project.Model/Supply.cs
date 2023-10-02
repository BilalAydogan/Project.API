﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [Table("tblSupply")]
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Offer {  get; set; }
    }
}
