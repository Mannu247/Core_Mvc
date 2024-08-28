using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core21824.Models
{
    public class tbluser
    {
        [Key]
        public int uid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
