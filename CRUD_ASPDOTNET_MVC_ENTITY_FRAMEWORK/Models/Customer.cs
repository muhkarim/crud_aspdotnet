using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Models
{
    [Table("TB_M_Customer")] // anotasi nama tabel
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

        public Customer()
        {

        }

      
    }
}