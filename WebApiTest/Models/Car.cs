using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class Car
    {
        public int ID { get; set; }

        [MaxLength(6)]
        public string Placas { get; set; }
            
        public string Marca { get; set; }

        public User Usuario { get; set; }
    }
}
