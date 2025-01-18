using Order.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Models.Request
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Customer ID must be a positive integer.")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string ShippingMethod { get; set; } = string.Empty;
        [Range(0, double.MaxValue, ErrorMessage = "Bill amount must be a non-negative value.")]
        public decimal BillAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
    }
}
