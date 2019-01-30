using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingTask.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please Enter Valid price")]
        public int Price { get; set; }

    }
}