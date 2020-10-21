using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockpoint.Models
{
    public class Product
        {
            [Key]
            public int id { get; set; }

            [Required]
            public string category_name { get; set; }

            public Category()
            {
                
            }
        }
}