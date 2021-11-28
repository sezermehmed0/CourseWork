using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Fname { get; set; }
        [StringLength(30, ErrorMessage = "Must be below 30 characters")]
        public string Lname { get; set; }
        public int age { get; set; }
        [StringLength(30, ErrorMessage = "Must be below 30 characters")]
        public string City { get; set; }
        public double PostCode { get; set; }
        public long? PhoneNumber { get; set; }

        

      

    }
}