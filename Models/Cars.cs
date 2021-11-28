using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cars
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="Must be below 30 characters")]
        public string Brand { get; set; }

        [Required]
        [StringLength(30,ErrorMessage = "Must be below 30 characters")]
        public string Model { get; set; }

        [Required]
       
        public string EngineType { get; set; }
        [Required]
        public double HorsePower { get; set; }
        [Required]
        public bool IsAutomatic { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }
        [Display(Name ="Position")]
        public int SortableId { get; set; }
   
        public virtual ICollection<Customers> Customers { get; set; }
      


    }
}