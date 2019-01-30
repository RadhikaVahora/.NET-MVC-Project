using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingTask.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please Enter Full Name")]
        [DataType(DataType.Text)]
        public string CustomerName { get; set; }
        public string Address { get; set; }

        //Relationship
        public ICollection<Sales> Sales { get; set; } 
    }
}