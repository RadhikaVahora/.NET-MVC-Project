using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnBoardingTask.Models
{
    public class DataEntities : DbContext
    {
        public DataEntities() : base("OnBoard_Task1") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Sales> Sales { get; set; }


    }
}