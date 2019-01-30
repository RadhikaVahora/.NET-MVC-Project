using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingTask.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Enter the Store Name")]
        public string StoreName { get; set; }
        public string Address { get; set; }
    }
}