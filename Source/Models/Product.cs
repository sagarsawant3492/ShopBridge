using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name{get; set;}

        [Required]
        public string Category { get; set; }

        [Required]
        public string ProductCode { get; set; }
        public string Description {get; set;}

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price should not be less than 0")]
        public decimal Price {get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity should not be less than 0")]
        public int Quantity{get; set;}
        public string ManufacturerCode{get; set;}
        public byte [] Image{get; set;}

        [Range(0, double.MaxValue, ErrorMessage = "Quantity should not be less than 0")]
        public decimal Weight{get; set;}
        public string WeightUnit{get; set;}
        public DateTime CreatedOn{get; set;}
        public DateTime LastModifiedOn {get; set;}
        public DateTime ManufactureDate {get; set;}
        public DateTime ExpiryDate {get; set;}
        public bool IsActive { get; set; }

    }

    public class ShopBridgeDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopBridgeDbContext() : base("name=Main")
        {

        }

        //public ShopBridgeDbContext(string connString) 
        //{
        //    DbContext.
        //}
    }
}