using System.Collections.Generic;

namespace SalesDatabase.Models
{
    /// <summary>
    /// Represents a Product that can be sold in an order.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Primary key for the Products table.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Unique code or SKU representing the product.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Short description of the product.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// The price for a single unit of this product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// One product can appear in multiple order items.
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}