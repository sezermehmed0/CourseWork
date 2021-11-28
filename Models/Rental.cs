using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]

        public int CarId { get; set; }
        public virtual Cars Cars { get; set; }
        [Required]

        public int CustomerId { get; set; }
        

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public double DailyPrice { get; set; }

        public bool? IsAutomatic { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentedFromThisDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentedToThisDate {get; set;}

        public virtual  Customers Customers { get; set; }
        



                
        

    }
}