using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.Dtos
{
    public class ProductDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price should not be less than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity should not be less than 0")]
        public int Quantity { get; set; }
        public string ManufacturerCode { get; set; }
        public string ImageContent { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Quantity should not be less than 0")]
        public decimal Weight { get; set; }
        public string WeightUnit { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
