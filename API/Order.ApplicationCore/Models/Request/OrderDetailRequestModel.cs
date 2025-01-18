using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Models.Request
{
    public class OrderDetailRequestModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required Entities.Order Order { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive integer.")]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Qty { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "Discount must be a non-negative value.")]
        public decimal Discount { get; set; }
    }
}
