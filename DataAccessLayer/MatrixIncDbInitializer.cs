using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer
                {
                    Name = "Neo",
                    StreetName = "Elm St",
                    HouseNumber = "123",
                    PostalCode = "10001",
                    CityName = "Zion City",
                    Country = "Matrixland",
                    Active = true,
                    JoinDate = DateTime.Parse("2020-01-01")
                },
                new Customer
                {
                    Name = "Morpheus",
                    StreetName = "Oak St",
                    HouseNumber = "456",
                    PostalCode = "10002",
                    CityName = "Zion City",
                    Country = "Matrixland",
                    Active = true,
                    JoinDate = DateTime.Parse("2020-02-15")
                },
                new Customer
                {
                    Name = "Trinity",
                    StreetName = "Pine St",
                    HouseNumber = "789",
                    PostalCode = "10003",
                    CityName = "Zion City",
                    Country = "Matrixland",
                    Active = true,
                    JoinDate = DateTime.Parse("2020-03-10")
                }
            };

            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order
                {
                    Customer = customers[0],
                    OrderDate = DateTime.Parse("2021-01-01"),
                    Status = OrderStatus.Pending
                    // Nog niet betaald, verzonden of geleverd
                },
                new Order
                {
                    Customer = customers[0],
                    OrderDate = DateTime.Parse("2021-02-01"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2021-02-02") // Betaald, maar nog niet verzonden
                },
                new Order
                {
                    Customer = customers[1],
                    OrderDate = DateTime.Parse("2021-02-01"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-02-02"),
                    ShippedAt = DateTime.Parse("2021-02-03")
                },
                new Order
                {
                    Customer = customers[2],
                    OrderDate = DateTime.Parse("2021-03-01"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-03-02"),
                    ShippedAt = DateTime.Parse("2021-03-03"),
                    DeliveredAt = DateTime.Parse("2021-03-05")
                }
            };
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product
                {
                    Name = "Nebuchadnezzar",
                    Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen",
                    Price = 10000.00m,
                    StockQuantity = 2,
                    ImageUrl = "img/Nebuchadnezzar.webp",
                },
                new Product
                {
                    Name = "Jack-in Chair",
                    Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort",
                    Price = 500.50m,
                    SalePrice = 450.00m,
                    SaleStartDate = DateTime.UtcNow.AddDays(-5),
                    SaleEndDate = DateTime.UtcNow.AddDays(30),
                    StockQuantity = 10,
                    ImageUrl = "img/jackinchair.png",
                    CreatedAt = DateTime.Parse("1999-03-31")
                },
                new Product
                {
                    Name = "EMP (Electro-Magnetic Pulse) Device",
                    Description = "Wapentuig op de schepen van Zion",
                    Price = 129.99m,
                    SalePrice = 99.99m,
                    SaleStartDate = DateTime.UtcNow,
                    SaleEndDate = DateTime.UtcNow.AddDays(30), //on sale  
                    StockQuantity = 5,
                    ImageUrl = "img/emp.png",
                    CreatedAt = DateTime.UtcNow.AddDays(-20)
                }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);

            products[0].Parts.Add(parts[0]);
            products[0].Parts.Add(parts[1]);
            products[1].Parts.Add(parts[1]);
            products[1].Parts.Add(parts[2]);
            products[2].Parts.Add(parts[3]);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
