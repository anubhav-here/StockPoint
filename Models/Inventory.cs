using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockpoint.Models
{
    public class Product
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }

            [Required]
            public int invoice_id {get;set;}

            [Required]
            [ForeignKey("category")]
            public int category_id { get; set; }

            [Required]
            public string item_name { get; set; }

            [Required]
            public string item_model { get; set; }

            [Required]
            public int quantity { get; set; }

            [Required]
            public int price_per_unit { get; set; }

            [Required]
            public string date_of_purchase { get; set; }


            public virtual category Category {get;set;}




            public Inventory()
            {
                
            }
            public Inventory(int invoice_id, int category_id, string item_name, string item_model, int quantity, int price_per_unit, string date_of_purchase)
            {
                this.invoice_id = invoice_id;
                this.category_id = category_id;
                this.item_name = item_name;
                this.item_model = item_model;
                this.quantity = quantity;
                this.price_per_unit = price_per_unit;
                this.date_of_purchase = date_of_purchase;
            }
        }
}