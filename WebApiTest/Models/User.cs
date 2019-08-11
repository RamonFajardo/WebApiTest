using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Models
{
    public class User
    {
        public int ID { get; set; }

        [MaxLength(10)]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime CreateDate { get; set; }


        
    }
}
