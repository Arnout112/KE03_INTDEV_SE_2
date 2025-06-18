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

            #region Database Creation Customers
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", StreetName = "Elm St", HouseNumber = "123", PostalCode = "10001", CityName = "Zion City", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-01-01") },
                new Customer { Name = "Morpheus", StreetName = "Oak St", HouseNumber = "456", PostalCode = "10002", CityName = "Zion City", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-02-15") },
                new Customer { Name = "Trinity", StreetName = "Pine St", HouseNumber = "789", PostalCode = "10003", CityName = "Zion City", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-03-10") },
                new Customer { Name = "Smith", StreetName = "Maple St", HouseNumber = "101", PostalCode = "10004", CityName = "Matrixville", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-04-01") },
                new Customer { Name = "Oracle", StreetName = "Willow St", HouseNumber = "202", PostalCode = "10005", CityName = "Matrixville", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-05-12") },
                new Customer { Name = "Cypher", StreetName = "Ash St", HouseNumber = "303", PostalCode = "10006", CityName = "Neo City", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-06-23") },
                new Customer { Name = "Tank", StreetName = "Birch St", HouseNumber = "404", PostalCode = "10007", CityName = "Neo City", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-07-04") },
                new Customer { Name = "Dozer", StreetName = "Cedar St", HouseNumber = "505", PostalCode = "10008", CityName = "Zion Heights", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-08-15") },
                new Customer { Name = "Mouse", StreetName = "Hickory St", HouseNumber = "606", PostalCode = "10009", CityName = "Zion Heights", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-09-26") },
                new Customer { Name = "Niobe", StreetName = "Spruce St", HouseNumber = "707", PostalCode = "10010", CityName = "Matrix Hills", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-4-07") },
                new Customer { Name = "Link", StreetName = "Fir St", HouseNumber = "808", PostalCode = "10011", CityName = "Matrix Hills", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-4-18") },
                new Customer { Name = "Zee", StreetName = "Poplar St", HouseNumber = "909", PostalCode = "10012", CityName = "Matrix Hills", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-12-29") },
                new Customer { Name = "Sparks", StreetName = "Aspen St", HouseNumber = "111", PostalCode = "10013", CityName = "Neo Valley", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-01-10") },
                new Customer { Name = "Ghost", StreetName = "Sequoia St", HouseNumber = "222", PostalCode = "10014", CityName = "Neo Valley", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-02-21") },
                new Customer { Name = "Persephone", StreetName = "Palm St", HouseNumber = "333", PostalCode = "10015", CityName = "Zion Central", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-03-04") },
                new Customer { Name = "Merovingian", StreetName = "Bamboo St", HouseNumber = "444", PostalCode = "10016", CityName = "Zion Central", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-04-15") },
                new Customer { Name = "Sati", StreetName = "Teak St", HouseNumber = "555", PostalCode = "10017", CityName = "Zion Central", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-05-26") },
                new Customer { Name = "Seraph", StreetName = "Mahogany St", HouseNumber = "666", PostalCode = "10018", CityName = "Matrix Heights", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-06-07") },
                new Customer { Name = "Bane", StreetName = "Ebony St", HouseNumber = "777", PostalCode = "10019", CityName = "Matrix Heights", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-07-18") },
                new Customer { Name = "Rama", StreetName = "Cherry St", HouseNumber = "888", PostalCode = "10020", CityName = "Matrix Heights", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-08-29") },
                new Customer { Name = "Kamala", StreetName = "Chestnut St", HouseNumber = "999", PostalCode = "10021", CityName = "Neo Heights", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-09-09") },
                new Customer { Name = "The Kid", StreetName = "Olive St", HouseNumber = "112", PostalCode = "10022", CityName = "Neo Heights", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-10-20") },
                new Customer { Name = "Apoc", StreetName = "Laurel St", HouseNumber = "221", PostalCode = "10023", CityName = "Zion West", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-11-01") },
                new Customer { Name = "Switch", StreetName = "Magnolia St", HouseNumber = "332", PostalCode = "10024", CityName = "Zion West", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-12-12") },
                new Customer { Name = "Cain", StreetName = "Redwood St", HouseNumber = "443", PostalCode = "10025", CityName = "Matrix East", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-01-23") },
                new Customer { Name = "Abel", StreetName = "Juniper St", HouseNumber = "554", PostalCode = "10026", CityName = "Matrix East", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2022-02-03") },
                new Customer { Name = "Lock", StreetName = "Sycamore St", HouseNumber = "665", PostalCode = "10027", CityName = "Matrix East", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-03-16") },
                new Customer { Name = "Roland", StreetName = "Hemlock St", HouseNumber = "776", PostalCode = "10028", CityName = "Zion North", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-04-27") },
                new Customer { Name = "Maggie", StreetName = "Dogwood St", HouseNumber = "887", PostalCode = "10029", CityName = "Zion North", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-05-08") },
                new Customer { Name = "Cass", StreetName = "Beech St", HouseNumber = "998", PostalCode = "10030", CityName = "Zion North", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-06-19") },
                new Customer { Name = "Berg", StreetName = "Walnut St", HouseNumber = "109", PostalCode = "10031", CityName = "Zion South", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2022-07-30") },
                new Customer { Name = "Glitch", StreetName = "Cipher St", HouseNumber = "651", PostalCode = "10162", CityName = "Matrix Sector", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-02-04") },
                new Customer { Name = "Proxy", StreetName = "Nova Dr", HouseNumber = "148", PostalCode = "10956", CityName = "Codeville", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-09-08") },
                new Customer { Name = "Cipherpunk", StreetName = "Cipher St", HouseNumber = "440", PostalCode = "10477", CityName = "Zion District", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-04-02") },
                new Customer { Name = "Backdoor", StreetName = "Shadow St", HouseNumber = "204", PostalCode = "10352", CityName = "Matrix Sector", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2023-10-10") },
                new Customer { Name = "Phantom", StreetName = "Shadow St", HouseNumber = "117", PostalCode = "10981", CityName = "Codeville", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-04-01") },
                new Customer { Name = "Warden", StreetName = "Echo Way", HouseNumber = "47", PostalCode = "10521", CityName = "Matrix Sector", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2021-03-26") },
                new Customer { Name = "Specter", StreetName = "Matrix Blvd", HouseNumber = "479", PostalCode = "10597", CityName = "Matrix Sector", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-02-21") },
                new Customer { Name = "Torrent", StreetName = "Cipher St", HouseNumber = "682", PostalCode = "10110", CityName = "Zion District", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2021-12-28") },
                new Customer { Name = "Overseer", StreetName = "Nova Dr", HouseNumber = "19", PostalCode = "10897", CityName = "Zion District", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-07-24") },
                new Customer { Name = "Daemon", StreetName = "Shadow St", HouseNumber = "203", PostalCode = "10277", CityName = "Codeville", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-07-14") },
                new Customer { Name = "Echo", StreetName = "Signal Rd", HouseNumber = "458", PostalCode = "10702", CityName = "Matrix Sector", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2022-08-07") },
                new Customer { Name = "Delta", StreetName = "Matrix Blvd", HouseNumber = "646", PostalCode = "10944", CityName = "Zion District", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2022-04-25") },
                new Customer { Name = "Relay", StreetName = "Shadow St", HouseNumber = "994", PostalCode = "10365", CityName = "Matrix Sector", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2023-09-13") },
                new Customer { Name = "Byte", StreetName = "Proxy Ln", HouseNumber = "305", PostalCode = "10985", CityName = "Matrix Sector", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2023-01-22") },
                new Customer { Name = "Nexus", StreetName = "Nova Dr", HouseNumber = "364", PostalCode = "10428", CityName = "Matrix Sector", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-05-06") },
                new Customer { Name = "Vector", StreetName = "Nova Dr", HouseNumber = "924", PostalCode = "10352", CityName = "Matrix Sector", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-04-17") },
                new Customer { Name = "Kernel", StreetName = "Nova Dr", HouseNumber = "479", PostalCode = "10509", CityName = "Codeville", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2022-08-16") },
                new Customer { Name = "Trojan", StreetName = "Shadow St", HouseNumber = "906", PostalCode = "10222", CityName = "Codeville", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2023-03-23") },
                new Customer { Name = "Pulse", StreetName = "Signal Rd", HouseNumber = "886", PostalCode = "10585", CityName = "Codeville", Country = "Matrixland", Active = false, JoinDate = DateTime.Parse("2020-03-18") },
                new Customer { Name = "Nova", StreetName = "Proxy Ln", HouseNumber = "825", PostalCode = "10337", CityName = "Codeville", Country = "Matrixland", Active = true, JoinDate = DateTime.Parse("2020-06-15") },
            };

            context.Customers.AddRange(customers);
            #endregion

            #region Database creation Orders
            var orders = new Order[]
            {
                new Order
                {
                    Customer = customers[2],
                    OrderDate = DateTime.Parse("2021-12-15"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-12-16"),
                    ShippedAt = DateTime.Parse("2021-12-17"),
                    DeliveredAt = DateTime.Parse("2021-12-19")
                },
                new Order
                {
                    Customer = customers[43],
                    OrderDate = DateTime.Parse("2021-10-10"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[9],
                    OrderDate = DateTime.Parse("2021-04-18"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-04-19"),
                    ShippedAt = DateTime.Parse("2021-04-20")
                },
                new Order
                {
                    Customer = customers[46],
                    OrderDate = DateTime.Parse("2022-03-02"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-03-03"),
                    ShippedAt = DateTime.Parse("2022-03-04"),
                    DeliveredAt = DateTime.Parse("2022-03-06")
                },
                new Order
                {
                    Customer = customers[15],
                    OrderDate = DateTime.Parse("2021-12-27"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-12-28"),
                    ShippedAt = DateTime.Parse("2021-12-29"),
                    DeliveredAt = DateTime.Parse("2021-12-31")
                },
                new Order
                {
                    Customer = customers[7],
                    OrderDate = DateTime.Parse("2021-11-30"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-12-01"),
                    ShippedAt = DateTime.Parse("2021-12-02")
                },
                new Order
                {
                    Customer = customers[27],
                    OrderDate = DateTime.Parse("2022-06-05"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-06-06"),
                    ShippedAt = DateTime.Parse("2022-06-07")
                },
                new Order
                {
                    Customer = customers[18],
                    OrderDate = DateTime.Parse("2021-12-12"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-12-13"),
                    ShippedAt = DateTime.Parse("2021-12-14"),
                    DeliveredAt = DateTime.Parse("2021-12-16")
                },
                new Order
                {
                    Customer = customers[7],
                    OrderDate = DateTime.Parse("2022-04-24"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-04-25"),
                    ShippedAt = DateTime.Parse("2022-04-26"),
                    DeliveredAt = DateTime.Parse("2022-04-28")
                },
                new Order
                {
                    Customer = customers[12],
                    OrderDate = DateTime.Parse("2021-04-30"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-05-01"),
                    ShippedAt = DateTime.Parse("2021-05-02"),
                    DeliveredAt = DateTime.Parse("2021-05-04")
                },
                new Order
                {
                    Customer = customers[20],
                    OrderDate = DateTime.Parse("2022-12-14"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[9],
                    OrderDate = DateTime.Parse("2022-08-30"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-08-31"),
                    ShippedAt = DateTime.Parse("2022-09-01"),
                    DeliveredAt = DateTime.Parse("2022-09-03")
                },
                new Order
                {
                    Customer = customers[4],
                    OrderDate = DateTime.Parse("2021-07-12"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-07-13"),
                    ShippedAt = DateTime.Parse("2021-07-14"),
                    DeliveredAt = DateTime.Parse("2021-07-16")
                },
                new Order
                {
                    Customer = customers[5],
                    OrderDate = DateTime.Parse("2022-08-03"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-08-04")
                },
                new Order
                {
                    Customer = customers[5],
                    OrderDate = DateTime.Parse("2021-10-20"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[29],
                    OrderDate = DateTime.Parse("2022-11-10"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-11-11"),
                    ShippedAt = DateTime.Parse("2022-11-12")
                },
                new Order
                {
                    Customer = customers[3],
                    OrderDate = DateTime.Parse("2022-03-30"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-03-31")
                },
                new Order
                {
                    Customer = customers[6],
                    OrderDate = DateTime.Parse("2022-08-04"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-08-05"),
                    ShippedAt = DateTime.Parse("2022-08-06"),
                    DeliveredAt = DateTime.Parse("2022-08-08")
                },
                new Order
                {
                    Customer = customers[9],
                    OrderDate = DateTime.Parse("2022-05-29"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-05-30")
                },
                new Order
                {
                    Customer = customers[47],
                    OrderDate = DateTime.Parse("2023-02-25"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2023-02-26")
                },
                new Order
                {
                    Customer = customers[13],
                    OrderDate = DateTime.Parse("2022-08-15"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[40],
                    OrderDate = DateTime.Parse("2022-02-22"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-02-23"),
                    ShippedAt = DateTime.Parse("2022-02-24")
                },
                new Order
                {
                    Customer = customers[3],
                    OrderDate = DateTime.Parse("2021-12-20"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2021-12-21")
                },
                new Order
                {
                    Customer = customers[38],
                    OrderDate = DateTime.Parse("2022-06-20"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-06-21"),
                    ShippedAt = DateTime.Parse("2022-06-22")
                },
                new Order
                {
                    Customer = customers[8],
                    OrderDate = DateTime.Parse("2022-07-05"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-07-06")
                },
                new Order
                {
                    Customer = customers[38],
                    OrderDate = DateTime.Parse("2021-02-02"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2021-02-03")
                },
                new Order
                {
                    Customer = customers[37],
                    OrderDate = DateTime.Parse("2021-03-21"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-03-22"),
                    ShippedAt = DateTime.Parse("2021-03-23")
                },
                new Order
                {
                    Customer = customers[14],
                    OrderDate = DateTime.Parse("2022-04-14"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-04-15"),
                    ShippedAt = DateTime.Parse("2022-04-16"),
                    DeliveredAt = DateTime.Parse("2022-04-18")
                },
                new Order
                {
                    Customer = customers[32],
                    OrderDate = DateTime.Parse("2022-04-02"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[34],
                    OrderDate = DateTime.Parse("2022-06-21"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-06-22"),
                    ShippedAt = DateTime.Parse("2022-06-23"),
                    DeliveredAt = DateTime.Parse("2022-06-25")
                },
                new Order
                {
                    Customer = customers[24],
                    OrderDate = DateTime.Parse("2021-10-27"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[29],
                    OrderDate = DateTime.Parse("2021-04-06"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-04-07"),
                    ShippedAt = DateTime.Parse("2021-04-08")
                },
                new Order
                {
                    Customer = customers[27],
                    OrderDate = DateTime.Parse("2022-01-24"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-01-25"),
                    ShippedAt = DateTime.Parse("2022-01-26")
                },
                new Order
                {
                    Customer = customers[40],
                    OrderDate = DateTime.Parse("2021-04-03"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[24],
                    OrderDate = DateTime.Parse("2021-12-31"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[4],
                    OrderDate = DateTime.Parse("2022-11-09"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-11-10")
                },
                new Order
                {
                    Customer = customers[18],
                    OrderDate = DateTime.Parse("2023-02-10"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[22],
                    OrderDate = DateTime.Parse("2022-02-12"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-02-13")
                },
                new Order
                {
                    Customer = customers[7],
                    OrderDate = DateTime.Parse("2022-07-05"),
                    Status = OrderStatus.Processing,
                    PaidAt = DateTime.Parse("2022-07-06")
                },
                new Order
                {
                    Customer = customers[32],
                    OrderDate = DateTime.Parse("2021-01-23"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[1],
                    OrderDate = DateTime.Parse("2022-08-06"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[42],
                    OrderDate = DateTime.Parse("2022-02-28"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2022-03-01"),
                    ShippedAt = DateTime.Parse("2022-03-02"),
                    DeliveredAt = DateTime.Parse("2022-03-04")
                },
                new Order
                {
                    Customer = customers[14],
                    OrderDate = DateTime.Parse("2021-08-22"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[35],
                    OrderDate = DateTime.Parse("2022-10-13"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[7],
                    OrderDate = DateTime.Parse("2022-12-25"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2022-12-26"),
                    ShippedAt = DateTime.Parse("2022-12-27")
                },
                new Order
                {
                    Customer = customers[45],
                    OrderDate = DateTime.Parse("2021-09-07"),
                    Status = OrderStatus.Shipped,
                    PaidAt = DateTime.Parse("2021-09-08"),
                    ShippedAt = DateTime.Parse("2021-09-09")
                },
                new Order
                {
                    Customer = customers[33],
                    OrderDate = DateTime.Parse("2021-08-09"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[38],
                    OrderDate = DateTime.Parse("2021-10-24"),
                    Status = OrderStatus.Delivered,
                    PaidAt = DateTime.Parse("2021-10-25"),
                    ShippedAt = DateTime.Parse("2021-10-26"),
                    DeliveredAt = DateTime.Parse("2021-10-28")
                },
                new Order
                {
                    Customer = customers[21],
                    OrderDate = DateTime.Parse("2021-11-14"),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Customer = customers[30],
                    OrderDate = DateTime.Parse("2022-11-09"),
                    Status = OrderStatus.Pending
                },
            };
            context.Orders.AddRange(orders);
            #endregion

            #region Database Creation Products          
            var products = new Product[]
            {
                new Product
                {
                    Name = "Matrix Code Rain Projector",
                    Description = "Een item uit de wereld van The Matrix: Matrix Code Rain Projector",
                    Price = 48.44m,
                    StockQuantity = 13,
                    ImageUrl = "img/matrix_code_rain_projector.png",
                    CreatedAt = DateTime.Parse("2025-01-24"),
                    SalePrice = 41.17m,
                    SaleStartDate = DateTime.Parse("2025-06-02"),
                    SaleEndDate = DateTime.Parse("2025-07-29")
                },
                new Product
                {
                    Name = "Red Pill",
                    Description = "Een item uit de wereld van The Matrix: Red Pill",
                    Price = 42.65m,
                    StockQuantity = 5,
                    ImageUrl = "img/red_pill.png",
                    CreatedAt = DateTime.Parse("2024-09-02"),
                    SalePrice = 36.25m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-07-22")
                },
                new Product
                {
                    Name = "Blue Pill",
                    Description = "Een item uit de wereld van The Matrix: Blue Pill",
                    Price = 35.85m,
                    StockQuantity = 3,
                    ImageUrl = "img/blue_pill.png",
                    CreatedAt = DateTime.Parse("2025-01-16")
                },
                new Product
                {
                    Name = "Construct Training Program",
                    Description = "Een item uit de wereld van The Matrix: Construct Training Program",
                    Price = 60.05m,
                    StockQuantity = 14,
                    ImageUrl = "img/construct_training_program.png",
                    CreatedAt = DateTime.Parse("2025-02-13"),
                    SalePrice = 51.04m,
                    SaleStartDate = DateTime.Parse("2025-05-29"),
                    SaleEndDate = DateTime.Parse("2025-07-27")
                },
                new Product
                {
                    Name = "Sentinel Drone",
                    Description = "Een item uit de wereld van The Matrix: Sentinel Drone",
                    Price = 133.16m,
                    StockQuantity = 3,
                    ImageUrl = "img/sentinel_drone.png",
                    CreatedAt = DateTime.Parse("2024-11-02")
                },
                new Product
                {
                    Name = "Zion Defense Turret",
                    Description = "Een item uit de wereld van The Matrix: Zion Defense Turret",
                    Price = 109.3m,
                    StockQuantity = 9,
                    ImageUrl = "img/zion_defense_turret.png",
                    CreatedAt = DateTime.Parse("2025-04-23"),
                    SalePrice = 92.91m,
                    SaleStartDate = DateTime.Parse("2025-05-28"),
                    SaleEndDate = DateTime.Parse("2025-06-12")
                },
                new Product
                {
                    Name = "Hovercraft Manual",
                    Description = "Een item uit de wereld van The Matrix: Hovercraft Manual",
                    Price = 38.6m,
                    StockQuantity = 23,
                    ImageUrl = "img/hovercraft_manual.png",
                    CreatedAt = DateTime.Parse("2024-09-25"),
                    SalePrice = 32.81m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-06-15")
                },
                new Product
                {
                    Name = "Matrix VR Headset",
                    Description = "Een item uit de wereld van The Matrix: Matrix VR Headset",
                    Price = 144.6m,
                    StockQuantity = 11,
                    ImageUrl = "img/matrix_vr_headset.png",
                    CreatedAt = DateTime.Parse("2024-08-04")
                },
                new Product
                {
                    Name = "Operator's Console",
                    Description = "Een item uit de wereld van The Matrix: Operator's Console",
                    Price = 66.61m,
                    StockQuantity = 24,
                    ImageUrl = "img/operators_console.png",
                    CreatedAt = DateTime.Parse("2024-11-17"),
                    SalePrice = 56.62m,
                    SaleStartDate = DateTime.Parse("2025-06-04"),
                    SaleEndDate = DateTime.Parse("2025-08-02")
                },
                new Product
                {
                    Name = "Residual Self Image Mirror",
                    Description = "Een item uit de wereld van The Matrix: Residual Self Image Mirror",
                    Price = 40.05m,
                    StockQuantity = 11,
                    ImageUrl = "img/residual_self_image_mirror.png",
                    CreatedAt = DateTime.Parse("2024-09-01"),
                    SalePrice = 34.04m,
                    SaleStartDate = DateTime.Parse("2025-05-27"),
                    SaleEndDate = DateTime.Parse("2025-07-13")
                },
                new Product
                {
                    Name = "Matrix Sunglasses",
                    Description = "Een item uit de wereld van The Matrix: Matrix Sunglasses",
                    Price = 78.98m,
                    StockQuantity = 49,
                    ImageUrl = "img/matrix_sunglasses.png",
                    CreatedAt = DateTime.Parse("2024-10-17"),
                    SalePrice = 67.13m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-06-13")
                },
                new Product
                {
                    Name = "Zion Resistance Patch",
                    Description = "Een item uit de wereld van The Matrix: Zion Resistance Patch",
                    Price = 129.52m,
                    StockQuantity = 32,
                    ImageUrl = "img/zion_resistance_patch.png",
                    CreatedAt = DateTime.Parse("2025-03-17")
                },
                new Product
                {
                    Name = "Trench Coat - Neo Edition",
                    Description = "Een item uit de wereld van The Matrix: Trench Coat - Neo Edition",
                    Price = 92.83m,
                    StockQuantity = 6,
                    ImageUrl = "img/trench_coat__neo_edition.png",
                    CreatedAt = DateTime.Parse("2025-03-09"),
                    SalePrice = 78.91m,
                    SaleStartDate = DateTime.Parse("2025-05-29"),
                    SaleEndDate = DateTime.Parse("2025-06-30")
                },
                new Product
                {
                    Name = "Dojo Training Disk",
                    Description = "Een item uit de wereld van The Matrix: Dojo Training Disk",
                    Price = 156.23m,
                    StockQuantity = 10,
                    ImageUrl = "img/dojo_training_disk.png",
                    CreatedAt = DateTime.Parse("2024-11-02"),
                    SalePrice = 132.8m,
                    SaleStartDate = DateTime.Parse("2025-06-03"),
                    SaleEndDate = DateTime.Parse("2025-07-22")
                },
                new Product
                {
                    Name = "Bullet Time Camera Rig",
                    Description = "Een item uit de wereld van The Matrix: Bullet Time Camera Rig",
                    Price = 67.11m,
                    StockQuantity = 41,
                    ImageUrl = "img/bullet_time_camera_rig.png",
                    CreatedAt = DateTime.Parse("2024-06-26")
                },
                new Product
                {
                    Name = "Matrix Door Key",
                    Description = "Een item uit de wereld van The Matrix: Matrix Door Key",
                    Price = 30.48m,
                    StockQuantity = 33,
                    ImageUrl = "img/matrix_door_key.png",
                    CreatedAt = DateTime.Parse("2024-06-10")
                },
                new Product
                {
                    Name = "Oracle's Cookie Jar",
                    Description = "Een item uit de wereld van The Matrix: Oracle's Cookie Jar",
                    Price = 56.18m,
                    StockQuantity = 11,
                    ImageUrl = "img/oracles_cookie_jar.png",
                    CreatedAt = DateTime.Parse("2025-05-12")
                },
                new Product
                {
                    Name = "Morpheus' Katana",
                    Description = "Een item uit de wereld van The Matrix: Morpheus' Katana",
                    Price = 135.73m,
                    StockQuantity = 10,
                    ImageUrl = "img/morpheus_katana.png",
                    CreatedAt = DateTime.Parse("2024-11-10"),
                    SalePrice = 115.37m,
                    SaleStartDate = DateTime.Parse("2025-05-29"),
                    SaleEndDate = DateTime.Parse("2025-07-01")
                },
                new Product
                {
                    Name = "Trinity's Motorcycle Helmet",
                    Description = "Een item uit de wereld van The Matrix: Trinity's Motorcycle Helmet",
                    Price = 54.07m,
                    StockQuantity = 30,
                    ImageUrl = "img/trinitys_motorcycle_helmet.png",
                    CreatedAt = DateTime.Parse("2024-08-04")
                },
                new Product
                {
                    Name = "Matrix Reloaded Poster",
                    Description = "Een item uit de wereld van The Matrix: Matrix Reloaded Poster",
                    Price = 133.76m,
                    StockQuantity = 7,
                    ImageUrl = "img/matrix_reloaded_poster.png",
                    CreatedAt = DateTime.Parse("2025-02-24"),
                    SalePrice = 113.7m,
                    SaleStartDate = DateTime.Parse("2025-06-03"),
                    SaleEndDate = DateTime.Parse("2025-06-22")
                },
                new Product
                {
                    Name = "Keymaker's Ring",
                    Description = "Een item uit de wereld van The Matrix: Keymaker's Ring",
                    Price = 124.57m,
                    StockQuantity = 42,
                    ImageUrl = "img/keymakers_ring.png",
                    CreatedAt = DateTime.Parse("2024-07-24"),
                    SalePrice = 105.88m,
                    SaleStartDate = DateTime.Parse("2025-06-02"),
                    SaleEndDate = DateTime.Parse("2025-07-16")
                },
                new Product
                {
                    Name = "Architect's Chair",
                    Description = "Een item uit de wereld van The Matrix: Architect's Chair",
                    Price = 126.82m,
                    StockQuantity = 50,
                    ImageUrl = "img/architects_chair.png",
                    CreatedAt = DateTime.Parse("2024-10-19"),
                    SalePrice = 107.8m,
                    SaleStartDate = DateTime.Parse("2025-06-05"),
                    SaleEndDate = DateTime.Parse("2025-07-27")
                },
                new Product
                {
                    Name = "Matrix Decryption Drive",
                    Description = "Een item uit de wereld van The Matrix: Matrix Decryption Drive",
                    Price = 110.87m,
                    StockQuantity = 17,
                    ImageUrl = "img/matrix_decryption_drive.png",
                    CreatedAt = DateTime.Parse("2025-05-07")
                },
                new Product
                {
                    Name = "Holographic Map of Zion",
                    Description = "Een item uit de wereld van The Matrix: Holographic Map of Zion",
                    Price = 152.9m,
                    StockQuantity = 13,
                    ImageUrl = "img/holographic_map_of_zion.png",
                    CreatedAt = DateTime.Parse("2025-06-03"),
                    SalePrice = 129.97m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-07-14")
                },
                new Product
                {
                    Name = "Matrix Philosophy Book",
                    Description = "Een item uit de wereld van The Matrix: Matrix Philosophy Book",
                    Price = 133.03m,
                    StockQuantity = 40,
                    ImageUrl = "img/matrix_philosophy_book.png",
                    CreatedAt = DateTime.Parse("2024-10-08")
                },
                new Product
                {
                    Name = "Green Code Lamp",
                    Description = "Een item uit de wereld van The Matrix: Green Code Lamp",
                    Price = 48.82m,
                    StockQuantity = 42,
                    ImageUrl = "img/green_code_lamp.png",
                    CreatedAt = DateTime.Parse("2025-03-27"),
                    SalePrice = 41.5m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-07-02")
                },
                new Product
                {
                    Name = "Digital Construct Console",
                    Description = "Een item uit de wereld van The Matrix: Digital Construct Console",
                    Price = 134.23m,
                    StockQuantity = 3,
                    ImageUrl = "img/digital_construct_console.png",
                    CreatedAt = DateTime.Parse("2025-04-16"),
                    SalePrice = 114.1m,
                    SaleStartDate = DateTime.Parse("2025-05-28"),
                    SaleEndDate = DateTime.Parse("2025-07-25")
                },
                new Product
                {
                    Name = "Zion Energy Core",
                    Description = "Een item uit de wereld van The Matrix: Zion Energy Core",
                    Price = 75.31m,
                    StockQuantity = 3,
                    ImageUrl = "img/zion_energy_core.png",
                    CreatedAt = DateTime.Parse("2025-05-27"),
                    SalePrice = 64.01m,
                    SaleStartDate = DateTime.Parse("2025-06-03"),
                    SaleEndDate = DateTime.Parse("2025-07-30")
                },
                new Product
                {
                    Name = "Sentinel Claw Replica",
                    Description = "Een item uit de wereld van The Matrix: Sentinel Claw Replica",
                    Price = 87.31m,
                    StockQuantity = 23,
                    ImageUrl = "img/sentinel_claw_replica.png",
                    CreatedAt = DateTime.Parse("2024-06-28")
                },
                new Product
                {
                    Name = "Neo's Replica Boots",
                    Description = "Een item uit de wereld van The Matrix: Neo's Replica Boots",
                    Price = 102.4m,
                    StockQuantity = 49,
                    ImageUrl = "img/neos_replica_boots.png",
                    CreatedAt = DateTime.Parse("2025-04-18"),
                    SalePrice = 87.04m,
                    SaleStartDate = DateTime.Parse("2025-06-01"),
                    SaleEndDate = DateTime.Parse("2025-07-11")
                },
                new Product
                {
                    Name = "Trinity's Gloves",
                    Description = "Een item uit de wereld van The Matrix: Trinity's Gloves",
                    Price = 83.44m,
                    StockQuantity = 27,
                    ImageUrl = "img/trinitys_gloves.png",
                    CreatedAt = DateTime.Parse("2024-12-31"),
                    SalePrice = 70.92m,
                    SaleStartDate = DateTime.Parse("2025-05-28"),
                    SaleEndDate = DateTime.Parse("2025-06-09")
                },
                new Product
                {
                    Name = "Matrix Code Blanket",
                    Description = "Een item uit de wereld van The Matrix: Matrix Code Blanket",
                    Price = 58.4m,
                    StockQuantity = 39,
                    ImageUrl = "img/matrix_code_blanket.png",
                    CreatedAt = DateTime.Parse("2025-01-13"),
                    SalePrice = 49.64m,
                    SaleStartDate = DateTime.Parse("2025-06-05"),
                    SaleEndDate = DateTime.Parse("2025-07-31")
                },
                new Product
                {
                    Name = "Jack-In Interface Cable",
                    Description = "Een item uit de wereld van The Matrix: Jack-In Interface Cable",
                    Price = 54.15m,
                    StockQuantity = 17,
                    ImageUrl = "img/jackin_interface_cable.png",
                    CreatedAt = DateTime.Parse("2025-04-13"),
                    SalePrice = 46.03m,
                    SaleStartDate = DateTime.Parse("2025-05-27"),
                    SaleEndDate = DateTime.Parse("2025-06-24")
                },
                new Product
                {
                    Name = "Red Pill Coffee Mug",
                    Description = "Een item uit de wereld van The Matrix: Red Pill Coffee Mug",
                    Price = 40.12m,
                    StockQuantity = 50,
                    ImageUrl = "img/red_pill_coffee_mug.png",
                    CreatedAt = DateTime.Parse("2025-03-03")
                },
                new Product
                {
                    Name = "Hovercraft Engine Part",
                    Description = "Een item uit de wereld van The Matrix: Hovercraft Engine Part",
                    Price = 20.66m,
                    StockQuantity = 28,
                    ImageUrl = "img/hovercraft_engine_part.png",
                    CreatedAt = DateTime.Parse("2024-08-24"),
                    SalePrice = 17.56m,
                    SaleStartDate = DateTime.Parse("2025-06-04"),
                    SaleEndDate = DateTime.Parse("2025-07-04")
                },
                new Product
                {
                    Name = "Zion Map Puzzle",
                    Description = "Een item uit de wereld van The Matrix: Zion Map Puzzle",
                    Price = 100.18m,
                    StockQuantity = 32,
                    ImageUrl = "img/zion_map_puzzle.png",
                    CreatedAt = DateTime.Parse("2025-05-09")
                },
                new Product
                {
                    Name = "Bullet Time Simulation Kit",
                    Description = "Een item uit de wereld van The Matrix: Bullet Time Simulation Kit",
                    Price = 145.78m,
                    StockQuantity = 44,
                    ImageUrl = "img/bullet_time_simulation_kit.png",
                    CreatedAt = DateTime.Parse("2025-01-29"),
                    SalePrice = 123.91m,
                    SaleStartDate = DateTime.Parse("2025-05-28"),
                    SaleEndDate = DateTime.Parse("2025-07-07")
                },
                new Product
                {
                    Name = "Construct Scenario Loader",
                    Description = "Een item uit de wereld van The Matrix: Construct Scenario Loader",
                    Price = 133.26m,
                    StockQuantity = 47,
                    ImageUrl = "img/construct_scenario_loader.png",
                    CreatedAt = DateTime.Parse("2025-04-03"),
                    SalePrice = 113.27m,
                    SaleStartDate = DateTime.Parse("2025-06-03"),
                    SaleEndDate = DateTime.Parse("2025-07-10")
                },
                new Product
                {
                    Name = "Oracle’s Prophecy Scroll",
                    Description = "Een item uit de wereld van The Matrix: Oracle’s Prophecy Scroll",
                    Price = 120.12m,
                    StockQuantity = 11,
                    ImageUrl = "img/oracles_prophecy_scroll.png",
                    CreatedAt = DateTime.Parse("2024-09-15"),
                    SalePrice = 102.1m,
                    SaleStartDate = DateTime.Parse("2025-06-01"),
                    SaleEndDate = DateTime.Parse("2025-07-19")
                },
                new Product
                {
                    Name = "Training Simulation USB",
                    Description = "Een item uit de wereld van The Matrix: Training Simulation USB",
                    Price = 45.69m,
                    StockQuantity = 3,
                    ImageUrl = "img/training_simulation_usb.png",
                    CreatedAt = DateTime.Parse("2025-03-24"),
                    SalePrice = 38.84m,
                    SaleStartDate = DateTime.Parse("2025-06-03"),
                    SaleEndDate = DateTime.Parse("2025-06-28")
                },
                new Product
                {
                    Name = "Matrix-themed Mouse Pad",
                    Description = "Een item uit de wereld van The Matrix: Matrix-themed Mouse Pad",
                    Price = 60.13m,
                    StockQuantity = 39,
                    ImageUrl = "img/matrixthemed_mouse_pad.png",
                    CreatedAt = DateTime.Parse("2024-08-22")
                },
                new Product
                {
                    Name = "Zion Communication Beacon",
                    Description = "Een item uit de wereld van The Matrix: Zion Communication Beacon",
                    Price = 154.98m,
                    StockQuantity = 11,
                    ImageUrl = "img/zion_communication_beacon.png",
                    CreatedAt = DateTime.Parse("2024-07-25"),
                    SalePrice = 131.73m,
                    SaleStartDate = DateTime.Parse("2025-05-31"),
                    SaleEndDate = DateTime.Parse("2025-07-18")
                },
                new Product
                {
                    Name = "Agent Smith’s Tie",
                    Description = "Een item uit de wereld van The Matrix: Agent Smith’s Tie",
                    Price = 152.49m,
                    StockQuantity = 7,
                    ImageUrl = "img/agent_smiths_tie.png",
                    CreatedAt = DateTime.Parse("2025-03-20"),
                    SalePrice = 129.62m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-06-19")
                },
                new Product
                {
                    Name = "Matrix Combat Manual",
                    Description = "Een item uit de wereld van The Matrix: Matrix Combat Manual",
                    Price = 145.59m,
                    StockQuantity = 4,
                    ImageUrl = "img/matrix_combat_manual.png",
                    CreatedAt = DateTime.Parse("2025-03-25")
                },
                new Product
                {
                    Name = "Hovercraft Floor Panel",
                    Description = "Een item uit de wereld van The Matrix: Hovercraft Floor Panel",
                    Price = 120.82m,
                    StockQuantity = 9,
                    ImageUrl = "img/hovercraft_floor_panel.png",
                    CreatedAt = DateTime.Parse("2024-07-12")
                },
                new Product
                {
                    Name = "Matrix Reloaded Blu-ray",
                    Description = "Een item uit de wereld van The Matrix: Matrix Reloaded Blu-ray",
                    Price = 123.89m,
                    StockQuantity = 40,
                    ImageUrl = "img/matrix_reloaded_bluray.png",
                    CreatedAt = DateTime.Parse("2025-05-13")
                },
                new Product
                {
                    Name = "Matrix Art Book",
                    Description = "Een item uit de wereld van The Matrix: Matrix Art Book",
                    Price = 156.63m,
                    StockQuantity = 13,
                    ImageUrl = "img/matrix_art_book.png",
                    CreatedAt = DateTime.Parse("2024-07-11"),
                    SalePrice = 133.14m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-06-30")
                },
                new Product
                {
                    Name = "Neo Funko Pop",
                    Description = "Een item uit de wereld van The Matrix: Neo Funko Pop",
                    Price = 38.39m,
                    StockQuantity = 47,
                    ImageUrl = "img/neo_funko_pop.png",
                    CreatedAt = DateTime.Parse("2025-02-19"),
                    SalePrice = 32.63m,
                    SaleStartDate = DateTime.Parse("2025-05-30"),
                    SaleEndDate = DateTime.Parse("2025-07-14")
                },
                new Product
                {
                    Name = "Zion Defense Blueprint",
                    Description = "Een item uit de wereld van The Matrix: Zion Defense Blueprint",
                    Price = 154.92m,
                    StockQuantity = 8,
                    ImageUrl = "img/zion_defense_blueprint.png",
                    CreatedAt = DateTime.Parse("2024-08-14"),
                    SalePrice = 131.68m,
                    SaleStartDate = DateTime.Parse("2025-05-28"),
                    SaleEndDate = DateTime.Parse("2025-06-30")
                },
                new Product
                {
                    Name = "Encrypted Matrix File Drive",
                    Description = "Een item uit de wereld van The Matrix: Encrypted Matrix File Drive",
                    Price = 144.54m,
                    StockQuantity = 33,
                    ImageUrl = "img/encrypted_matrix_file_drive.png",
                    CreatedAt = DateTime.Parse("2024-06-28")
                },
            };
            context.Products.AddRange(products);
            #endregion

            #region Database Creation Parts
            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);
            #endregion

            #region Product - Parts relationship
            products[0].Parts.Add(parts[0]);
            products[0].Parts.Add(parts[1]);
            products[1].Parts.Add(parts[1]);
            products[1].Parts.Add(parts[2]);
            products[2].Parts.Add(parts[3]);
            #endregion

            #region Orders - Product relationship
            orders[0].Products = new List<Product> { products[0], products[1], products[2], products[4], products[30], products[8] };
            orders[1].Products = new List<Product> { products[2] };
            orders[2].Products = new List<Product> { products[3], products[4] };
            orders[3].Products = new List<Product> { products[5] };
            orders[4].Products = new List<Product> { products[6], products[7], products[8] };
            orders[5].Products = new List<Product> { products[9] };
            orders[6].Products = new List<Product> { products[10], products[11] };
            orders[7].Products = new List<Product> { products[12] };
            orders[8].Products = new List<Product> { products[13], products[14] };
            orders[9].Products = new List<Product> { products[15] };
            orders[10].Products = new List<Product> { products[16], products[17] };
            orders[11].Products = new List<Product> { products[18] };
            orders[12].Products = new List<Product> { products[19], products[20] };
            orders[13].Products = new List<Product> { products[21] };
            orders[14].Products = new List<Product> { products[22], products[23] };
            orders[15].Products = new List<Product> { products[24] };
            orders[16].Products = new List<Product> { products[25], products[26] };
            orders[17].Products = new List<Product> { products[27] };
            orders[18].Products = new List<Product> { products[28], products[29] };
            orders[19].Products = new List<Product> { products[30] };
            orders[20].Products = new List<Product> { products[31], products[32] };
            orders[21].Products = new List<Product> { products[33] };
            orders[22].Products = new List<Product> { products[34], products[35] };
            orders[23].Products = new List<Product> { products[36] };
            orders[24].Products = new List<Product> { products[37], products[38] };
            orders[25].Products = new List<Product> { products[39] };
            orders[26].Products = new List<Product> { products[40], products[41] };
            orders[27].Products = new List<Product> { products[42] };
            orders[28].Products = new List<Product> { products[43], products[44] };
            orders[29].Products = new List<Product> { products[45] };
            orders[30].Products = new List<Product> { products[46], products[47] };
            orders[31].Products = new List<Product> { products[48] };
            orders[32].Products = new List<Product> { products[49], products[48] };
            orders[33].Products = new List<Product> { products[1] };
            orders[34].Products = new List<Product> { products[1], products[2] };
            orders[35].Products = new List<Product> { products[1] };
            orders[36].Products = new List<Product> { products[1], products[2] };
            orders[37].Products = new List<Product> { products[1] };
            orders[38].Products = new List<Product> { products[48], products[30] };
            orders[39].Products = new List<Product> { products[0] };
            orders[40].Products = new List<Product> { products[1], products[2] };
            orders[41].Products = new List<Product> { products[3] };
            orders[42].Products = new List<Product> { products[4], products[5] };
            orders[43].Products = new List<Product> { products[6] };
            orders[44].Products = new List<Product> { products[7], products[8] };
            orders[45].Products = new List<Product> { products[9] };
            orders[46].Products = new List<Product> { products[10], products[11] };
            orders[47].Products = new List<Product> { products[12] };
            orders[48].Products = new List<Product> { products[13], products[14] };
            orders[49].Products = new List<Product> { products[15] };
            #endregion

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}