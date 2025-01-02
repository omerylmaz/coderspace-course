using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_whole : Migration
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
                    OldCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
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
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
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
                    { new Guid("2d8651fd-3800-48da-a85c-f294282b5180"), 0, "81b0734a-dbdc-419d-b69a-6830b45915ca", "user4@gmail.com", false, "Kerem Aktürkoğlu", false, null, "USER4@GMAIL.COM", "KEREMTURK", "AQAAAAIAAYagAAAAEG8pRpi6c9urjhYiffryJbDm1z/Ssc7yGPUv6lLv/t1oTiStcxjLvvpMFt2odlzD0A==", "5554445566", false, "ab147ada-f7b2-4584-a9e0-51e78f3cc804", false, "keremturk" },
                    { new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"), 0, "0f31d486-2255-4ec7-981b-ffa4460b0762", "user5@gmail.com", false, "Victor Osimhen", false, null, "USER5@GMAIL.COM", "OSIMHEN", "AQAAAAIAAYagAAAAEB7+yG43B+Kn3OW4yQVPEyKLVdj0LQSemSxXZv+XkrEZaK6JaE1Fl6DeJYGnMMK5Gw==", "5555556677", false, "caf9cddf-9830-4ace-bebe-6cf9f6718325", false, "osimhen" },
                    { new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), 0, "c5e7a5a4-eb99-4b72-a1a0-1786b629ef10", "teacher1@gmail.com", false, "Ahmet Kaya", false, null, "TEACHER1@GMAIL.COM", "AHMETKAYA", "AQAAAAIAAYagAAAAEIslPtGZmwocZaOfcEBwLJfRGNXKlGsgNYZQ+sgaiAprm3e4xO4z3bNetWMKJv7fpA==", "5556667788", false, "6b3d1a16-180f-46e0-abab-346273fb068c", false, "ahmetkaya" },
                    { new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"), 0, "7c6c9b05-7cf5-44da-9d05-06a9f7294805", "user3@gmail.com", false, "Kıvanç Tatlıtuğ", false, null, "USER3@GMAIL.COM", "KIVANCTATLI", "AQAAAAIAAYagAAAAEL8bWEbVSGyBrW8YqjdexPuIL1pTPgYzeklV+TGhU6PGr2ayTUHoCsbSiOlZe7Cvxw==", "5553334455", false, "ddd360a1-5efb-4190-82b6-63e60e1dd9f9", false, "kivanctatli" },
                    { new Guid("54039b1c-f914-4171-97a8-f78a9c107935"), 0, "de3987de-c99a-467c-b71f-eea3bdb9b8f7", "user2@gmail.com", false, "Okan Buruk", false, null, "USER2@GMAIL.COM", "OKANBURUK", "AQAAAAIAAYagAAAAEIRsrJJ7GeBRPcGdWNhKEFZoBrkIIJ6JoMMFEyX3wlFu8P0li7+zeuRqwNTs8Q1JZQ==", "5552223344", false, "471f2a7d-ddea-4d1d-bf3e-215ece1feacc", false, "okanburuk" },
                    { new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"), 0, "315b7e01-cac0-4383-b5b6-83ab46c60555", "user1@gmail.com", false, "Ömer Yılmaz", false, null, "USER1@GMAIL.COM", "OMERYILMAZ", "AQAAAAIAAYagAAAAEC3tF8O4qpr1ETYObYsQ8XmZw506R7+X+EBo+nC+jr2/RjutSiXdb37xq3LFUtowMA==", "5551112233", false, "0015862d-cb59-4a5c-a8b2-6ba4255d0bda", false, "omeryilmaz" },
                    { new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), 0, "6016cb3c-7986-43c8-b184-5fee7cd7d553", "teacher2@gmail.com", false, "Fatih Çakıroğlu", false, null, "TEACHER2@GMAIL.COM", "FATIHCAMIR", "AQAAAAIAAYagAAAAEBR+zjJDPxxbr4l8BtixG9ziJCe2GgSX/O6Muwh11fbXhQi67+XY91a9mtzQvO8ZxA==", "5557778899", false, "dbe825ee-edf8-47c6-bc4e-2064173cdd67", false, "fatihcakiroglu" },
                    { new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), 0, "3990b8a1-1af9-4ee2-98a1-2fe85329a151", "teacher3@gmail.com", false, "Şadi Evren Şeker", false, null, "TEACHER3@GMAIL.COM", "SADIEVRENSEKER", "AQAAAAIAAYagAAAAEEkWHizCudf9c0YOB2fvDDSEk+WA0hu7EjaNWATHWsFrzGdVW/su5Hi37CIOeMuMhw==", "5558889900", false, "7a277333-4398-4aab-a12d-8caa61c0961d", false, "sadievrenseker" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9305), "Software" },
                    { new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9321), "Finance" },
                    { new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9319), "Project Management" },
                    { new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9323), "Lifestyle" },
                    { new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9317), "Marketing" },
                    { new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9315), "Design" },
                    { new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(2025, 1, 2, 23, 13, 27, 573, DateTimeKind.Local).AddTicks(9325), "Photography" }
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
                    { new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4015), "Learn the best SEO practices to rank higher in search engine results and attract more traffic.", "https://images.unsplash.com/photo-1562577309-2592ab84b1bc?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "SEO Mastery", 179.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Boost your website's SEO" },
                    { new Guid("1d9a5bcd-2390-4f8e-92c3-d23a5bcd2391"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4022), "Learn React, Angular, and Vue.js to build complex and interactive web applications.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Frontend Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced frontend technologies" },
                    { new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4026), "Master microservices development and deployment with .NET and Docker.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Microservices with .NET", 189.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Develop microservices architecture" },
                    { new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4017), "Learn how to create and promote your personal brand to stand out in your industry.", "https://plus.unsplash.com/premium_photo-1683543124615-fb42e42c6201?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Branding", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build your personal brand" },
                    { new Guid("2d8b5cfa-3441-4b9a-832b-d23a6c9d1342"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4022), "Learn advanced techniques for 3D game development, including physics and AI integration in Unity.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Advanced Game Mechanics", 199.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced Unity game development" },
                    { new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4026), "Learn to implement robust security practices in ASP.NET Core applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "ASP.NET Core Security", 169.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Secure your web applications" },
                    { new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4015), "Explore Agile project management techniques to deliver successful projects on time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Agile Project Management", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master Agile methodologies" },
                    { new Guid("3e7c5dfb-7892-4c9a-913b-e45b8c9d1343"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4023), "Learn how to design and build responsive websites using CSS, Flexbox, and Grid Layout.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Responsive Web Design", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Create beautiful responsive websites" },
                    { new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4025), "Learn how to build, secure, and optimize APIs using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Building APIs with .NET Core", 139.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Create robust and efficient APIs" },
                    { new Guid("4f6d7cfb-6783-4d9a-91b4-f56d8c9d1344"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4023), "Learn JavaScript from scratch, including variables, functions, and DOM manipulation.", "https://upload.wikimedia.org/wikipedia/commons/a/a4/JavaScript_code.png", "JavaScript for Beginners", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master the fundamentals of JavaScript" },
                    { new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4017), "Learn the art of photography, including composition, lighting, and camera settings.", "https://images.unsplash.com/photo-1524037992922-3a0937719e1d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Photography Basics", 79.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Capture stunning photos" },
                    { new Guid("5f7e8cfb-8914-4e9a-92c5-167e9d9d1345"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4024), "Master complex CSS concepts like animations, transitions, and preprocessors like SASS and LESS.", "https://cdn.prod.website-files.com/6097e0eca1e875de53031ff6/66b344b75c2572d16bb65242_66b343c191fd4cea42793a3a_image%2520-%25202024-08-07T125129.064.png", "CSS Mastery", 109.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Advanced CSS techniques" },
                    { new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4014), "Discover the tools and techniques to create stunning vector designs using Adobe Illustrator.", "https://images.unsplash.com/photo-1526485797145-514b2fe83749?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Illustrator Essentials", 99.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn Adobe Illustrator from scratch" },
                    { new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4016), "Understand the principles of investing and learn how to grow your wealth over time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Investing for Beginners", 89.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn the basics of investing" },
                    { new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4006), "This course covers the fundamentals of C# programming, including syntax, classes, and objects.", "https://code.visualstudio.com/assets/docs/languages/csharp/csharp-hero.png", "Introduction to C# Programming", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn the basics of C# programming" },
                    { new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4020), "Learn how to craft compelling stories and improve your writing skills.", "https://images.unsplash.com/photo-1617575521317-d2974f3b56d2?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Creative Writing", 109.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master the art of storytelling" },
                    { new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4021), "Learn to create 2D and 3D games using the Unity engine and C# scripting.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Game Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Build games with Unity" },
                    { new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4018), "Discover the principles of graphic design and how to create eye-catching visuals.", "https://images.unsplash.com/photo-1432888498266-38ffec3eaf0a?q=80&w=2074&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Graphic Design Fundamentals", 119.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn the basics of graphic design" },
                    { new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4020), "Learn to build responsive and interactive web pages using modern frontend technologies.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Frontend Development Essentials", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master HTML, CSS, and JavaScript" },
                    { new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4013), "This course covers essential project management techniques and tools for successful project execution.", "https://plus.unsplash.com/premium_photo-1726743809701-67e8600f7670?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Project Management Essentials", 119.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn to manage projects effectively" },
                    { new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4021), "Learn to create high-performance web APIs and applications using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", ".NET Core Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master .NET Core and build robust APIs" },
                    { new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4019), "Learn the skills needed to speak confidently and effectively in front of an audience.", "https://plus.unsplash.com/premium_photo-1661780400751-e8e9a09ba7b1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Public Speaking Confidence", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Speak confidently in public" },
                    { new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4025), "Learn advanced techniques for working with databases using Entity Framework Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Entity Framework Core Mastery", 149.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master data access with EF Core" },
                    { new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4018), "Learn data analysis, visualization, and machine learning basics with Python.", "https://plus.unsplash.com/premium_photo-1714618831065-8e8dadd8d3df?q=80&w=1800&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Introduction to Data Science", 199.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Explore the world of data science" },
                    { new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4012), "This course provides an introduction to digital marketing, covering SEO, social media, and email marketing.", "https://plus.unsplash.com/premium_photo-1661425715124-310ec1b49b8a?q=80&w=1882&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Digital Marketing 101", 199.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn digital marketing strategies" },
                    { new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4014), "This course dives into advanced Python topics, including data structures, algorithms, and performance optimization.", "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Python Programming", 129.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master advanced Python concepts" },
                    { new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4012), "Learn the key principles of UI/UX design to create user-friendly and visually appealing designs.", "https://plus.unsplash.com/premium_photo-1733306548826-95daff988ae6?q=80&w=1824&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "UI/UX Design Principles", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master UI/UX design fundamentals" },
                    { new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4013), "Learn the basics of personal finance, including budgeting, saving, and investing.", "https://plus.unsplash.com/premium_photo-1663100794696-6b7afa02016c?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Finance Basics", 79.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Manage your finances effectively" },
                    { new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4019), "Master the tools and techniques needed to analyze financial statements and make better decisions.", "https://plus.unsplash.com/premium_photo-1661418553375-5ea448f11f34?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Financial Analysis Basics", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn financial analysis techniques" },
                    { new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 2, 23, 13, 27, 574, DateTimeKind.Local).AddTicks(4024), "Master advanced .NET Core features to develop scalable and secure backend applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Advanced .NET Backend Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build enterprise-level backend systems" }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "CourseId", "CreatedDate", "Description", "Duration", "Title" },
                values: new object[,]
                {
                    { new Guid("037f46cd-2235-4bb0-89ea-f3049968a4ac"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(8667), "Accusantium cupiditate quo quae libero architecto iure qui quia pariatur. İusto fugiat et rerum accusamus illo. Officia ut quo eveniet sit voluptatem voluptas maxime sequi. Voluptatem minus architecto corporis cupiditate voluptatem qui eveniet aspernatur.", new TimeSpan(0, 0, 13, 0, 0), "Quam voluptatem voluptates facere omnis." },
                    { new Guid("089abc2d-59ec-47b8-bb79-955d66f35e96"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(829), "Rerum iusto eveniet qui ut. İnventore rerum eius maxime voluptatem est reprehenderit dolorem. Qui eligendi voluptas quam nostrum aut. Eveniet ut quia sunt non quod earum magni vitae.", new TimeSpan(0, 0, 33, 0, 0), "İmpedit laborum accusantium maxime molestiae." },
                    { new Guid("093a8be9-6f65-46f5-a6c1-82dd96248f54"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3086), "Necessitatibus fugit quis enim. Quia facere rerum. Dicta deserunt officia non unde soluta accusantium. Veniam eaque adipisci est id dolorum temporibus. Ullam officiis nobis ullam quia inventore ipsa sed necessitatibus.", new TimeSpan(0, 0, 15, 0, 0), "Cupiditate placeat eos ut modi." },
                    { new Guid("0a3d7c9d-af4b-49be-bce1-3e1b0937f30d"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4122), "İtaque tenetur quidem et dolor nihil. Vero aut aliquid nam ut. Rerum ea ipsa mollitia necessitatibus delectus tempore. Dolor nihil mollitia nam aut aut ut qui rem molestias.", new TimeSpan(0, 0, 29, 0, 0), "Quidem praesentium sed aut commodi." },
                    { new Guid("0fdd804e-f0cd-478d-b870-f8933b9efedd"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5363), "Qui eveniet accusamus quia eos. Eligendi iusto labore. Molestiae dolores libero ex vel itaque consequatur. Reprehenderit voluptatem sint eos harum.", new TimeSpan(0, 0, 36, 0, 0), "Qui quidem iure culpa nobis." },
                    { new Guid("10e2cb09-0959-46e8-a099-b04019b8da33"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9199), "Dicta reprehenderit voluptatem esse veniam sunt voluptatem quibusdam ipsa enim. Aliquid iusto sed dolorum autem id. Magnam blanditiis tenetur doloremque voluptatibus praesentium amet voluptatum. İnventore non saepe magnam ducimus iusto voluptates ipsam. Rem omnis quia dolores. Quia nostrum vel illo consequuntur cumque.", new TimeSpan(0, 0, 15, 0, 0), "Delectus modi ipsam natus totam." },
                    { new Guid("14957bc9-49e4-4ac8-9a97-5cca7b34e525"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4887), "Accusamus vel necessitatibus illo iusto autem officiis officia. Dolores vero et nulla sunt hic similique. Natus sed hic unde rerum natus.", new TimeSpan(0, 0, 24, 0, 0), "Natus pariatur aliquid et sit." },
                    { new Guid("15e97a20-2877-42a4-aa5a-1bcb2afffc13"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(557), "Eos blanditiis eaque soluta iure id culpa. Autem et sed aut consequatur aut aspernatur. Ex velit totam et esse perspiciatis qui consequatur natus. Et inventore ut natus quae itaque. Est cupiditate voluptatem earum aut dolorem at expedita deserunt aliquid. Amet et eligendi eum.", new TimeSpan(0, 0, 17, 0, 0), "Numquam vel in qui fugiat." },
                    { new Guid("1676b2f5-6b41-4f8f-8bfd-c8862eb7ccae"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8985), "Voluptatem consequuntur quia. Qui non fugiat cupiditate ducimus omnis consequatur ut architecto occaecati. Et qui fugit laborum. Aut voluptatum tempore qui. Est nesciunt debitis rem est unde autem. Odit impedit velit ducimus officiis et velit.", new TimeSpan(0, 0, 39, 0, 0), "Soluta laborum molestiae vitae non." },
                    { new Guid("1b25098c-28a3-4f24-b01d-69ed04aae0d9"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3580), "Quod placeat rerum rerum error delectus officiis voluptas accusantium. Est libero deserunt placeat et provident natus. İure veritatis consequuntur autem minus accusantium architecto tenetur a.", new TimeSpan(0, 0, 38, 0, 0), "Recusandae nulla quia ut mollitia." },
                    { new Guid("1c21c743-859b-42db-ba37-b1c624653173"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3815), "Commodi voluptatum voluptatem minus dolor ullam dolore id. Quidem harum animi molestiae repudiandae voluptas. Aperiam rem ut pariatur recusandae repellendus dolorem eligendi veritatis. Quo exercitationem vero velit dolor pariatur. Voluptate magni a veniam id voluptatem sed praesentium odio. İpsam impedit optio modi quibusdam est.", new TimeSpan(0, 0, 7, 0, 0), "Omnis ut et quibusdam dignissimos." },
                    { new Guid("1df2b1f3-6f6a-4265-936a-216af915dd3b"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(656), "Vitae deleniti vitae. Autem repellendus placeat non corrupti est ab at doloremque. Voluptates consequatur quo.", new TimeSpan(0, 0, 7, 0, 0), "Et est voluptatibus amet in." },
                    { new Guid("1f6efee9-a412-48af-83e0-e5da06614c47"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(7058), "Consequatur et id praesentium est libero ex ratione. Dolorum quo nihil officiis autem. Quo mollitia necessitatibus est suscipit cumque ut. Perspiciatis voluptas aut sit.", new TimeSpan(0, 0, 13, 0, 0), "Pariatur et architecto dolorem distinctio." },
                    { new Guid("209ac38a-260b-4135-9ca5-5476376c7d0d"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6070), "Sunt quod porro nisi accusantium eos. Culpa esse consequatur quis assumenda eius totam ipsum est. Eligendi tempora et atque sapiente. Quo quas veritatis est eum quibusdam. İtaque dolores qui voluptas dicta. Eos quos ut voluptas ducimus non sed.", new TimeSpan(0, 0, 31, 0, 0), "Distinctio praesentium mollitia dolorem quis." },
                    { new Guid("213b24c3-6db1-4186-b75a-163d83bd336d"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2441), "Sunt incidunt assumenda. Corrupti et dolor aperiam doloribus dolores expedita sit. Eum consequatur est veniam adipisci aut delectus nisi natus non. Repellat velit modi ab consequuntur est sit aut alias. Rerum optio consequatur voluptates tenetur.", new TimeSpan(0, 0, 26, 0, 0), "Fuga qui exercitationem ea sit." },
                    { new Guid("21a04e4b-9f12-42bd-a01b-a0f79a1d404b"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4600), "Et nemo quod veritatis autem sit vel consequuntur unde. Et corporis mollitia explicabo quasi dolor nostrum sed. Cumque eaque quaerat esse. Magnam et eligendi aspernatur voluptas et minima. İusto nihil repudiandae provident minima.", new TimeSpan(0, 0, 32, 0, 0), "Vel velit voluptas eos odio." },
                    { new Guid("22ef0aa9-4716-46e8-bc74-f143bc7f13dd"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4936), "Recusandae nobis ab dolores. Eum nulla quia assumenda ut aperiam nostrum dolores voluptatem nam. Commodi ut corrupti nihil. Consequuntur natus quasi voluptas delectus voluptatum et eius asperiores. Et eaque quasi aperiam.", new TimeSpan(0, 0, 33, 0, 0), "Fugiat ut quia adipisci voluptatem." },
                    { new Guid("26614ddd-8d09-4ca4-a854-4f63d7de445a"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6821), "Molestias porro id ratione corrupti consequuntur eveniet commodi. Quasi porro rerum quia fugit est quasi fugit. Doloribus et quia quae. Laboriosam nisi at sequi tempore sit quod. Fugit assumenda dolor consequuntur sapiente dolorem.", new TimeSpan(0, 0, 14, 0, 0), "Eos eveniet ut itaque sed." },
                    { new Guid("2b882d59-5033-41ac-adbe-3af5de8bbf40"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(8827), "Voluptas ex aut praesentium qui tenetur tenetur magnam. Qui esse eius et modi corrupti velit et. Veritatis aut veritatis. Voluptatem qui ratione facere.", new TimeSpan(0, 0, 35, 0, 0), "At ea dolor omnis corporis." },
                    { new Guid("2bf0c3c8-2580-47e9-bee5-8e3ac5a8ec49"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9629), "Doloremque eveniet non. Voluptatum et aut error et velit. Aspernatur quia eveniet voluptatum. Dolorem odit corporis est ducimus aliquid tempore quia quas.", new TimeSpan(0, 0, 34, 0, 0), "İmpedit aut rem excepturi possimus." },
                    { new Guid("2f3c270c-59d1-4d70-98cc-51001de5dd3f"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1647), "Cum exercitationem illo ex nostrum corporis. Qui eum eum facilis ea cupiditate quae. Qui in aliquid.", new TimeSpan(0, 0, 35, 0, 0), "Quo libero dicta voluptas suscipit." },
                    { new Guid("330424b0-af4c-4609-8cb4-12fa8d5f27b0"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(7430), "Soluta non quis delectus quia quis voluptatum dignissimos quia qui. Quo sequi est ea sunt rem velit. Doloremque ab et perferendis ipsum consequatur. Aperiam illum beatae quis illum reiciendis vitae non exercitationem est. Quia aut itaque in tempore quia. Ducimus maiores qui doloremque officia ut autem velit est.", new TimeSpan(0, 0, 12, 0, 0), "Ut iusto ipsam rerum similique." },
                    { new Guid("34042fb0-6e86-4cad-9991-bcebfe64b532"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(9349), "İnventore fugiat deserunt. Reiciendis alias adipisci voluptas nam debitis amet est voluptatem. Sit sunt asperiores libero qui iure enim dolor et.", new TimeSpan(0, 0, 15, 0, 0), "Exercitationem aut ut laboriosam porro." },
                    { new Guid("365f5298-28ef-4e64-b5f3-0feea8287064"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(9498), "Ut a libero perferendis recusandae dolorem veritatis sint corrupti earum. Quos soluta doloribus ut beatae distinctio error est. Ea modi in consectetur deserunt. İd incidunt deserunt. Culpa velit ipsam adipisci aperiam sunt.", new TimeSpan(0, 0, 22, 0, 0), "Nihil iusto asperiores ea aspernatur." },
                    { new Guid("36b0d3b1-e871-4f9d-bcf5-563fdcaff318"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3099), "Libero qui repellat omnis. Nulla voluptas neque molestias ut consequatur. Eius quis sint expedita est velit quia alias voluptas. Soluta voluptatem ipsum velit voluptas et consequuntur inventore. Vitae qui eum. Molestiae consequatur nostrum officiis officia fugit a similique.", new TimeSpan(0, 0, 11, 0, 0), "Veritatis voluptatum consequuntur et delectus." },
                    { new Guid("380eafde-bdae-41be-a8c0-ae27183a950a"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2578), "Qui deleniti vel eos pariatur deserunt. Aut nihil iure molestiae. Aut omnis quasi asperiores quos et. Pariatur et totam.", new TimeSpan(0, 0, 8, 0, 0), "Cum corrupti nobis omnis consequatur." },
                    { new Guid("38979d93-355a-45ca-82a7-a0db0e455a8a"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5130), "Ducimus et illum reiciendis labore maxime. Et animi voluptates. Quis ab omnis magni itaque labore quam. Dolores ut sint ipsam quia laboriosam qui quia repudiandae et.", new TimeSpan(0, 0, 34, 0, 0), "Quam vel est dolorum possimus." },
                    { new Guid("3ae3ae6b-ff10-4d1c-8dec-a93642e5e6b2"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4590), "Pariatur ducimus quos harum error autem autem optio. Ut id rerum. Ab dignissimos voluptate sed ut accusantium similique et. Et eveniet velit iure sunt. Dolorem reprehenderit distinctio quis. Nobis veritatis quia molestiae quos natus suscipit.", new TimeSpan(0, 0, 13, 0, 0), "Consequuntur eaque minima accusamus et." },
                    { new Guid("4421ebd5-c29e-4262-9766-a6da5ea296f6"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8821), "Dolorem architecto sed quae. İpsam assumenda dicta. Corrupti in laborum eum nobis officiis.", new TimeSpan(0, 0, 16, 0, 0), "Quos ducimus fugiat adipisci ut." },
                    { new Guid("44bdbda1-e992-4cdb-8ec3-4834822fa6aa"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5712), "Consequatur sed officiis praesentium perferendis consequatur sit quo corporis voluptas. Minima quis aut quae. Tempore cum rerum voluptatem architecto quas. Est hic voluptas qui omnis laboriosam repudiandae ipsa. Aliquid sed distinctio debitis nam et odit sequi.", new TimeSpan(0, 0, 23, 0, 0), "Nam veniam vitae dolorem molestias." },
                    { new Guid("45ca8ef7-454c-4758-b21d-587fd3e5822c"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2894), "İpsam consequatur qui nisi adipisci tempora sit maxime sint omnis. Molestias iure adipisci beatae. Qui possimus nihil molestiae. Minima vel et ipsum officiis quaerat voluptas eaque beatae.", new TimeSpan(0, 0, 37, 0, 0), "Qui error dicta qui quisquam." },
                    { new Guid("467e771b-adfb-4c20-8711-999ef5f036d8"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5427), "Beatae et aut rerum voluptatem dolores. Nemo et et autem tempore quisquam totam autem. Tenetur voluptas cum earum. Non reiciendis a consequatur est quo unde.", new TimeSpan(0, 0, 39, 0, 0), "Eveniet eligendi vero natus facilis." },
                    { new Guid("4a736d54-834a-4090-9331-11f5ea277f8c"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9874), "Sint cupiditate laudantium sed voluptatem accusamus soluta est. Saepe molestias voluptas ab fuga voluptas. Qui nostrum doloribus facere cum eum a iure.", new TimeSpan(0, 0, 14, 0, 0), "Veniam ab facilis qui illum." },
                    { new Guid("4f69993f-fc81-49c8-b198-5c62158bd50d"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(9841), "Sed et rem odit nostrum sunt. Voluptatem at ut ea. Eos labore voluptates est consequatur molestias omnis veritatis voluptatem. Facere dignissimos non et et. Et sint consectetur sint ut quia.", new TimeSpan(0, 0, 39, 0, 0), "İn non necessitatibus odit qui." },
                    { new Guid("503eaf40-9451-4811-aabd-0aa6b4ae8a9e"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(8454), "Magnam molestiae tempore blanditiis sit adipisci ad dolor. Ea doloremque ut ab aut nostrum. Similique praesentium temporibus esse ut.", new TimeSpan(0, 0, 27, 0, 0), "Facilis tempore voluptas eum saepe." },
                    { new Guid("5058d0f6-2910-47ec-954b-5633eb208339"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6025), "Et est qui perferendis quam eius et. Excepturi natus ut. Sit et qui veniam ea sit architecto reprehenderit odit autem.", new TimeSpan(0, 0, 25, 0, 0), "Rem qui nobis quia eveniet." },
                    { new Guid("5083ef79-747f-4e78-b470-947fe6ac26e9"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(2734), "Laborum itaque qui. Veritatis quaerat et debitis. Autem laudantium occaecati ut sed laboriosam minima aut qui neque. Ea aut itaque non delectus quaerat ut est distinctio. Accusamus deleniti reiciendis.", new TimeSpan(0, 0, 24, 0, 0), "Dolorum ut fugit nihil ut." },
                    { new Guid("5721ad39-685b-45bd-a062-1fbd3fb6c6e5"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8457), "Eius pariatur est. Temporibus est et. Tenetur soluta hic voluptas. Modi voluptatem sit necessitatibus natus est ullam qui. Adipisci harum et blanditiis soluta molestiae eum.", new TimeSpan(0, 0, 21, 0, 0), "Unde quo blanditiis amet asperiores." },
                    { new Guid("58b78a5c-ebe5-4035-bf46-360ee4eb6d6c"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4382), "Repellat sed sed nisi dolorem est vero atque exercitationem. Facere laboriosam voluptatibus quis fugit. Eos omnis esse et nisi facilis et nam et qui. Qui cumque necessitatibus. Enim saepe qui dolor dolor provident deleniti neque quia qui.", new TimeSpan(0, 0, 23, 0, 0), "Perferendis aut optio blanditiis ipsam." },
                    { new Guid("5b09f2c8-6a55-484c-b5e6-6c1eaeeb70a6"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(8126), "Ea veniam consequatur dolor. Dolorum voluptatem maiores et labore ipsum quaerat quas. Occaecati aut soluta dignissimos rerum molestiae numquam et velit. Exercitationem omnis delectus officia impedit ut dolores magnam quia inventore.", new TimeSpan(0, 0, 16, 0, 0), "Aut voluptates possimus asperiores cupiditate." },
                    { new Guid("5b65c3d4-5ec8-433e-a2f3-af1ad0a18130"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(2555), "Explicabo enim consectetur explicabo vel et. Voluptas voluptatem veniam ducimus. İncidunt possimus iste vitae odio dolore. Molestiae illum voluptas sit cumque quo vitae hic soluta. Labore eos fugiat molestiae est nihil quasi sapiente fuga.", new TimeSpan(0, 0, 27, 0, 0), "Exercitationem non saepe ducimus qui." },
                    { new Guid("5c01e6d2-03c7-41a1-9bd9-1834bc5ba39e"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1904), "İllo quia quasi. İllum animi tenetur. Odit quae et qui consequuntur ea culpa pariatur non dolor. Totam nisi fugit.", new TimeSpan(0, 0, 5, 0, 0), "Modi dolor dolores iste cum." },
                    { new Guid("5d653eb1-eb77-4b68-a1fe-94f14d05818f"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4733), "Laudantium debitis accusamus nulla blanditiis et ut quia molestiae in. Nam et assumenda dolorum distinctio ex occaecati. Libero voluptas nobis labore quo omnis doloremque omnis. Distinctio consequuntur nulla aut.", new TimeSpan(0, 0, 27, 0, 0), "Qui inventore ex nobis non." },
                    { new Guid("5e42fa06-fd5e-480f-a0bb-c4e504a9629e"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1575), "Qui est dolorum quaerat at quas odio doloremque laudantium ut. Qui officia nulla cupiditate dicta ex voluptatum. İd ut corrupti dolores praesentium perspiciatis molestias libero. Voluptas ut maxime. Sed distinctio quasi nisi et voluptatem dolores.", new TimeSpan(0, 0, 16, 0, 0), "Dignissimos laborum earum dolor eos." },
                    { new Guid("5fcae302-f23e-4b31-a133-3b3236fa1183"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1415), "Corporis dolorum voluptates inventore dolores nisi sit error delectus. Eligendi sunt optio sunt. Sit assumenda quae perferendis voluptatem qui recusandae fugit quo. İpsam repellendus soluta officiis et perferendis ea omnis. Sit eos dolorem ex perferendis. Voluptas id rerum tenetur.", new TimeSpan(0, 0, 23, 0, 0), "Quia deleniti eos corrupti sunt." },
                    { new Guid("6399167c-03b9-459e-ada0-a391e5f659a3"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6270), "Beatae harum quod aut nam non. Maxime est aut. Sunt dolorem qui ex fugit doloribus vel. Ut perspiciatis inventore mollitia qui quidem consequatur et laborum. At deleniti necessitatibus et.", new TimeSpan(0, 0, 39, 0, 0), "Laudantium possimus quidem corporis quo." },
                    { new Guid("63c894e1-5d13-49c2-bafe-fc9d475a6209"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7550), "Quo saepe aut. Quis qui ad nulla cum. Similique debitis explicabo laboriosam ut in sapiente magnam omnis a. Quaerat provident ab aut eius aspernatur nihil cumque.", new TimeSpan(0, 0, 13, 0, 0), "Est ut nisi quo perspiciatis." },
                    { new Guid("676de2ab-9bfd-414b-8030-463cf80e3c6a"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4975), "Earum modi voluptas. Quaerat fugit ea assumenda doloribus. İd reiciendis aperiam fugiat et sunt.", new TimeSpan(0, 0, 37, 0, 0), "Quis eius quo expedita fugit." },
                    { new Guid("69570e81-938c-4939-9db0-e5d0bf2b22b3"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(165), "Alias non sit molestiae provident sit blanditiis voluptatem ut. Alias doloribus enim cumque deleniti sint et qui aut. Accusamus ipsam hic.", new TimeSpan(0, 0, 28, 0, 0), "Libero reiciendis cupiditate corrupti corporis." },
                    { new Guid("6c2f5ff6-6681-4156-b196-f5893cb62c65"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(7649), "Eveniet aut eum id similique ad saepe pariatur. Sit voluptatum itaque omnis. Recusandae sed est sapiente. At dolore quis nemo neque. Doloribus officia rem id recusandae aut odio rerum molestias. Similique ipsum praesentium qui rerum harum veritatis voluptas.", new TimeSpan(0, 0, 12, 0, 0), "Voluptatem eum temporibus harum impedit." },
                    { new Guid("6cf6a6bf-5e1b-40e3-9543-10e7d506016a"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6895), "İn dolores fugit nesciunt fuga cupiditate voluptas. Ut sunt tempora et autem. Placeat dolorem asperiores corporis quos qui. Quo quis ipsam sed eaque expedita.", new TimeSpan(0, 0, 22, 0, 0), "İd in dolores facilis itaque." },
                    { new Guid("6d9add44-24b9-4f47-b65d-027e8431ae7e"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6270), "Ullam aut quas ut illo eligendi aut numquam nam. Esse illum quae quia a alias. Tenetur perferendis voluptate dolorem. Et et magnam consequuntur quibusdam maxime voluptatem beatae officia est. Natus voluptatem voluptatem quae vitae aliquam eos. Blanditiis facere sed animi quam veritatis iusto.", new TimeSpan(0, 0, 33, 0, 0), "Non voluptate eum velit qui." },
                    { new Guid("6e88a2cf-da4d-48c0-9bc7-1cfa71870da9"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1987), "Quis optio ipsa temporibus iste voluptas dolores a dolor corrupti. Explicabo cupiditate quaerat eos ipsum. Eveniet recusandae recusandae hic asperiores sed aspernatur adipisci sint ipsa. Ut non reprehenderit fuga consectetur facilis quia est nam deleniti. İllo mollitia accusamus. Consequatur laborum vel.", new TimeSpan(0, 0, 37, 0, 0), "Possimus quaerat alias soluta qui." },
                    { new Guid("6f10ecff-8f4b-48b6-900c-1c37fd31d438"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(9201), "Provident ea eum. Ut tenetur accusamus commodi animi tempore voluptas incidunt perferendis. Repudiandae quis quae deleniti. Qui tempore ipsam omnis aut quaerat. Et est nobis et unde sit officiis a sunt. Aut dolore deleniti iure qui ab excepturi.", new TimeSpan(0, 0, 23, 0, 0), "Cumque deleniti quidem at dolores." },
                    { new Guid("717e7545-719c-487f-9c4f-3430405f9cea"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(81), "Nihil sit esse quo voluptatem aut alias praesentium dolores. Nesciunt hic eos laborum architecto et. Dignissimos voluptatem doloribus aperiam unde. Quo corporis iste dolorum odio reiciendis consequatur quos exercitationem. Voluptate non omnis. Qui modi quia aut porro aut.", new TimeSpan(0, 0, 30, 0, 0), "Voluptatem ut ratione repellat error." },
                    { new Guid("71e780ae-ac86-4895-94b8-7bc54771590d"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6459), "Perspiciatis rerum nisi nihil. Vero et sapiente reprehenderit totam molestiae. Voluptatem sit corporis laborum tenetur molestias tenetur suscipit delectus deserunt.", new TimeSpan(0, 0, 12, 0, 0), "Libero beatae recusandae voluptatum ab." },
                    { new Guid("761519d4-bf73-48f9-a21a-8ab9b578818e"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(7226), "Vitae hic numquam. Qui omnis alias illum. Et vel doloremque. Optio dolorem neque recusandae et repellat consectetur. Sit natus sit aut soluta minima quia perferendis.", new TimeSpan(0, 0, 38, 0, 0), "Qui voluptatem magni beatae sapiente." },
                    { new Guid("789085b7-627f-49e2-b022-b4fbdf81ad9f"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2063), "Quia accusamus perspiciatis saepe natus in harum quasi. Ea illum architecto praesentium quidem. Cum nulla animi dolores dolor. Et fugit id eum. Aliquam similique harum. At omnis quam consectetur nemo eius qui maiores laudantium.", new TimeSpan(0, 0, 21, 0, 0), "Nulla explicabo voluptatem nihil nulla." },
                    { new Guid("7bb03c31-693e-48ee-bf2b-b5868960b9d7"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(930), "Doloribus possimus omnis iste et dolores. Voluptatem eaque qui consectetur. Quaerat ea cupiditate. Aliquid itaque autem eum molestias enim provident. Et ut pariatur ex praesentium. Praesentium reprehenderit quia laboriosam.", new TimeSpan(0, 0, 33, 0, 0), "Tenetur similique distinctio omnis iste." },
                    { new Guid("7c34344d-915a-4103-96ba-ed0486814575"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6927), "Quae laudantium ea. Quia autem quaerat provident et doloribus. İpsam deleniti in tempore voluptatem. Ut labore amet.", new TimeSpan(0, 0, 25, 0, 0), "Nihil ut ut eum vel." },
                    { new Guid("7c600605-7dcf-4add-b9c2-6960e6705d2f"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(527), "İusto animi ea distinctio aspernatur. Quam provident sed rerum. Quia voluptas possimus et nihil dolore commodi. Deleniti suscipit cupiditate minima cumque quaerat sapiente explicabo voluptas voluptas. Quae culpa impedit libero molestiae rerum tempore ab maiores natus. Et quam illo maiores occaecati corporis fuga eos.", new TimeSpan(0, 0, 38, 0, 0), "Consequuntur dolorum adipisci aut nam." },
                    { new Guid("7cc1faae-34c4-4ef3-95ef-66a87bc5c7d4"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(8741), "İtaque ea illo a facere ipsum quidem. Architecto quaerat possimus illo sit. Est similique atque quibusdam ratione dolorem et. Et velit id nesciunt et perferendis rerum fuga deserunt et.", new TimeSpan(0, 0, 31, 0, 0), "Cupiditate alias recusandae quo qui." },
                    { new Guid("7f73794e-73a3-4ca5-af26-cdf072044266"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5899), "Neque harum quo nobis quia voluptatem et. Quos doloribus sed dolore in et dolor nihil nostrum. Quos necessitatibus totam qui sit.", new TimeSpan(0, 0, 36, 0, 0), "Magni earum id ipsum et." },
                    { new Guid("803aa565-03c3-4179-aba4-00a9e754b180"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3999), "Minus pariatur aut iure aut est deleniti nihil sed libero. İllum dolorem dolorem voluptatum odio vitae optio quam est. Nostrum velit quia aut accusamus.", new TimeSpan(0, 0, 33, 0, 0), "Omnis omnis ducimus sint aut." },
                    { new Guid("8222748a-0411-4908-abb9-33302d79ae8f"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(945), "Quo delectus eos qui sit. Sit delectus sunt labore eaque ex eum impedit nemo doloremque. Quasi exercitationem aliquam ipsa est et in commodi totam.", new TimeSpan(0, 0, 34, 0, 0), "Ratione id perspiciatis voluptatum voluptas." },
                    { new Guid("8309278d-f5ac-4ec8-b35c-f9adf1de23ce"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6474), "Sunt ipsum earum deleniti beatae qui et eos ea tempora. Nihil cum mollitia eos. Voluptas ducimus nihil. Doloribus illum ipsa pariatur voluptatum fugit ad eos consequuntur. Autem et voluptate iste consequatur dolores impedit.", new TimeSpan(0, 0, 32, 0, 0), "Repellendus consequatur deleniti dolor cupiditate." },
                    { new Guid("87bcb798-e93e-4bd8-b1e9-bcf0e4de825d"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8096), "Dolores iste voluptate veritatis alias labore ipsum earum qui. İn qui expedita et laboriosam ea fuga porro harum. Ab neque nostrum rem. Voluptas corporis omnis iste. İpsa tenetur est nesciunt tempora suscipit mollitia. Ut est praesentium exercitationem excepturi eligendi amet accusantium minima molestiae.", new TimeSpan(0, 0, 21, 0, 0), "Beatae ut qui exercitationem molestiae." },
                    { new Guid("8c791c34-bfff-4fee-98cd-162342173a2d"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(2187), "Molestiae voluptate enim et animi. İnventore facere dolorum explicabo nulla fugit nihil quas. Rerum et praesentium earum accusantium non. Cupiditate reprehenderit qui. Aspernatur ullam quisquam non nihil tempora in vel ad.", new TimeSpan(0, 0, 26, 0, 0), "Sed natus ut sunt quisquam." },
                    { new Guid("8d56e4c7-f625-4c6f-b9c3-212450a569be"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4390), "Similique nemo et modi impedit qui necessitatibus quia. Veniam ipsam et est culpa placeat omnis quasi. Sed facere laudantium inventore. Officia consequatur velit. Voluptate necessitatibus eaque ducimus tenetur debitis praesentium explicabo.", new TimeSpan(0, 0, 9, 0, 0), "Delectus ratione esse excepturi pariatur." },
                    { new Guid("8d6f6109-bc31-4cd7-9876-5f6ae5962f29"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5716), "Non ut non adipisci dolorem sed commodi enim. Veritatis ipsam sunt expedita nobis deserunt. Voluptatem sequi ex sint fuga fugit incidunt. Aut similique rerum impedit deserunt repellat aut.", new TimeSpan(0, 0, 10, 0, 0), "Eveniet necessitatibus consequuntur sint deserunt." },
                    { new Guid("90b63338-25cc-43ff-874d-ac19937d36d7"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1762), "Sed vitae incidunt blanditiis magnam corporis doloribus architecto eaque ullam. Sequi minus illum non nulla porro et. Aut quia temporibus architecto velit eos.", new TimeSpan(0, 0, 27, 0, 0), "Repellat maxime repudiandae ut ut." },
                    { new Guid("91ae3950-f1bd-4fa8-a444-be84371ee41f"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4239), "Aliquam dolores quia ut. İpsa at ad et quasi consequatur dolorem hic ullam at. Odit nesciunt dicta.", new TimeSpan(0, 0, 13, 0, 0), "Porro cum dicta corporis sit." },
                    { new Guid("91be3ee9-e712-4d2f-9102-6367f6d8b77a"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(8065), "Sint mollitia aperiam libero saepe aut labore sed. Quisquam ducimus sed sit voluptas excepturi error aut. Laborum autem qui assumenda et soluta est eius mollitia. Ad ea quidem ut dolores alias dicta qui dolorem perferendis. Qui sed rerum amet aliquid accusantium itaque qui. Quas ipsa saepe dolores quia atque ipsa.", new TimeSpan(0, 0, 18, 0, 0), "Culpa maiores laboriosam ut itaque." },
                    { new Guid("91e5c194-6ac5-4f4f-9efa-cfa4900184a7"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(6616), "Aperiam alias minus. Facere rerum qui cupiditate sed quis. Quis ducimus temporibus minima. Doloremque nihil blanditiis corrupti culpa rerum aut accusantium sit. Aperiam alias id incidunt blanditiis.", new TimeSpan(0, 0, 10, 0, 0), "Et accusamus et est culpa." },
                    { new Guid("9342d6bc-4052-433c-b0c8-6253fdceee0b"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(2341), "Voluptates placeat enim enim aut nam sed. Dolorum tempora eos labore reprehenderit unde et qui. Exercitationem repellendus quia magni dicta quidem eaque laborum at. İtaque qui nihil cupiditate qui temporibus quis. Eveniet aliquam eaque.", new TimeSpan(0, 0, 16, 0, 0), "Ad unde doloremque iure unde." },
                    { new Guid("958b4182-4950-402a-9a54-c647a9e65ccf"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9762), "Et blanditiis architecto magnam deserunt. Est consequatur iste natus. Libero est tempore natus facere sint.", new TimeSpan(0, 0, 11, 0, 0), "Nihil eaque ut beatae cumque." },
                    { new Guid("970bac88-aa40-48fc-bdbb-aa8e9c961ce4"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(7604), "Explicabo id eos. Eveniet aspernatur sunt voluptas est. Non porro odit molestiae architecto dolor quisquam dolorem ut.", new TimeSpan(0, 0, 32, 0, 0), "Delectus deleniti qui autem labore." },
                    { new Guid("9b32af52-f1f9-4fb3-a324-a3996ed7f828"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7925), "Quod praesentium sit saepe quaerat ratione non voluptatem. Quia magni eveniet dignissimos. Dolor dolorem quo in odio. İpsum impedit repellendus officiis est deserunt libero veniam libero ut.", new TimeSpan(0, 0, 33, 0, 0), "Velit modi quisquam omnis facere." },
                    { new Guid("9d258406-fd36-4318-b973-83a4e6bad95e"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6776), "Veniam voluptatem nihil sed ea autem est aut. Voluptatibus veniam vel libero vel. Aut odit sequi nostrum totam similique nisi rerum dicta dignissimos. Dolorem quo aut. Quis asperiores eveniet fugit delectus recusandae qui. Esse molestias sequi.", new TimeSpan(0, 0, 18, 0, 0), "Quaerat quidem aspernatur vero inventore." },
                    { new Guid("9d944fbd-d5e6-4556-b1c4-06cbb0fccc86"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3280), "Nisi ab id sed dolorem in nisi. Reprehenderit enim est rerum rem. Cumque adipisci blanditiis. Voluptas iure aut iste soluta corporis dolorem. Non hic molestiae dolor illum ut eveniet.", new TimeSpan(0, 0, 22, 0, 0), "Quam laudantium ab velit consequuntur." },
                    { new Guid("a51d7e5d-b8df-4410-b042-e54900f8f2e2"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8698), "Animi id inventore alias qui veniam qui eveniet sunt. Atque enim doloremque sequi iste quisquam molestias aut autem. Expedita dolorem et est. Totam qui minus quam qui tenetur ut et mollitia. Laboriosam qui qui voluptates omnis accusantium id voluptate quia. Est et dolores voluptatem.", new TimeSpan(0, 0, 24, 0, 0), "Rerum labore aliquam corporis magni." },
                    { new Guid("a5c465c3-185d-4c97-b223-e3be643319f5"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5116), "Nemo inventore sed. Omnis optio expedita numquam ipsam et quo nostrum dolor dolores. Voluptatem dignissimos sint quaerat quo expedita tempora. Vel in vitae officiis perspiciatis dolores eligendi impedit illum hic.", new TimeSpan(0, 0, 29, 0, 0), "Cumque est ullam et molestias." },
                    { new Guid("a6e4a2f8-bb59-4658-8147-26ac433d0260"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(310), "Modi quam eveniet nihil porro explicabo. Similique culpa voluptatem est totam aut. İn sed culpa dolor eum excepturi. Quis expedita ullam. Et sapiente sunt illum velit magni ut autem. İnventore temporibus architecto et minus quas provident.", new TimeSpan(0, 0, 35, 0, 0), "Soluta velit error explicabo ex." },
                    { new Guid("a7a67f25-4d79-44c6-be8f-b40be071d5cf"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(742), "Laudantium dolor rerum delectus delectus. İd pariatur dolore est optio ullam ad. Recusandae sint nisi non. Minima officia harum voluptatum nesciunt sequi cumque distinctio. Quia totam cumque sed ipsum. Nesciunt veritatis quam quae quisquam possimus perferendis reiciendis culpa.", new TimeSpan(0, 0, 8, 0, 0), "Velit eius omnis deleniti sunt." },
                    { new Guid("aa379f18-5cb2-4505-9d62-4e2a38953006"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(6552), "Excepturi quia impedit atque excepturi rerum. Consectetur occaecati ipsa et autem. Est laboriosam non aut aut.", new TimeSpan(0, 0, 5, 0, 0), "Consequatur temporibus repellendus voluptatibus qui." },
                    { new Guid("acde7e8b-2d6e-4f76-be92-e935d99e1226"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(4790), "Quis repellendus quo quos maxime mollitia suscipit libero molestiae aliquam. Quis sunt veritatis autem. Quo deleniti non similique. Rerum sit sunt magnam quia. Dolores aliquam et.", new TimeSpan(0, 0, 9, 0, 0), "İn nisi et et quis." },
                    { new Guid("adb01fed-725c-4c25-846a-b64b69520070"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1777), "Voluptatem saepe quo qui qui molestiae dolor tenetur temporibus. Ut numquam deleniti ipsa non aut repudiandae excepturi et. Et sed consequatur. Perferendis quae dolorem tenetur sapiente sapiente quidem animi explicabo eum. Error ut voluptas animi laborum.", new TimeSpan(0, 0, 34, 0, 0), "Natus aspernatur voluptatem corrupti corporis." },
                    { new Guid("b073b660-b4c4-4477-8661-2c9952a44f34"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5521), "Officia amet officiis rerum maxime ratione aut rerum quo. Officia in aut corporis aut. Dolores eius voluptatibus.", new TimeSpan(0, 0, 26, 0, 0), "Error officiis ullam non quia." },
                    { new Guid("b0b41ccb-0c92-4c49-856d-6cdbd325b3b4"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1515), "Eaque cupiditate ex. Necessitatibus perspiciatis qui quos dicta soluta quisquam. Quae inventore enim doloribus quasi quia. Nesciunt neque dolor molestias sint sed reiciendis. Qui animi asperiores aperiam voluptas qui sed nostrum. Laborum deleniti unde porro nulla exercitationem sapiente ducimus.", new TimeSpan(0, 0, 12, 0, 0), "Est ipsa voluptates consequatur odit." },
                    { new Guid("b1be1713-54f3-4d34-bbe6-86594be25b53"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1087), "Voluptate est vel omnis aspernatur. Qui consequatur est aut qui vero sed. Et ducimus unde asperiores ut facere sed.", new TimeSpan(0, 0, 21, 0, 0), "İllum et adipisci voluptatum et." },
                    { new Guid("b2783356-a4a1-4541-8daa-57e0a952b085"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2766), "İusto quaerat accusamus quas placeat. Aut totam sed atque eius. Maiores et soluta distinctio possimus qui aperiam. At beatae ratione fugiat impedit qui facilis quia laudantium tempora.", new TimeSpan(0, 0, 27, 0, 0), "Laudantium ullam et ex mollitia." },
                    { new Guid("b5f4564c-0b7c-427a-ad55-baae717ec800"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(8293), "Molestias reiciendis eos nostrum reprehenderit fuga dolorum autem qui. Accusantium quasi quo eum voluptas. Sit nisi voluptatum hic dolores ut a suscipit. Vel vel similique. Voluptatum omnis iste ut quas.", new TimeSpan(0, 0, 27, 0, 0), "Dolorem repellendus unde cupiditate voluptas." },
                    { new Guid("b9103a7e-4828-4258-86bc-6b90ccfe63b1"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5916), "Nihil provident facere unde sequi et incidunt. İmpedit numquam consequatur commodi cupiditate est. Ut ut recusandae molestias et voluptas veritatis maiores omnis. Adipisci quo repudiandae qui saepe maxime necessitatibus. Et quisquam ipsa.", new TimeSpan(0, 0, 21, 0, 0), "Laboriosam provident similique sed numquam." },
                    { new Guid("b9bb7481-0163-47af-93f4-984ea6ec1ce7"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(7419), "Molestias excepturi quibusdam cumque natus unde ut aut aperiam. İpsum quis quia. Alias ipsam nostrum est in numquam in debitis cupiditate neque. Accusamus suscipit omnis in omnis soluta sunt aliquam.", new TimeSpan(0, 0, 16, 0, 0), "Minima eos veniam quod eos." },
                    { new Guid("ba565823-7b80-402f-b1c8-f7c5dc272588"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1017), "Repellat ab labore neque et blanditiis ipsa adipisci corrupti dicta. İusto dolorem neque. Vero dolorem sed.", new TimeSpan(0, 0, 25, 0, 0), "Quis quia non perspiciatis quas." },
                    { new Guid("bba2936e-3216-4cf3-9bad-724371c1aeaf"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(274), "Dolorum voluptas qui autem quae quo molestiae. Qui sint est deleniti. Facere sit placeat facere cum. Ducimus beatae animi illum excepturi.", new TimeSpan(0, 0, 16, 0, 0), "Nobis ut delectus qui minus." },
                    { new Guid("be951df3-ee17-46a4-a6fd-031cb99a4d97"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(8327), "Recusandae molestias et. Suscipit voluptatum sed praesentium voluptatem. Laudantium quis aliquid temporibus illo nam. Aliquam recusandae explicabo recusandae eius tempore. İste omnis debitis nemo voluptatum nisi et sit iste et. Rerum recusandae itaque quia quisquam aut illum quae vitae eum.", new TimeSpan(0, 0, 18, 0, 0), "Doloribus est omnis fugit eos." },
                    { new Guid("c0ae3748-9791-4609-a64e-7e28ec103ea3"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3431), "Sunt dicta dignissimos corrupti libero similique facilis. Eaque iusto dolore corporis porro voluptas. Quis qui dolor minus officiis quidem iure in dolores. Molestiae quas quia quia eum odit facere. Dignissimos est dolorem a sapiente.", new TimeSpan(0, 0, 32, 0, 0), "Praesentium temporibus sit dolor architecto." },
                    { new Guid("c343566f-b290-4368-9a9d-e403fe6688f1"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7205), "Eligendi omnis similique impedit necessitatibus. Animi odit et excepturi sunt rem repellat. Suscipit est numquam explicabo inventore fuga doloremque odit facilis.", new TimeSpan(0, 0, 23, 0, 0), "Rerum totam nobis quis aut." },
                    { new Guid("c794d723-fcf0-4218-9174-1ea63a8991a1"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(5239), "Eligendi est est sit. Voluptatem eveniet aut. Quasi odio porro sint quo qui molestiae ipsum. İnventore culpa totam sunt.", new TimeSpan(0, 0, 14, 0, 0), "Modi aliquam et laboriosam illum." },
                    { new Guid("c89898b5-6fc1-414d-a85b-f7a3abca1305"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7354), "Aut qui et voluptatum sapiente alias veritatis. Qui rerum voluptatem labore corrupti repellat voluptatem magnam odio. İtaque accusamus dolore reprehenderit suscipit omnis excepturi.", new TimeSpan(0, 0, 24, 0, 0), "Voluptatem sit dolorem rerum in." },
                    { new Guid("cae8bc6f-8db5-4d42-80e3-620592f02e71"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(8534), "Nihil architecto ducimus laboriosam. Ut optio dignissimos eveniet a molestiae sit et sint minus. Mollitia et laudantium cum excepturi repellendus debitis. Rerum veniam veniam molestias. Fugit veniam veritatis vero aut earum ut voluptas deleniti.", new TimeSpan(0, 0, 35, 0, 0), "Perspiciatis sint voluptas est id." },
                    { new Guid("cc77354f-aed8-4cbc-8000-e93194c9c13d"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1293), "Velit dolorem incidunt necessitatibus amet est commodi culpa quam. Et dolorum explicabo laudantium. At quis quo sed officia occaecati eaque deserunt.", new TimeSpan(0, 0, 5, 0, 0), "Quae et rerum cupiditate vel." },
                    { new Guid("d167c35d-d604-4682-b380-72ddae4cd92f"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3990), "Veritatis ipsa voluptatem dolorem velit. Temporibus omnis velit architecto. Odio doloribus maxime est id sed aliquid. Ea laboriosam iusto at. Accusantium optio aut. Dolorum facilis aut.", new TimeSpan(0, 0, 32, 0, 0), "Qui ea animi ab praesentium." },
                    { new Guid("d407f80b-acf1-43c8-a46a-5b7d05933929"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1194), "Dolores et eos repellendus a aliquam deserunt aliquam. Animi est et et magni ut explicabo. Vero et officia et. Maxime est et. Velit nam id ad saepe laudantium.", new TimeSpan(0, 0, 15, 0, 0), "Assumenda quidem minus expedita nemo." },
                    { new Guid("d68e1f97-9734-4f0c-9927-931e1610a8ca"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3589), "Soluta neque dolor debitis voluptate maxime. Nemo suscipit sunt consequuntur voluptatibus. Soluta quisquam rerum. İllo eligendi alias iste cumque. Eius voluptatem et.", new TimeSpan(0, 0, 33, 0, 0), "Quis et eum maxime voluptas." },
                    { new Guid("da2e742a-2145-445b-9714-6086b4e66b23"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(4160), "Quis esse cum iusto in voluptatem quidem est quaerat. Ut qui sit molestiae aut excepturi ut quod provident culpa. Aut eaque consequatur sunt omnis eum quia. Labore nam ab nostrum quia delectus odio illo omnis nihil.", new TimeSpan(0, 0, 21, 0, 0), "Eius molestiae sed error ut." },
                    { new Guid("dc3dd7f7-00ed-4e8b-a5b1-b1416110f6c9"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(2881), "Voluptate voluptas est sint quis. Eaque omnis sint quidem eum saepe. Sit non corrupti tempora voluptatem aut minus ad voluptatem magnam. Tempora fugit voluptatem. Est non quasi sit quos laboriosam consectetur.", new TimeSpan(0, 0, 19, 0, 0), "Eveniet error voluptatem tenetur perferendis." },
                    { new Guid("dfb2e1bf-7ac7-41d1-9548-04753fad1000"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7724), "Perferendis molestiae ex. Consequatur recusandae et ut mollitia. Eveniet optio eligendi consectetur voluptas illum exercitationem id eos inventore. Maiores omnis iusto et a. Doloribus dolorem sit facilis voluptas. Esse deleniti tempora sunt non.", new TimeSpan(0, 0, 10, 0, 0), "Aperiam sed dolorem eos earum." },
                    { new Guid("e27e49b4-90cc-4654-9543-7c7e30fdf6b1"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5214), "Molestiae et eius sint enim. Tempora sit consequatur quas. Quia quisquam molestiae dolorem ipsa consequatur iste est et cumque.", new TimeSpan(0, 0, 33, 0, 0), "Qui aliquid harum error rerum." },
                    { new Guid("e3b0c7c5-1b15-42ce-a273-05f1bb373878"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(2205), "Consequatur aliquid quis numquam. Eius rem qui eveniet nam alias similique laborum dolor et. Voluptas officia quae voluptates mollitia enim. Quasi quam nam.", new TimeSpan(0, 0, 18, 0, 0), "Harum ea alias itaque pariatur." },
                    { new Guid("e446780f-c5ea-489c-9b95-19bfc879e4fc"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9362), "İpsa tempore qui. Sit voluptatem alias. Labore qui eligendi in provident. Voluptates odit autem porro magnam est voluptas laboriosam ut nihil. Ullam voluptate eum architecto unde sint quod laboriosam quas.", new TimeSpan(0, 0, 38, 0, 0), "Numquam aut culpa ducimus quia." },
                    { new Guid("e71f38f1-9386-4aba-996a-d68e771fcfba"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(1186), "Voluptatem corrupti quaerat. Et vel ut dolor voluptatum eaque inventore voluptatem vitae. Autem ipsa dolor sapiente fugiat hic.", new TimeSpan(0, 0, 29, 0, 0), "Ex et sed optio sunt." },
                    { new Guid("e720cf8a-ae14-48b3-afe0-49ae066c95b5"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(9658), "Aliquid doloremque magnam est placeat dolor magni sint. Accusamus totam perspiciatis quia rerum consequuntur dolor adipisci dolor. Ut quis quo laborum ducimus tenetur odit enim voluptatem.", new TimeSpan(0, 0, 19, 0, 0), "Cumque corporis modi ipsam nisi." },
                    { new Guid("e7483b45-a669-420e-bbd4-d5f19c9354de"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(7747), "Sint ut aut odio. Minima quaerat dicta quia. Sit consequatur et et vitae dignissimos fugit. Vel et excepturi molestias. İtaque ullam neque.", new TimeSpan(0, 0, 22, 0, 0), "Qui voluptate odio explicabo sit." },
                    { new Guid("ec8d96c0-3d21-4f3d-a9d7-b92d47eb9981"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3689), "Voluptatem reiciendis nesciunt nihil cumque. Ut consectetur corporis aut recusandae molestias totam et. Sit eum sunt maxime est eum.", new TimeSpan(0, 0, 30, 0, 0), "Esse et et magni aut." },
                    { new Guid("ee44ffe9-26fe-4cb0-8f7e-eb6bfc2c2a35"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(7854), "Cum cum qui inventore. Aut est ipsa ipsam sapiente neque at nihil facere. Nulla voluptas doloribus omnis voluptates ea. Expedita architecto numquam veniam incidunt quod quibusdam nam. İd sunt et sequi id quia voluptas ex. Molestiae voluptas quia repellat ad.", new TimeSpan(0, 0, 32, 0, 0), "Maxime ut illum quam commodi." },
                    { new Guid("f3686de1-14b0-41ae-a1e9-0db2f5c2ae76"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3422), "Magni omnis sit qui. Quas maxime repellendus accusamus eos iure voluptatem qui. Ut neque id quod similique praesentium qui necessitatibus. Quos omnis eum repudiandae possimus molestiae magnam tempora et odio. Possimus provident laboriosam minima aspernatur facilis.", new TimeSpan(0, 0, 24, 0, 0), "Magnam architecto ut est quis." },
                    { new Guid("f68ced40-b04e-40f7-bd4a-3429e638009a"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(1), "Velit dolor voluptatem ex. Possimus nisi quo possimus velit totam. Voluptatum et accusantium et animi voluptas dolores quaerat. Molestias et natus aut nam quod assumenda. Quaerat beatae et nihil culpa id est explicabo veniam.", new TimeSpan(0, 0, 24, 0, 0), "Aut doloribus libero eius aut." },
                    { new Guid("f7033a99-13b3-4fcd-b20f-156757ab49f6"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(8332), "Maxime aliquid qui nesciunt. Et deserunt nostrum. Harum molestiae et quis quasi et et reprehenderit quos fugiat. Perspiciatis voluptatem architecto explicabo omnis iste vero. Sit vel qui animi in alias laboriosam. Cumque sint non tempore quo eius reiciendis.", new TimeSpan(0, 0, 11, 0, 0), "Adipisci enim minima expedita cum." },
                    { new Guid("f7a03c71-b04f-45cf-9fcb-1b83101697ab"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(7092), "Nostrum ut doloribus. İn voluptate et debitis ut est saepe accusantium. Soluta dignissimos assumenda quod sit sint qui. Et ratione officiis sunt.", new TimeSpan(0, 0, 38, 0, 0), "Assumenda ipsam voluptas quo dolores." },
                    { new Guid("f81b3f83-4d4a-4f57-bcb1-7f527804f1c5"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 2, 23, 13, 27, 569, DateTimeKind.Local).AddTicks(9513), "Quibusdam itaque eum consectetur delectus quaerat consequuntur quos explicabo qui. Sit suscipit illo veniam dolorem. Qui recusandae inventore velit.", new TimeSpan(0, 0, 35, 0, 0), "Exercitationem ab id est et." },
                    { new Guid("fb05cc98-2d1d-4a05-8dff-20f12570301c"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(3259), "Ex eum rem. Ut quo veniam. Rerum quia facilis nostrum officia iste quae. Molestiae et id animi consequatur iste occaecati dicta amet ipsam. Commodi hic consequatur.", new TimeSpan(0, 0, 23, 0, 0), "Quaerat saepe et et rem." },
                    { new Guid("fbe4a0fa-e303-4653-b87a-75b2e9ac0b59"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 2, 23, 13, 27, 571, DateTimeKind.Local).AddTicks(3863), "Dolores molestiae dolorem deleniti iste dolorem. Hic aut eveniet consectetur esse. Consequatur et vel non non blanditiis inventore cumque. Ratione laborum quasi velit modi quasi est quisquam at error.", new TimeSpan(0, 0, 23, 0, 0), "İtaque sunt nisi sunt laborum." },
                    { new Guid("fc529f4f-da88-40fd-ba2b-0ba70ae1743f"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 2, 23, 13, 27, 570, DateTimeKind.Local).AddTicks(5503), "Repellendus soluta deserunt facere sunt qui laborum nobis sed quo. Molestiae totam et dicta eum. Voluptatem numquam illum eligendi quaerat et sed eligendi placeat. Aspernatur tempora molestiae est nesciunt eos adipisci.", new TimeSpan(0, 0, 16, 0, 0), "İd sed et et quia." }
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
                name: "IX_Content_CourseId",
                table: "Content",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

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
                name: "Content");

            migrationBuilder.DropTable(
                name: "Notifications");

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
