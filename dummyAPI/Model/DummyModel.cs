using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dummyAPI.Model
{
    public class DummyModel
    {
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public bool Blocked { get; set; }
    }
}
