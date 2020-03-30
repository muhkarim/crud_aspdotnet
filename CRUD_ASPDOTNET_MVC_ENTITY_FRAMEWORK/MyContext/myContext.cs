using CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.MyContext
{
    public class myContext : DbContext
    {
        public myContext() : base("BelajarCRUD_MCC_ASP") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }


    }
}