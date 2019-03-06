using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class Store
    {
        public Guid ID { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string NRC { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Product> Products { get; set; }

        

        public Store()
        {

        }
    }
}