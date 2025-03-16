using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesOrders.Models;  

namespace SalesOrders
{
    /// <summary>
    /// Entry point for the SalesOrders project.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the dependency injection container.
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Use a SQLite database named "SalesOrders.db" located in the current directory.
                options.UseSqlite("Data Source=SalesOrders.db");
            });

            // Build the service provider.
            var serviceProvider = services.BuildServiceProvider();

            // Create a scope and obtain an instance of ApplicationDbContext.
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                // Apply any pending migrations to update the database schema.
                context.Database.Migrate();

                // Check if there are any customers in the database.
                if (!context.Customers.Any())
                {
                    // If not, add a sample customer.
                    var customer = new Customer
                    {
                        // Set sample customer properties. Adjust these based on your model.
                        CustomerName = "Acme Corporation"
                        // For example, you could add:
                        // CustomerAddress = "123 Main St",
                        // CustomerCity = "Anytown",
                        // CustomerEmail = "contact@acme.com"
                    };

                    context.Customers.Add(customer);
                    context.SaveChanges();
                    Console.WriteLine("Added a sample customer: Acme Corporation");
                }
                else
                {
                    Console.WriteLine("Customers already exist in the database.");
                }
            }

            // Inform the user and wait for input before exiting.
            Console.WriteLine("SalesOrders project is running. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
