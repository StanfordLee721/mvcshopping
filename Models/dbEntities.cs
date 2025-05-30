using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcshopping.Models.Tables;

namespace mvcshopping.Models
{
    public class dbEntities : DbContext
    {
        private readonly IConfiguration Configuration;
        public DbSet<Products>? Products { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Users>? Users { get; set; }

        public dbEntities(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }
        public dbEntities()
        {
        }
        // public dbEntities(DbContextOptions<dbEntities> options) : base(options)
        // {
        // }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection is not configured in appsettings.json");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("ConnectionString 未正確初始化");
                }
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1,
                    ProductNo = "T001",
                    ProductName = "滑鼠",
                    Description = "有線滑鼠，低價位",
                    Price = 299,
                    StockQuantity = 100,
                    Address = "台北市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 2,
                    ProductNo = "T002",
                    ProductName = "無線滑鼠",
                    Description = "中價位",
                    Price = 1220,
                    StockQuantity = 80,
                    Address = "新竹市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 3,
                    ProductNo = "T003",
                    ProductName = "藍芽滑鼠",
                    Description = "高價位",
                    Price = 1800,
                    StockQuantity = 50,
                    Address = "台北市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 4,
                    ProductNo = "T004",
                    ProductName = "有線鍵盤",
                    Description = "低價位",
                    Price = 299,
                    StockQuantity = 100,
                    Address = "台北市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 5,
                    ProductNo = "T005",
                    ProductName = "無線鍵盤",
                    Description = "中價位",
                    Price = 1000,
                    StockQuantity = 200,
                    Address = "高雄市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 6,
                    ProductNo = "T006",
                    ProductName = "電競鍵盤",
                    Description = "高價位",
                    Price = 3000,
                    StockQuantity = 50,
                    Address = "臺中市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 7,
                    ProductNo = "T007",
                    ProductName = "電競耳機",
                    Description = "高價位",
                    Price = 3000,
                    StockQuantity = 50,
                    Address = "臺中市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 8,
                    ProductNo = "T008",
                    ProductName = "藍芽耳機",
                    Description = "中價位",
                    Price = 1000,
                    StockQuantity = 200,
                    Address = "高雄市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 9,
                    ProductNo = "T009",
                    ProductName = "有線耳機",
                    Description = "低價位",
                    Price = 299,
                    StockQuantity = 100,
                    Address = "台北市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                },
                new Products
                {
                    ProductId = 10,
                    ProductNo = "T010",
                    ProductName = "藍芽音響",
                    Description = "中價位",
                    Price = 1000,
                    StockQuantity = 200,
                    Address = "高雄市",
                    ImageUrl = "https://example.com/image1.jpg",
                    CategoryId = 1,
                    RegistrationDate = new DateTime(2025, 1, 1)
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "電腦周邊"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "手機周邊"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "家電"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "電腦"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "手機"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "平板"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "相機"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "耳機"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "音響"
                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "電視"
                }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    UserName = "Admin",
                    Password = "admin123",
                    Email = "admin123@example.com"
                },
                new Users
                {
                    UserId = 2,
                    UserName = "user1",
                    Password = "user123",
                    Email = "user1@example.com"
                },
                new Users
                {
                    UserId = 3,
                    UserName = "user2",
                    Password = "user123",
                    Email = "user2@example.com"
                },
                new Users
                {
                    UserId = 4,
                    UserName = "user3",
                    Password = "user123",
                    Email = "user3@example.com"
                },
                new Users
                {
                    UserId = 5,
                    UserName = "user4",
                    Password = "user123",
                    Email = "user4@example.com"
                },
                new Users
                {
                    UserId = 6,
                    UserName = "user5",
                    Password = "user123",
                    Email = "user5@example.com"
                },
                new Users
                {
                    UserId = 7,
                    UserName = "user6",
                    Password = "user123",
                    Email = "user6@example.com"
                },
                new Users
                {
                    UserId = 8,
                    UserName = "user7",
                    Password = "user123",
                    Email = "user7@example.com"
                },
                new Users
                {
                    UserId = 9,
                    UserName = "Mis",
                    Password = "mis123",
                    Email = "mis@example.com"
                },
                new Users
                {
                    UserId = 10,
                    UserName = "Member",
                    Password = "member123",
                    Email = "member@example.com"
                }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders
                {
                    OrderId = 1,
                    ProductName = "藍芽耳機",
                    Description = "請3日內出貨",
                    Price = 1000,
                    OrderQuantity = 2,
                    AddressId = 1,
                    ProductId = 8,
                    OrderDate = new DateTime(2025, 3, 1)
                },
                new Orders
                {
                    OrderId = 2,
                    ProductName = "滑鼠",
                    Description = "黑色滑鼠",
                    Price = 299,
                    OrderQuantity = 10,
                    AddressId = 2,
                    ProductId = 1,
                    OrderDate = new DateTime(2025, 3, 23)
                },
                new Orders
                {
                    OrderId = 3,
                    ProductName = "藍芽滑鼠",
                    Description = "白色滑鼠",
                    Price = 1800,
                    OrderQuantity = 3,
                    AddressId = 3,
                    ProductId = 3,
                    OrderDate = new DateTime(2025, 4, 1)
                },
                new Orders
                {
                    OrderId = 4,
                    ProductName = "藍芽耳機",
                    Description = "請3日內出貨",
                    Price = 1000,
                    OrderQuantity = 2,
                    AddressId = 1,
                    ProductId = 8,
                    OrderDate = new DateTime(2025, 3, 1)
                },
                new Orders
                {
                    OrderId = 5,
                    ProductName = "電競耳機",
                    Description = "金色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 3,
                    ProductId = 7,
                    OrderDate = new DateTime(2025, 1, 23)
                },
                new Orders
                {
                    OrderId = 6,
                    ProductName = "電競耳機",
                    Description = "黑色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 3,
                    ProductId = 7,
                    OrderDate = new DateTime(2025, 2, 23)
                },
                new Orders
                {
                    OrderId = 7,
                    ProductName = "電競耳機",
                    Description = "白色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 4,
                    ProductId = 7,
                    OrderDate = new DateTime(2025, 3, 23)
                },
                new Orders
                {
                    OrderId = 8,
                    ProductName = "藍芽音響",
                    Description = "藍色",
                    Price = 1000,
                    OrderQuantity = 5,
                    AddressId = 5,
                    ProductId = 7,
                    OrderDate = new DateTime(2024, 12, 20)
                },
                new Orders
                {
                    OrderId = 9,
                    ProductName = "電競耳機",
                    Description = "紅色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 6,
                    ProductId = 7,
                    OrderDate = new DateTime(2025, 1, 23)
                },
                new Orders
                {
                    OrderId = 10,
                    ProductName = "電競鍵盤",
                    Description = "黑色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 7,
                    ProductId = 6,
                    OrderDate = new DateTime(2025, 2, 23)
                },
                new Orders
                {
                    OrderId = 11,
                    ProductName = "電競鍵盤",
                    Description = "白色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 8,
                    ProductId = 6,
                    OrderDate = new DateTime(2025, 2, 1)
                },
                new Orders
                {
                    OrderId = 12,
                    ProductName = "電競鍵盤",
                    Description = "紅色",
                    Price = 3000,
                    OrderQuantity = 1,
                    AddressId = 9,
                    ProductId = 6,
                    OrderDate = new DateTime(2024, 11, 11)
                }

            );
            modelBuilder.Entity<Address>().HasData(
                            new Address
                            {
                                AddressId = 1,
                                StreetAddress = "台北市信義區",
                                SortNo = "001",
                                Latitude = 25.0330m,
                                Longitude = 121.5654m,
                                zipcode = 110,
                                UserNo = "user1",
                                CodeNo = "A001",
                                FirstName = "John",
                                LastName = "Doe",
                                EngName = "John Doe",
                                GenderCode = "M",
                                Birthday = new DateTime(1990, 1, 1),
                                CompName = "ABC Corp.",
                                CompID = "C001",
                                DeptName = "IT",
                                TitleName = "Manager",
                                CompTel = "02-12345678",
                                ContactTel = "0912345678",
                                ContactEmail = "user1@gmail.com"

                            },
                            new Address
                            {
                                AddressId = 2,
                                StreetAddress = "新北市三峽區",
                                SortNo = "002",
                                Latitude = 24.9394m,
                                Longitude = 121.3662m,
                                zipcode = 237,
                                UserNo = "user2",
                                CodeNo = "A002",
                                FirstName = "Jane",
                                LastName = "Smith",
                                EngName = "Jane Smith",
                                GenderCode = "F",
                                Birthday = new DateTime(1992, 2, 2),
                                CompName = "XYZ Inc.",
                                CompID = "C002",
                                DeptName = "HR",
                                TitleName = "Director",
                                CompTel = "02-87654321",
                                ContactTel = "0987654321",
                                ContactEmail = "user2@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 3,
                                StreetAddress = "台中市南區",
                                SortNo = "003",
                                Latitude = 24.1477m,
                                Longitude = 120.6736m,
                                zipcode = 402,
                                UserNo = "user3",
                                CodeNo = "A003",
                                FirstName = "Alice",
                                LastName = "Johnson",
                                EngName = "Alice Johnson",
                                GenderCode = "F",
                                Birthday = new DateTime(1995, 3, 3),
                                CompName = "LMN Ltd.",
                                CompID = "C003",
                                DeptName = "Finance",
                                TitleName = "Analyst",
                                CompTel = "04-23456789",
                                ContactTel = "0934567890",
                                ContactEmail = "user3@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 4,
                                StreetAddress = "高雄市前鎮區",
                                SortNo = "004",
                                Latitude = 22.6163m,
                                Longitude = 120.3014m,
                                zipcode = 806,
                                UserNo = "user4",
                                CodeNo = "A004",
                                FirstName = "Bob",
                                LastName = "Brown",
                                EngName = "Bob Brown",
                                GenderCode = "M",
                                Birthday = new DateTime(1988, 4, 4),
                                CompName = "DEF Co.",
                                CompID = "C004",
                                DeptName = "Marketing",
                                TitleName = "Executive",
                                CompTel = "07-3456789",
                                ContactTel = "0912345678",
                                ContactEmail = "user4@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 5,
                                StreetAddress = "台南市東區",
                                SortNo = "005",
                                Latitude = 22.9992m,
                                Longitude = 120.2270m,
                                zipcode = 701,
                                UserNo = "user5",
                                CodeNo = "A005",
                                FirstName = "Charlie",
                                LastName = "Davis",
                                EngName = "Charlie Davis",
                                GenderCode = "M",
                                Birthday = new DateTime(1991, 5, 5),
                                CompName = "GHI Group",
                                CompID = "C005",
                                DeptName = "Sales",
                                TitleName = "Salesperson",
                                CompTel = "06-4567890",
                                ContactTel = "0923456789",
                                ContactEmail = "user5@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 6,
                                StreetAddress = "基隆市仁愛區",
                                SortNo = "006",
                                Latitude = 25.1302m,
                                Longitude = 121.7405m,
                                zipcode = 200,
                                UserNo = "user6",
                                CodeNo = "A006",
                                FirstName = "David",
                                LastName = "Wilson",
                                EngName = "David Wilson",
                                GenderCode = "M",
                                Birthday = new DateTime(1993, 6, 6),
                                CompName = "JKL Enterprises",
                                CompID = "C006",
                                DeptName = "Operations",
                                TitleName = "Supervisor",
                                CompTel = "02-56789012",
                                ContactTel = "0934567890",
                                ContactEmail = "user6@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 7,
                                StreetAddress = "新竹市東區",
                                SortNo = "007",
                                Latitude = 24.8138m,
                                Longitude = 120.9675m,
                                zipcode = 300,
                                UserNo = "user7",
                                CodeNo = "A007",
                                FirstName = "Eve",
                                LastName = "Garcia",
                                EngName = "Eve Garcia",
                                GenderCode = "F",
                                Birthday = new DateTime(1994, 7, 7),
                                CompName = "MNO Solutions",
                                CompID = "C007",
                                DeptName = "IT Support",
                                TitleName = "Technician",
                                CompTel = "03-67890123",
                                ContactTel = "0912345678",
                                ContactEmail = "user7@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 8,
                                StreetAddress = "桃園市中壢區",
                                SortNo = "008",
                                Latitude = 24.9524m,
                                Longitude = 121.2250m,
                                zipcode = 320,
                                UserNo = "user8",
                                CodeNo = "A008",
                                FirstName = "Frank",
                                LastName = "Martinez",
                                EngName = "Frank Martinez",
                                GenderCode = "M",
                                Birthday = new DateTime(1990, 8, 8),
                                CompName = "PQR Technologies",
                                CompID = "C008",
                                DeptName = "Research",
                                TitleName = "Scientist",
                                CompTel = "03-78901234",
                                ContactTel = "0923456789",
                                ContactEmail = "user8@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 9,
                                StreetAddress = "嘉義市西區",
                                SortNo = "009",
                                Latitude = 23.4822m,
                                Longitude = 120.4475m,
                                zipcode = 600,
                                UserNo = "user9",
                                CodeNo = "A009",
                                FirstName = "Grace",
                                LastName = "Hernandez",
                                EngName = "Grace Hernandez",
                                GenderCode = "F",
                                Birthday = new DateTime(1995, 9, 9),
                                CompName = "STU Innovations",
                                CompID = "C009",
                                DeptName = "Design",
                                TitleName = "Designer",
                                CompTel = "05-8901234",
                                ContactTel = "0934567890",
                                ContactEmail = "user9@gmail.com"
                            },
                            new Address
                            {
                                AddressId = 10,
                                StreetAddress = "屏東市東港區",
                                SortNo = "010",
                                Latitude = 22.4563m,
                                Longitude = 120.4555m,
                                zipcode = 928,
                                UserNo = "user10",
                                CodeNo = "A010",
                                FirstName = "Henry",
                                LastName = "Lopez",
                                EngName = "Henry Lopez",
                                GenderCode = "M",
                                Birthday = new DateTime(1992, 10, 10),
                                CompName = "VWX Holdings",
                                CompID = "C010",
                                DeptName = "Legal",
                                TitleName = "Lawyer",
                                CompTel = "08-90123456",
                                ContactTel = "0912345678",
                                ContactEmail = "user10@gmail.com"
                            }
            );
        }
    }
}