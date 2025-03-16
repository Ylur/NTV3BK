using System;
using System.Collections.Generic;

namespace SalesDatabase.Models
{
    /// <summary>
    /// Represents an Order placed by a Customer.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Primary key for the Orders table.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Date the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The total amount for the entire order.
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Foreign key referencing the Customer who placed this order.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Navigation property for the Customer who placed the order.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// One order can have multiple OrderItems.
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}