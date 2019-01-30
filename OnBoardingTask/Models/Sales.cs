﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingTask.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
       

        //Relationship
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}