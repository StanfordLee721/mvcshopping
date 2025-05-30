using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvcshopping.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", maxLength: 250, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", maxLength: 250, nullable: false),
                    zipcode = table.Column<int>(type: "int", nullable: false),
                    UserNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Birthday", "CodeNo", "CompID", "CompName", "CompTel", "ContactAddress", "ContactEmail", "ContactTel", "DeptName", "EngName", "FacebookID", "FirstName", "GenderCode", "InstagramID", "LastName", "Latitude", "LineID", "LinkedInID", "Longitude", "Remark", "SortNo", "StreetAddress", "TitleName", "TwitterID", "UserNo", "zipcode" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A001", "C001", "ABC Corp.", "02-12345678", null, "user1@gmail.com", "0912345678", "IT", "John Doe", null, "John", "M", null, "Doe", 25.0330m, null, null, 121.5654m, null, "001", "台北市信義區", "Manager", null, "user1", 110 },
                    { 2, new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "A002", "C002", "XYZ Inc.", "02-87654321", null, "user2@gmail.com", "0987654321", "HR", "Jane Smith", null, "Jane", "F", null, "Smith", 24.9394m, null, null, 121.3662m, null, "002", "新北市三峽區", "Director", null, "user2", 237 },
                    { 3, new DateTime(1995, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "A003", "C003", "LMN Ltd.", "04-23456789", null, "user3@gmail.com", "0934567890", "Finance", "Alice Johnson", null, "Alice", "F", null, "Johnson", 24.1477m, null, null, 120.6736m, null, "003", "台中市南區", "Analyst", null, "user3", 402 },
                    { 4, new DateTime(1988, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A004", "C004", "DEF Co.", "07-3456789", null, "user4@gmail.com", "0912345678", "Marketing", "Bob Brown", null, "Bob", "M", null, "Brown", 22.6163m, null, null, 120.3014m, null, "004", "高雄市前鎮區", "Executive", null, "user4", 806 },
                    { 5, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A005", "C005", "GHI Group", "06-4567890", null, "user5@gmail.com", "0923456789", "Sales", "Charlie Davis", null, "Charlie", "M", null, "Davis", 22.9992m, null, null, 120.2270m, null, "005", "台南市東區", "Salesperson", null, "user5", 701 },
                    { 6, new DateTime(1993, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A006", "C006", "JKL Enterprises", "02-56789012", null, "user6@gmail.com", "0934567890", "Operations", "David Wilson", null, "David", "M", null, "Wilson", 25.1302m, null, null, 121.7405m, null, "006", "基隆市仁愛區", "Supervisor", null, "user6", 200 },
                    { 7, new DateTime(1994, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A007", "C007", "MNO Solutions", "03-67890123", null, "user7@gmail.com", "0912345678", "IT Support", "Eve Garcia", null, "Eve", "F", null, "Garcia", 24.8138m, null, null, 120.9675m, null, "007", "新竹市東區", "Technician", null, "user7", 300 },
                    { 8, new DateTime(1990, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A008", "C008", "PQR Technologies", "03-78901234", null, "user8@gmail.com", "0923456789", "Research", "Frank Martinez", null, "Frank", "M", null, "Martinez", 24.9524m, null, null, 121.2250m, null, "008", "桃園市中壢區", "Scientist", null, "user8", 320 },
                    { 9, new DateTime(1995, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "A009", "C009", "STU Innovations", "05-8901234", null, "user9@gmail.com", "0934567890", "Design", "Grace Hernandez", null, "Grace", "F", null, "Hernandez", 23.4822m, null, null, 120.4475m, null, "009", "嘉義市西區", "Designer", null, "user9", 600 },
                    { 10, new DateTime(1992, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A010", "C010", "VWX Holdings", "08-90123456", null, "user10@gmail.com", "0912345678", "Legal", "Henry Lopez", null, "Henry", "M", null, "Lopez", 22.4563m, null, null, 120.4555m, null, "010", "屏東市東港區", "Lawyer", null, "user10", 928 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "電腦周邊" },
                    { 2, "手機周邊" },
                    { 3, "家電" },
                    { 4, "電腦" },
                    { 5, "手機" },
                    { 6, "平板" },
                    { 7, "相機" },
                    { 8, "耳機" },
                    { 9, "音響" },
                    { 10, "電視" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AddressId", "Description", "OrderDate", "OrderQuantity", "Price", "ProductId", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "請3日內出貨", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1000m, 8, "藍芽耳機" },
                    { 2, 2, "黑色滑鼠", new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 299m, 1, "滑鼠" },
                    { 3, 3, "白色滑鼠", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1800m, 3, "藍芽滑鼠" },
                    { 4, 1, "請3日內出貨", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1000m, 8, "藍芽耳機" },
                    { 5, 3, "金色", new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 7, "電競耳機" },
                    { 6, 3, "黑色", new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 7, "電競耳機" },
                    { 7, 4, "白色", new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 7, "電競耳機" },
                    { 8, 5, "藍色", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1000m, 7, "藍芽音響" },
                    { 9, 6, "紅色", new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 7, "電競耳機" },
                    { 10, 7, "黑色", new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 6, "電競鍵盤" },
                    { 11, 8, "白色", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 6, "電競鍵盤" },
                    { 12, 9, "紅色", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, 6, "電競鍵盤" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Address", "CategoryId", "Description", "ImageUrl", "Price", "ProductName", "ProductNo", "RegistrationDate", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "台北市", 1, "有線滑鼠，低價位", "https://example.com/image1.jpg", 299m, "滑鼠", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, "新竹市", 1, "中價位", "https://example.com/image1.jpg", 1220m, "無線滑鼠", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80 },
                    { 3, "台北市", 1, "高價位", "https://example.com/image1.jpg", 1800m, "藍芽滑鼠", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 4, "台北市", 1, "低價位", "https://example.com/image1.jpg", 299m, "有線鍵盤", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 5, "高雄市", 1, "中價位", "https://example.com/image1.jpg", 1000m, "無線鍵盤", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { 6, "臺中市", 1, "高價位", "https://example.com/image1.jpg", 3000m, "電競鍵盤", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 7, "臺中市", 1, "高價位", "https://example.com/image1.jpg", 3000m, "電競耳機", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 8, "高雄市", 1, "中價位", "https://example.com/image1.jpg", 1000m, "藍芽耳機", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { 9, "台北市", 1, "低價位", "https://example.com/image1.jpg", 299m, "有線耳機", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 10, "高雄市", 1, "中價位", "https://example.com/image1.jpg", 1000m, "藍芽音響", 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "FullName", "LastLogin", "Password", "Phone", "RegistrationDate", "UserName" },
                values: new object[,]
                {
                    { 1, null, "admin123@example.com", null, null, "admin123", null, null, "Admin" },
                    { 2, null, "user1@example.com", null, null, "user123", null, null, "user1" },
                    { 3, null, "user2@example.com", null, null, "user123", null, null, "user2" },
                    { 4, null, "user3@example.com", null, null, "user123", null, null, "user3" },
                    { 5, null, "user4@example.com", null, null, "user123", null, null, "user4" },
                    { 6, null, "user5@example.com", null, null, "user123", null, null, "user5" },
                    { 7, null, "user6@example.com", null, null, "user123", null, null, "user6" },
                    { 8, null, "user7@example.com", null, null, "user123", null, null, "user7" },
                    { 9, null, "mis@example.com", null, null, "mis123", null, null, "Mis" },
                    { 10, null, "member@example.com", null, null, "member123", null, null, "Member" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
