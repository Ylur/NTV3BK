using System.Collections.Generic;

namespace SalesDatabase.Models
{
    /// <summary>
    /// Represents a customer entity with basic contact information.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Primary key for the Customers table.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Name of the customer or business.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Street address of the customer.
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// City part of the address.
        /// </summary>
        public string CustomerCity { get; set; }

        /// <summary>
        /// Email contact of the customer.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// A Customer can have multiple orders.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}