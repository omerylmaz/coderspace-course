using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class total_upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => new { x.Id, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThreeDSStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), null, "User", "USER" },
                    { new Guid("8672057e-cd8e-4f23-b002-f1a2785fe8f3"), null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2d8651fd-3800-48da-a85c-f294282b5180"), 0, "83f229ee-8eb2-4c84-a059-a130b6149e79", "user4@gmail.com", false, "Kerem Aktürkoğlu", false, null, "USER4@GMAIL.COM", "KEREMTURK", "AQAAAAIAAYagAAAAEJqrheVkippD/zxlEJ/zEQ6YaEao8IL0LhZPFGxz+4ZvXbLjF2Q/X7rV13HqayWu5g==", "5554445566", false, null, false, "keremturk" },
                    { new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"), 0, "a39ce119-6fab-4c92-85d9-e75ae579fd30", "user5@gmail.com", false, "Victor Osimhen", false, null, "USER5@GMAIL.COM", "OSIMHEN", "AQAAAAIAAYagAAAAEIjaj8JYQEoj1kqYcJ1zsymEny81BvcbN1LnecUpfE+JzKiMnPpUADAqdLCIdCO/yA==", "5555556677", false, null, false, "osimhen" },
                    { new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), 0, "d50bfa63-40ec-4bbb-8dd3-21df5ce17675", "teacher1@gmail.com", false, "Ahmet Kaya", false, null, "TEACHER1@GMAIL.COM", "AHMETKAYA", "AQAAAAIAAYagAAAAEH19c68RDy+nTUUoASc+28Z/x7W14ZvzWBLqMrCOAOAOHreshJSDM+wTdbAETKr/Fg==", "5556667788", false, null, false, "ahmetkaya" },
                    { new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"), 0, "5bee7a2b-2166-45cf-8164-9bb534ae7070", "user3@gmail.com", false, "Kıvanç Tatlıtuğ", false, null, "USER3@GMAIL.COM", "KIVANCTATLI", "AQAAAAIAAYagAAAAEAQ2MJIdmxppt664W7SYezooWkJZJQyIhLN6h3U+p65TGqT/5GiBILmJuFPOsZrq5Q==", "5553334455", false, null, false, "kivanctatli" },
                    { new Guid("54039b1c-f914-4171-97a8-f78a9c107935"), 0, "e6faf2bd-e33a-4c8c-821c-0fdd0dacdb27", "user2@gmail.com", false, "Okan Buruk", false, null, "USER2@GMAIL.COM", "OKANBURUK", "AQAAAAIAAYagAAAAEPLEPNVded8aR7+7hvpX6ZC9sTNuQFyc1cqSTERtRPDTrWnhadyD0GhG1Z0hcJFZ/Q==", "5552223344", false, null, false, "okanburuk" },
                    { new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"), 0, "7ea26e95-9517-48db-96ba-138e1badeb10", "user1@gmail.com", false, "Ömer Yılmaz", false, null, "USER1@GMAIL.COM", "OMERYILMAZ", "AQAAAAIAAYagAAAAEOJKYJ26u9WYWk09Ox/MkjADfyD7XAy99UKY7juafqkpkyLnvpM7WRbWih3BeRs83A==", "5551112233", false, null, false, "omeryilmaz" },
                    { new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), 0, "d3c6ea43-2902-4a6a-b3aa-87d48819a47c", "teacher2@gmail.com", false, "Fatih Çakıroğlu", false, null, "TEACHER2@GMAIL.COM", "FATIHCAMIR", "AQAAAAIAAYagAAAAEJFgNTraw+MbssmpIp0nnR07TTjJz8IKCeWa4rDgXYgPcbiM2bneIxmxiX67iQdQ/w==", "5557778899", false, null, false, "fatihcakiroglu" },
                    { new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), 0, "ed4c18e1-c5fd-417d-9df6-bde8b27a13ee", "teacher3@gmail.com", false, "Şadi Evren Şeker", false, null, "TEACHER3@GMAIL.COM", "SADIEVRENSEKER", "AQAAAAIAAYagAAAAEPCtcyGULpOFUyDjj9KY1h19vNgCyDB9lLlLRdoYfC0vUn98smch6AHUa4D7zhgIQg==", "5558889900", false, null, false, "sadievrenseker" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2149), "Software" },
                    { new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2175), "Finance" },
                    { new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2173), "Project Management" },
                    { new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2177), "Lifestyle" },
                    { new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2171), "Marketing" },
                    { new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2169), "Design" },
                    { new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2179), "Photography" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), new Guid("2d8651fd-3800-48da-a85c-f294282b5180") },
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8") },
                    { new Guid("8672057e-cd8e-4f23-b002-f1a2785fe8f3"), new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27") },
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), new Guid("54039b1c-f914-4171-97a8-f78a9c107935") },
                    { new Guid("41330934-5681-4660-bfd0-a7c91940073f"), new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("8672057e-cd8e-4f23-b002-f1a2785fe8f3"), new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9") },
                    { new Guid("8672057e-cd8e-4f23-b002-f1a2785fe8f3"), new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "TeacherId", "Title" },
                values: new object[,]
                {
                    { new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the best SEO practices to rank higher in search engine results and attract more traffic.", "https://images.unsplash.com/photo-1562577309-2592ab84b1bc?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "SEO Mastery", 179.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Boost your website's SEO" },
                    { new Guid("1d9a5bcd-2390-4f8e-92c3-d23a5bcd2391"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn React, Angular, and Vue.js to build complex and interactive web applications.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Frontend Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced frontend technologies" },
                    { new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master microservices development and deployment with .NET and Docker.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Microservices with .NET", 189.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Develop microservices architecture" },
                    { new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to create and promote your personal brand to stand out in your industry.", "https://plus.unsplash.com/premium_photo-1683543124615-fb42e42c6201?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Branding", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build your personal brand" },
                    { new Guid("2d8b5cfa-3441-4b9a-832b-d23a6c9d1342"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn advanced techniques for 3D game development, including physics and AI integration in Unity.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Advanced Game Mechanics", 199.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced Unity game development" },
                    { new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn to implement robust security practices in ASP.NET Core applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "ASP.NET Core Security", 169.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Secure your web applications" },
                    { new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore Agile project management techniques to deliver successful projects on time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Agile Project Management", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master Agile methodologies" },
                    { new Guid("3e7c5dfb-7892-4c9a-913b-e45b8c9d1343"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to design and build responsive websites using CSS, Flexbox, and Grid Layout.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Responsive Web Design", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Create beautiful responsive websites" },
                    { new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to build, secure, and optimize APIs using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Building APIs with .NET Core", 139.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Create robust and efficient APIs" },
                    { new Guid("4f6d7cfb-6783-4d9a-91b4-f56d8c9d1344"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn JavaScript from scratch, including variables, functions, and DOM manipulation.", "https://upload.wikimedia.org/wikipedia/commons/a/a4/JavaScript_code.png", "JavaScript for Beginners", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master the fundamentals of JavaScript" },
                    { new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the art of photography, including composition, lighting, and camera settings.", "https://images.unsplash.com/photo-1524037992922-3a0937719e1d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Photography Basics", 79.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Capture stunning photos" },
                    { new Guid("5f7e8cfb-8914-4e9a-92c5-167e9d9d1345"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master complex CSS concepts like animations, transitions, and preprocessors like SASS and LESS.", "https://cdn.prod.website-files.com/6097e0eca1e875de53031ff6/66b344b75c2572d16bb65242_66b343c191fd4cea42793a3a_image%2520-%25202024-08-07T125129.064.png", "CSS Mastery", 109.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Advanced CSS techniques" },
                    { new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover the tools and techniques to create stunning vector designs using Adobe Illustrator.", "https://images.unsplash.com/photo-1526485797145-514b2fe83749?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Illustrator Essentials", 99.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn Adobe Illustrator from scratch" },
                    { new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understand the principles of investing and learn how to grow your wealth over time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Investing for Beginners", 89.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn the basics of investing" },
                    { new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This course covers the fundamentals of C# programming, including syntax, classes, and objects.", "https://code.visualstudio.com/assets/docs/languages/csharp/csharp-hero.png", "Introduction to C# Programming", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn the basics of C# programming" },
                    { new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to craft compelling stories and improve your writing skills.", "https://images.unsplash.com/photo-1617575521317-d2974f3b56d2?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Creative Writing", 109.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master the art of storytelling" },
                    { new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn to create 2D and 3D games using the Unity engine and C# scripting.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Game Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Build games with Unity" },
                    { new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover the principles of graphic design and how to create eye-catching visuals.", "https://images.unsplash.com/photo-1432888498266-38ffec3eaf0a?q=80&w=2074&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Graphic Design Fundamentals", 119.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn the basics of graphic design" },
                    { new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn to build responsive and interactive web pages using modern frontend technologies.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Frontend Development Essentials", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master HTML, CSS, and JavaScript" },
                    { new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This course covers essential project management techniques and tools for successful project execution.", "https://plus.unsplash.com/premium_photo-1726743809701-67e8600f7670?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Project Management Essentials", 119.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn to manage projects effectively" },
                    { new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn to create high-performance web APIs and applications using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", ".NET Core Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master .NET Core and build robust APIs" },
                    { new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the skills needed to speak confidently and effectively in front of an audience.", "https://plus.unsplash.com/premium_photo-1661780400751-e8e9a09ba7b1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Public Speaking Confidence", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Speak confidently in public" },
                    { new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn advanced techniques for working with databases using Entity Framework Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Entity Framework Core Mastery", 149.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master data access with EF Core" },
                    { new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn data analysis, visualization, and machine learning basics with Python.", "https://plus.unsplash.com/premium_photo-1714618831065-8e8dadd8d3df?q=80&w=1800&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Introduction to Data Science", 199.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Explore the world of data science" },
                    { new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This course provides an introduction to digital marketing, covering SEO, social media, and email marketing.", "https://plus.unsplash.com/premium_photo-1661425715124-310ec1b49b8a?q=80&w=1882&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Digital Marketing 101", 199.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn digital marketing strategies" },
                    { new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This course dives into advanced Python topics, including data structures, algorithms, and performance optimization.", "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Python Programming", 129.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master advanced Python concepts" },
                    { new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the key principles of UI/UX design to create user-friendly and visually appealing designs.", "https://plus.unsplash.com/premium_photo-1733306548826-95daff988ae6?q=80&w=1824&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "UI/UX Design Principles", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master UI/UX design fundamentals" },
                    { new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn the basics of personal finance, including budgeting, saving, and investing.", "https://plus.unsplash.com/premium_photo-1663100794696-6b7afa02016c?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Finance Basics", 79.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Manage your finances effectively" },
                    { new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master the tools and techniques needed to analyze financial statements and make better decisions.", "https://plus.unsplash.com/premium_photo-1661418553375-5ea448f11f34?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Financial Analysis Basics", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn financial analysis techniques" },
                    { new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master advanced .NET Core features to develop scalable and secure backend applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Advanced .NET Backend Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build enterprise-level backend systems" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourseId",
                table: "Orders",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
