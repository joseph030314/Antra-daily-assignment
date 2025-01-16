namespace Order.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public int PaymentMethodId { get; set; }
        public required string PaymentName { get; set; }
        public required string ShippingAddress { get; set; }
        public required string ShippingMethod { get; set; }
        public decimal BillAmount { get; set; }
        public required string OrderStatus { get; set; }

        public required ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
