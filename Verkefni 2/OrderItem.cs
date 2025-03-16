namespace SalesDatabase.Models
{
    /// <summary>
    /// Represents an individual line item of an order (Order + Product).
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Composite PK (part 1): The order this item belongs to.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Composite PK (part 2): The product included in the order.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Quantity of the product in this order line.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Line subtotal (optional column; can be computed from Quantity * UnitPrice).
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Navigation property for the Order.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Navigation property for the Product.
        /// </summary>
        public Product Product { get; set; }
    }
}