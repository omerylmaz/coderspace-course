using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finished_project : Migration
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
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_AspNetUsers_UserId",
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
                    { new Guid("2d8651fd-3800-48da-a85c-f294282b5180"), 0, "1dbc16db-059f-46f4-bbcd-fcc9ec0901a9", "user4@gmail.com", false, "Kerem Aktürkoğlu", false, null, "USER4@GMAIL.COM", "KEREMTURK", "AQAAAAIAAYagAAAAELCGOI/sssGr1NMZp3b2NtyZgeS1SsMiu1XDEcHwo3w4Q4W1nqBigZwYXrhmIQFbsA==", "5554445566", false, "89e66a72-a975-42b3-94d4-b91621a3af7c", false, "keremturk" },
                    { new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"), 0, "94f240b3-59fd-4147-8650-6d5883860fa9", "user5@gmail.com", false, "Victor Osimhen", false, null, "USER5@GMAIL.COM", "OSIMHEN", "AQAAAAIAAYagAAAAEIcpgKRgbo4PkZxU8vIdh6ruOPO7Yu3aoJZ6CgDzELF+OI1z123YwJEPXcAIiG9a/w==", "5555556677", false, "1ab81d94-1dd3-4915-95b9-77d92049f9b4", false, "osimhen" },
                    { new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), 0, "03291dcf-d927-4db4-994a-f7423b5c7a2f", "teacher1@gmail.com", false, "Ahmet Kaya", false, null, "TEACHER1@GMAIL.COM", "AHMETKAYA", "AQAAAAIAAYagAAAAEChNdY7zwJXlo10rb2elB87hJtOYm8SOEAW1jwhXzXUDWLJkvnv69lqJVhT2JVDPCQ==", "5556667788", false, "6f7cf2e8-1788-4622-884b-4464f449821b", false, "ahmetkaya" },
                    { new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"), 0, "3eb5083e-2224-458c-8142-2d7776e89f5f", "user3@gmail.com", false, "Kıvanç Tatlıtuğ", false, null, "USER3@GMAIL.COM", "KIVANCTATLI", "AQAAAAIAAYagAAAAEPTaHAN0oN5ak7nZ9SU3qeOwc4umi43bf9D6Nbwj0wwhyFibhlnCj0JKDpTw6nRDuA==", "5553334455", false, "c88297bc-36bf-400d-8ec1-41a82585927b", false, "kivanctatli" },
                    { new Guid("54039b1c-f914-4171-97a8-f78a9c107935"), 0, "04e60c83-7ca3-40ea-8f9e-b9ae0b8b94cd", "user2@gmail.com", false, "Okan Buruk", false, null, "USER2@GMAIL.COM", "OKANBURUK", "AQAAAAIAAYagAAAAEFOaz7PEiNoEqRkQClYogRpV+VWg4Zuf9D+V/buZ95iEZnjzRY+MwyHIqCKj8c9VvQ==", "5552223344", false, "b1c06737-f295-49ce-8ac9-a1efa5a96843", false, "okanburuk" },
                    { new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"), 0, "b3770f7b-dd65-4626-869c-1b39cf6a33f6", "user1@gmail.com", false, "Ömer Yılmaz", false, null, "USER1@GMAIL.COM", "OMERYILMAZ", "AQAAAAIAAYagAAAAEOfuGK3SrQfI5L35u0VwDhQuoUVwTRB3AuIIkrjZOSooJ5wAIZglm9gLGHZ3THFafw==", "5551112233", false, "332df285-627c-44be-b5c0-2f62932e25a1", false, "omeryilmaz" },
                    { new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), 0, "b7ee716e-8931-45e3-827b-df81fb2eea50", "teacher2@gmail.com", false, "Fatih Çakıroğlu", false, null, "TEACHER2@GMAIL.COM", "FATIHCAMIR", "AQAAAAIAAYagAAAAEF5HSVr+Qx4GAQKDC/LDOW7gP2Te8KLpd6FpQ5/K4hPErT9clsylcz1si4xlV4g4Ow==", "5557778899", false, "44c39c80-c997-44cf-841f-82abbff9b79d", false, "fatihcakiroglu" },
                    { new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), 0, "7c06a858-483a-43c7-a863-685eb1950f2c", "teacher3@gmail.com", false, "Şadi Evren Şeker", false, null, "TEACHER3@GMAIL.COM", "SADIEVRENSEKER", "AQAAAAIAAYagAAAAEIuOFg/oe1ilbipF2FkH32AL9nTnoAZUMkrj9qm2c6iJMYMhub/Bogj4r3vP6x2Z9w==", "5558889900", false, "975bbe18-006e-4baf-be6c-4ca31f315bc0", false, "sadievrenseker" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9261), "Software" },
                    { new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9274), "Finance" },
                    { new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9272), "Project Management" },
                    { new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9278), "Lifestyle" },
                    { new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9271), "Marketing" },
                    { new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9269), "Design" },
                    { new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(2025, 1, 5, 22, 9, 44, 786, DateTimeKind.Local).AddTicks(9280), "Photography" }
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
                    { new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2972), "Learn the best SEO practices to rank higher in search engine results and attract more traffic.", "https://images.unsplash.com/photo-1562577309-2592ab84b1bc?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "SEO Mastery", 179.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Boost your website's SEO" },
                    { new Guid("1d9a5bcd-2390-4f8e-92c3-d23a5bcd2391"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2978), "Learn React, Angular, and Vue.js to build complex and interactive web applications.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Frontend Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced frontend technologies" },
                    { new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2982), "Master microservices development and deployment with .NET and Docker.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Microservices with .NET", 189.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Develop microservices architecture" },
                    { new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2974), "Learn how to create and promote your personal brand to stand out in your industry.", "https://plus.unsplash.com/premium_photo-1683543124615-fb42e42c6201?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Branding", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build your personal brand" },
                    { new Guid("2d8b5cfa-3441-4b9a-832b-d23a6c9d1342"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2978), "Learn advanced techniques for 3D game development, including physics and AI integration in Unity.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Advanced Game Mechanics", 199.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master advanced Unity game development" },
                    { new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2981), "Learn to implement robust security practices in ASP.NET Core applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "ASP.NET Core Security", 169.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Secure your web applications" },
                    { new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2973), "Explore Agile project management techniques to deliver successful projects on time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Agile Project Management", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master Agile methodologies" },
                    { new Guid("3e7c5dfb-7892-4c9a-913b-e45b8c9d1343"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2979), "Learn how to design and build responsive websites using CSS, Flexbox, and Grid Layout.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Responsive Web Design", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Create beautiful responsive websites" },
                    { new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2981), "Learn how to build, secure, and optimize APIs using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Building APIs with .NET Core", 139.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Create robust and efficient APIs" },
                    { new Guid("4f6d7cfb-6783-4d9a-91b4-f56d8c9d1344"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2979), "Learn JavaScript from scratch, including variables, functions, and DOM manipulation.", "https://upload.wikimedia.org/wikipedia/commons/a/a4/JavaScript_code.png", "JavaScript for Beginners", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master the fundamentals of JavaScript" },
                    { new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2974), "Learn the art of photography, including composition, lighting, and camera settings.", "https://images.unsplash.com/photo-1524037992922-3a0937719e1d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Photography Basics", 79.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Capture stunning photos" },
                    { new Guid("5f7e8cfb-8914-4e9a-92c5-167e9d9d1345"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2980), "Master complex CSS concepts like animations, transitions, and preprocessors like SASS and LESS.", "https://cdn.prod.website-files.com/6097e0eca1e875de53031ff6/66b344b75c2572d16bb65242_66b343c191fd4cea42793a3a_image%2520-%25202024-08-07T125129.064.png", "CSS Mastery", 109.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Advanced CSS techniques" },
                    { new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2972), "Discover the tools and techniques to create stunning vector designs using Adobe Illustrator.", "https://images.unsplash.com/photo-1526485797145-514b2fe83749?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Illustrator Essentials", 99.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn Adobe Illustrator from scratch" },
                    { new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2973), "Understand the principles of investing and learn how to grow your wealth over time.", "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Investing for Beginners", 89.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn the basics of investing" },
                    { new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2966), "This course covers the fundamentals of C# programming, including syntax, classes, and objects.", "https://code.visualstudio.com/assets/docs/languages/csharp/csharp-hero.png", "Introduction to C# Programming", 99.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn the basics of C# programming" },
                    { new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2976), "Learn how to craft compelling stories and improve your writing skills.", "https://images.unsplash.com/photo-1617575521317-d2974f3b56d2?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Creative Writing", 109.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master the art of storytelling" },
                    { new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2977), "Learn to create 2D and 3D games using the Unity engine and C# scripting.", "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp", "Unity Game Development", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Build games with Unity" },
                    { new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2974), "Discover the principles of graphic design and how to create eye-catching visuals.", "https://images.unsplash.com/photo-1432888498266-38ffec3eaf0a?q=80&w=2074&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Graphic Design Fundamentals", 119.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn the basics of graphic design" },
                    { new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2977), "Learn to build responsive and interactive web pages using modern frontend technologies.", "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Frontend Development Essentials", 129.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master HTML, CSS, and JavaScript" },
                    { new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2971), "This course covers essential project management techniques and tools for successful project execution.", "https://plus.unsplash.com/premium_photo-1726743809701-67e8600f7670?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Project Management Essentials", 119.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Learn to manage projects effectively" },
                    { new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2978), "Learn to create high-performance web APIs and applications using .NET Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", ".NET Core Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master .NET Core and build robust APIs" },
                    { new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2976), "Learn the skills needed to speak confidently and effectively in front of an audience.", "https://plus.unsplash.com/premium_photo-1661780400751-e8e9a09ba7b1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Public Speaking Confidence", 89.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Speak confidently in public" },
                    { new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2981), "Learn advanced techniques for working with databases using Entity Framework Core.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Entity Framework Core Mastery", 149.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master data access with EF Core" },
                    { new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2975), "Learn data analysis, visualization, and machine learning basics with Python.", "https://plus.unsplash.com/premium_photo-1714618831065-8e8dadd8d3df?q=80&w=1800&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Introduction to Data Science", 199.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Explore the world of data science" },
                    { new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2970), "This course provides an introduction to digital marketing, covering SEO, social media, and email marketing.", "https://plus.unsplash.com/premium_photo-1661425715124-310ec1b49b8a?q=80&w=1882&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Digital Marketing 101", 199.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Learn digital marketing strategies" },
                    { new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2971), "This course dives into advanced Python topics, including data structures, algorithms, and performance optimization.", "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Advanced Python Programming", 129.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Master advanced Python concepts" },
                    { new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2970), "Learn the key principles of UI/UX design to create user-friendly and visually appealing designs.", "https://plus.unsplash.com/premium_photo-1733306548826-95daff988ae6?q=80&w=1824&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "UI/UX Design Principles", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Master UI/UX design fundamentals" },
                    { new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2971), "Learn the basics of personal finance, including budgeting, saving, and investing.", "https://plus.unsplash.com/premium_photo-1663100794696-6b7afa02016c?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Personal Finance Basics", 79.99m, new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"), "Manage your finances effectively" },
                    { new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2975), "Master the tools and techniques needed to analyze financial statements and make better decisions.", "https://plus.unsplash.com/premium_photo-1661418553375-5ea448f11f34?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Financial Analysis Basics", 149.99m, new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"), "Learn financial analysis techniques" },
                    { new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(2980), "Master advanced .NET Core features to develop scalable and secure backend applications.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s", "Advanced .NET Backend Development", 159.99m, new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), "Build enterprise-level backend systems" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedDate", "IsRead", "Message", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("09792dcb-30d9-4e15-b51e-b29f34e883fa"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4278), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8") },
                    { new Guid("0a485cff-2325-4aab-868f-7efe7f7bc050"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4287), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9") },
                    { new Guid("171f8ca7-fef8-4ed1-886b-291bfb53c1a0"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4308), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("2a4ac3d0-3bb4-4e77-90b3-79486df3a877"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4321), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("2edf533b-a2b7-4364-8190-b371b1c8cf43"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4276), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8") },
                    { new Guid("2f01ae8b-48b6-4310-bb09-91c38d003d6e"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4252), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("3ab1ba97-bf62-42fa-bb30-890fff6c9dad"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4316), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("3bda6362-5a06-46ab-b371-955131ca9bbb"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4324), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("2d8651fd-3800-48da-a85c-f294282b5180") },
                    { new Guid("3d38eca9-37ea-4fb6-8ade-67afe7097de4"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4267), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("3f59ddf6-038f-4af9-a3ba-7a8ac1dc32e0"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4326), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("2d8651fd-3800-48da-a85c-f294282b5180") },
                    { new Guid("495b2e52-326f-4408-a27a-33ee61c06c41"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4264), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("662ab6cf-6809-40e0-9ac0-fb3a2e46e448"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4319), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("672b252f-ee50-4517-92bd-145431c6daf2"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4295), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("54039b1c-f914-4171-97a8-f78a9c107935") },
                    { new Guid("69256799-6b11-42a3-933b-c8774b1ffbfe"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4261), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("6ed1677c-b975-4897-9c24-8a713d86d73d"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4302), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27") },
                    { new Guid("75e00741-7027-4745-8e55-b2849e47e91f"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4292), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("2d8651fd-3800-48da-a85c-f294282b5180") },
                    { new Guid("958078ae-b9f2-4bda-a4ac-ba667f4ec21a"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4297), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("54039b1c-f914-4171-97a8-f78a9c107935") },
                    { new Guid("ca540251-71fe-4cd1-bb79-cfff4bc02aed"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4300), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27") },
                    { new Guid("d2f33f6c-643e-4473-ba55-fdd7eda2a829"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4289), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("2d8651fd-3800-48da-a85c-f294282b5180") },
                    { new Guid("db3f9ce7-5f52-478f-a5da-139a1b14da22"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4273), true, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9") },
                    { new Guid("dda3b19e-37b8-434b-9ae5-427481f5a07f"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4284), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9") },
                    { new Guid("e6d481ef-877d-441e-92f5-689f7fb76859"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4311), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b") },
                    { new Guid("f05edd9a-d0bc-4d51-95fa-6a38c48bc470"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4314), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("f482f1bb-67f2-4bb7-88e8-e0f9a206e4e2"), new DateTime(2025, 1, 5, 22, 9, 44, 785, DateTimeKind.Local).AddTicks(4269), false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9") }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "CourseId", "CreatedDate", "Description", "Duration", "Title" },
                values: new object[,]
                {
                    { new Guid("0134fe8c-9925-459c-90c3-9a0e3cffc54f"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4321), "Atque laborum et voluptas harum molestias unde repellendus accusamus illum. Voluptas qui officia est ullam eligendi nobis voluptas sit reprehenderit. Excepturi nemo aperiam autem.", new TimeSpan(0, 0, 11, 0, 0), "Saepe molestias minus et soluta." },
                    { new Guid("027799f9-88e6-4101-94b0-adbdb952ebb7"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(27), "Est itaque ut aliquam eum doloremque amet. Aut quo quo praesentium. Ut et praesentium tempora eaque iste.", new TimeSpan(0, 0, 40, 0, 0), "Rerum debitis molestiae tempora quia." },
                    { new Guid("0372bcf0-a042-4e20-9c54-dd8779fed70b"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5942), "Quis quisquam aliquam eveniet quasi accusantium qui dolorem voluptas quia. Accusamus nulla ducimus est qui atque delectus sit eius. Modi fugit totam.", new TimeSpan(0, 0, 27, 0, 0), "Accusamus blanditiis nisi laborum consectetur." },
                    { new Guid("039d8129-062f-48bf-9728-6a7a13022035"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1822), "Voluptatum dolorem sed exercitationem delectus odio atque eum pariatur. Eveniet minus dicta quasi. Reprehenderit odio eligendi rerum explicabo non. Sit dolorum earum. Placeat qui in labore quia harum odio non aut sapiente. Dolor dolorem odit architecto eligendi est illum.", new TimeSpan(0, 0, 32, 0, 0), "Explicabo architecto incidunt molestias iure." },
                    { new Guid("0894722e-06e4-4d2b-8dde-e81076bcdd08"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(351), "Mollitia doloremque dolore. Architecto iste culpa quos deserunt suscipit magnam. Consequatur itaque adipisci velit perferendis et et tenetur. İpsam sit dolores mollitia rerum consequuntur vel reprehenderit. Perferendis quis qui deleniti alias occaecati molestias voluptatum deleniti ea.", new TimeSpan(0, 0, 25, 0, 0), "İpsam vero neque natus consequuntur." },
                    { new Guid("0a62df5d-cce2-44da-95c4-fbba9f942770"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2426), "İd ipsa iusto qui aut et. Earum incidunt quos at velit eius. Consequatur est possimus. Aut voluptatem eveniet doloremque asperiores.", new TimeSpan(0, 0, 11, 0, 0), "Quia consequatur temporibus tempora dolorem." },
                    { new Guid("0abc2897-febb-4e28-a77e-f44ece0d276b"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8918), "Voluptatem odio minus dicta hic modi dicta eum. Similique nostrum voluptatem officiis autem. Excepturi odit velit aut numquam. Officiis adipisci laborum in molestiae accusamus quisquam aliquid officia ea.", new TimeSpan(0, 0, 13, 0, 0), "Dolorem recusandae temporibus laudantium fugit." },
                    { new Guid("0b47bcfe-28e3-4708-8003-72b9c95e17e9"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3694), "Officia non et enim magnam doloribus et. İnventore qui et. Quia ab velit deleniti. Vel iusto sint.", new TimeSpan(0, 0, 33, 0, 0), "Quis error aut et velit." },
                    { new Guid("0c3362e9-3da7-45ba-add6-17a70504d92f"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6375), "İure non fugiat corporis ut est consequatur. İncidunt voluptas ex veritatis quis amet maxime corporis sit aut. Commodi earum sint nemo cumque illo sint repellendus. Voluptate neque quisquam consectetur occaecati. Sequi quia totam rerum.", new TimeSpan(0, 0, 37, 0, 0), "Praesentium quod dolorem omnis non." },
                    { new Guid("0de1706c-278f-4d24-9c63-952b2393112c"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4891), "Quis eius officiis aliquam non. Accusamus maxime non vitae sit et rerum expedita voluptatem. Aliquid earum possimus. Voluptatem et vitae voluptatem at molestias perferendis.", new TimeSpan(0, 0, 18, 0, 0), "Ullam sit incidunt doloribus accusantium." },
                    { new Guid("0de3982d-43b9-4754-87ff-73283fce8ea7"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9817), "Rerum totam amet voluptatibus. Quas officiis iure ducimus quo aut iusto dolore voluptatem. Ut iusto doloribus qui quis voluptatem sit. Deserunt iusto nam nisi totam ratione. Adipisci aliquid rerum voluptas est. Doloribus est quia.", new TimeSpan(0, 0, 10, 0, 0), "Libero pariatur harum inventore veniam." },
                    { new Guid("0e6304fa-698d-4097-9f8a-1b1246a5d5ca"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8788), "Tempora qui quasi inventore quis labore voluptatem sint assumenda ut. Quia quidem asperiores fugiat ea maxime eos mollitia. İusto aut voluptatum voluptas molestiae dolorum in eos ipsam voluptatum.", new TimeSpan(0, 0, 25, 0, 0), "Laboriosam voluptates quia velit ipsam." },
                    { new Guid("0ffdf793-3e4a-49e1-a7e3-7ae35d06641a"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(7705), "Vero corrupti quaerat hic repellat odit commodi. Cupiditate veritatis vel quia laboriosam. Molestiae enim blanditiis sit autem beatae et odio.", new TimeSpan(0, 0, 25, 0, 0), "Ut sit sequi dolore accusamus." },
                    { new Guid("11979652-04a5-4467-953d-0088f977f71f"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9238), "Asperiores corrupti ea ut ducimus nemo porro. Sed qui maxime voluptates voluptatem et. Alias temporibus ab amet qui est ut quibusdam ab.", new TimeSpan(0, 0, 37, 0, 0), "Voluptatem repudiandae velit ea cupiditate." },
                    { new Guid("1328b321-e24c-4dda-b9ff-5d44d18f2e46"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4209), "Enim officiis facere ut vel est ut voluptatem. Ab incidunt molestias voluptatem vitae nesciunt. Nulla dolore magni quam. Cumque maxime ut et ut est animi dolore repellat. Recusandae est maxime est. Alias aut aut non beatae.", new TimeSpan(0, 0, 30, 0, 0), "Libero aperiam magni et unde." },
                    { new Guid("1743242b-96f1-4210-8b82-1cf597b9d8be"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(6022), "Et nihil autem soluta placeat. Vitae quis ratione dolores rerum. Voluptates alias minus cumque. Quis voluptatibus sapiente dolorem. Et corporis vel qui a voluptatem.", new TimeSpan(0, 0, 6, 0, 0), "Quia nobis quaerat sed libero." },
                    { new Guid("1a123c8e-d293-49cd-9896-b806a8babdf1"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1527), "Cupiditate nihil ratione quia exercitationem labore fugiat quas. Ullam eius totam maiores. Voluptate fuga similique. Et et voluptatem rerum iste inventore omnis dolor quis sunt. Ab ducimus excepturi quo. Dolor error quibusdam eaque.", new TimeSpan(0, 0, 8, 0, 0), "Eos quia consequatur occaecati eveniet." },
                    { new Guid("1b84fc95-0cb4-4613-b569-03b703e6ce7d"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5900), "Architecto magni eius. Perferendis eveniet vero aspernatur. Eveniet aut id nobis. Repellendus mollitia totam distinctio quam eos. Quidem facilis reprehenderit. Doloribus dolor quis consequuntur possimus et eum.", new TimeSpan(0, 0, 24, 0, 0), "Perferendis ullam ut voluptates ducimus." },
                    { new Guid("21f11261-2b13-4345-8f78-540b0b9f48db"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9369), "Omnis commodi rerum esse pariatur. İure culpa in id voluptatum repellat aspernatur. Quasi ipsa facere delectus. Quaerat voluptatem et quisquam molestiae. Eos quos est et optio unde.", new TimeSpan(0, 0, 12, 0, 0), "Vero dolores accusantium praesentium consequatur." },
                    { new Guid("22bf1d03-33e2-4164-9560-b1a386cd735b"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1821), "Sit ea nihil fuga inventore aut. Distinctio minus quas autem autem et deserunt ullam expedita quibusdam. Consequatur quo ipsam magni unde quas dolor eligendi et qui.", new TimeSpan(0, 0, 32, 0, 0), "Numquam doloribus dicta saepe illum." },
                    { new Guid("22f418cb-7af8-4dac-9c3a-5b33f6d66813"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6823), "Necessitatibus eos voluptas repudiandae error delectus quia quaerat quasi repudiandae. Quis enim ut placeat accusamus temporibus ex et aperiam eaque. Praesentium fuga quo repellat consequatur natus assumenda. Doloribus qui rerum est hic aut eligendi soluta rem.", new TimeSpan(0, 0, 37, 0, 0), "Reiciendis harum explicabo cupiditate facilis." },
                    { new Guid("25d00fc0-8c8a-4805-a7fc-465c41976de3"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7294), "Omnis culpa architecto consequatur ullam aut accusantium nemo. Facere omnis rem eum minus officiis qui illo veritatis occaecati. Non recusandae illum vel est cupiditate molestiae.", new TimeSpan(0, 0, 5, 0, 0), "Adipisci aliquid qui ipsam eum." },
                    { new Guid("2628841c-c362-4e6f-abe3-815aad499929"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9667), "Qui fugit vel nostrum optio magnam id. Facilis iusto illo neque iure veniam et nam. Ut veniam minima veritatis. Porro culpa tenetur adipisci placeat voluptatem nihil aliquam. Eaque quasi ad omnis.", new TimeSpan(0, 0, 13, 0, 0), "Qui vel sint quia et." },
                    { new Guid("2955d6fb-9507-4202-97a9-e5bd80b0473f"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(3099), "Quis est fugiat est quam iure voluptatum eligendi unde. Cupiditate minus veritatis qui quo cum cupiditate recusandae. Omnis est illum. Rem molestias quis saepe consequatur nostrum excepturi voluptate.", new TimeSpan(0, 0, 29, 0, 0), "Aut aut ducimus rerum sapiente." },
                    { new Guid("29b9f514-028b-4075-b15e-022368c37082"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1255), "Est praesentium deserunt delectus et placeat laboriosam natus qui et. Et numquam molestiae qui debitis. İnventore laborum consectetur quae ad voluptas quo sit. Qui quidem possimus possimus cumque molestiae quo quaerat aut sequi. Velit accusantium pariatur omnis voluptatum magni. Animi aut vitae quasi at qui accusamus.", new TimeSpan(0, 0, 27, 0, 0), "Dolor ipsa voluptates inventore quia." },
                    { new Guid("2d75b5ed-3a7e-4b11-a2a7-95b8c25a5e0b"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2146), "Officia repellat voluptas eaque. Architecto illum molestias quibusdam laudantium nihil sed dolor voluptas dolorum. Minima ducimus molestiae eos voluptatem soluta quidem debitis. Consequuntur magnam sed vero illum optio aperiam esse tempore ipsa. Eveniet optio non a incidunt. Ut et recusandae voluptas laboriosam incidunt modi.", new TimeSpan(0, 0, 15, 0, 0), "İusto inventore qui modi veniam." },
                    { new Guid("32059f83-957e-4be5-9116-83d49ddf39d6"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(3283), "Fugit ex eius eos quibusdam. Nihil eum qui et expedita placeat officia nihil non ut. Quia ut est quia consequatur debitis quaerat nihil quis. Quisquam temporibus cupiditate et dolores accusamus et eligendi ut. Nisi itaque omnis occaecati ipsa iste sit illum itaque. Qui aliquid aliquid.", new TimeSpan(0, 0, 16, 0, 0), "Nisi reiciendis natus non dolor." },
                    { new Guid("34ac4c9a-0132-4c96-a411-9102a14c31b1"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5841), "Omnis occaecati quam porro reiciendis quibusdam placeat. Laudantium quasi rerum omnis rerum quia qui atque non consequatur. Aspernatur dolores quia delectus eligendi ad quia neque. İd quibusdam vel sit est. Architecto quas sequi voluptas.", new TimeSpan(0, 0, 35, 0, 0), "Dignissimos porro sequi quia illum." },
                    { new Guid("35def87c-887a-48e7-8db9-5da5bceac165"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(99), "Excepturi incidunt rem id in quisquam voluptatibus praesentium aut est. Dolor totam occaecati minima tempora. Pariatur dolore eius quae. Sit voluptatibus quo ipsum dolore mollitia quibusdam molestiae autem voluptatem. Voluptas aliquid illum eum esse commodi laborum. İusto aut ut laboriosam.", new TimeSpan(0, 0, 21, 0, 0), "Quas dignissimos est dolorem dignissimos." },
                    { new Guid("399765d3-bce1-482a-b071-7d26242e3833"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8462), "Fugit reiciendis non. Aut laboriosam amet est ut voluptates ut. Aut suscipit voluptatem iste veniam iste nisi ratione. Asperiores quia similique repellat est omnis qui similique consequatur. Quidem id velit atque ullam. Dolor dolorem accusantium ut soluta velit aliquid.", new TimeSpan(0, 0, 8, 0, 0), "Molestiae non sunt architecto ea." },
                    { new Guid("3b10924d-1b55-4a61-8da0-024ccb2dd234"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(199), "Fuga in iste possimus. Molestiae consequatur repellat quo et omnis sint iste aut est. Quam incidunt rerum similique aspernatur non aliquam deserunt et est. Error sunt quos perspiciatis sed exercitationem molestias ratione.", new TimeSpan(0, 0, 32, 0, 0), "Voluptatem dolores soluta unde iste." },
                    { new Guid("403656b3-a456-4b39-8bde-938fb3509c77"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(7549), "Enim corporis totam. Culpa tempora ut dolor dolores est. Laborum iure ullam fugiat et non atque quia in. Quia aspernatur amet id ut distinctio. Modi assumenda illum molestiae incidunt quibusdam dolores molestiae suscipit ut.", new TimeSpan(0, 0, 23, 0, 0), "Labore quis commodi nulla eum." },
                    { new Guid("42fa4ffd-583e-4f57-b5e6-ed50581f45ba"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4891), "Velit odio pariatur praesentium quia ab libero aperiam rerum quos. Omnis vero officiis eveniet omnis ratione et sunt. Voluptatum qui quaerat commodi voluptas voluptate ut. Optio natus asperiores impedit est eos.", new TimeSpan(0, 0, 12, 0, 0), "İtaque quis esse aliquid aliquam." },
                    { new Guid("482ad518-088c-4eb4-95d8-bb50f0b09690"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4429), "Doloribus eligendi eos ducimus est modi. Vel animi sunt hic temporibus enim rerum possimus quia rerum. Labore animi dolorem quasi porro rem ut. Voluptatum blanditiis esse. Qui dolor qui in dolor. Rem iste facilis quaerat magni distinctio culpa.", new TimeSpan(0, 0, 36, 0, 0), "Libero quidem incidunt assumenda iure." },
                    { new Guid("495dab1a-1d15-469b-87d1-757bb7ee8c59"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4624), "Labore minima id et ut id dolor. Qui quaerat voluptas voluptatem cum necessitatibus. Et omnis delectus fuga exercitationem possimus sint. Nobis ipsum et ea dolorem praesentium accusamus. Harum cupiditate harum ut exercitationem.", new TimeSpan(0, 0, 13, 0, 0), "Quas earum aut quisquam sed." },
                    { new Guid("49959580-fa63-4549-a596-77df4a340d3b"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5658), "Sit sed deserunt dolore error sapiente. Qui repellat quia beatae totam quae quasi tenetur facere est. Labore maiores et architecto esse iste minus. Quos voluptatem itaque est aut error.", new TimeSpan(0, 0, 13, 0, 0), "Et ipsum enim qui voluptatem." },
                    { new Guid("4a908416-82d6-40ca-9585-f8e2747a130b"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4026), "Qui reiciendis sit quis consequatur nihil. Maiores eum sit placeat iste. Expedita nobis consequuntur iusto eum quaerat. Animi fuga aspernatur beatae. Velit ea sit voluptate ducimus sunt inventore recusandae earum non.", new TimeSpan(0, 0, 18, 0, 0), "Enim ratione dolores eaque id." },
                    { new Guid("4ae44d12-bc4a-4b73-93cb-08636d7dd90c"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4579), "Nam porro consequatur. Reiciendis ut aspernatur. Consequatur fugit quaerat molestias minus. Autem id culpa voluptatem ut repellat.", new TimeSpan(0, 0, 39, 0, 0), "Libero hic debitis modi hic." },
                    { new Guid("4c1d548c-62ac-417e-98d7-0357a332bc55"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8139), "Ullam officiis neque dolores nemo laudantium repellat aliquam. Cum omnis dolore sit est iste. Reiciendis non harum alias id tempora quo ut dolorum dolore. Temporibus sunt voluptatem harum autem dignissimos delectus consequatur consequuntur. Ut consequatur odit facilis facilis cumque corporis corrupti tempora magnam.", new TimeSpan(0, 0, 21, 0, 0), "Sed magnam ipsa vitae eaque." },
                    { new Guid("4d8b26a3-e583-4d04-b649-649b2ef5c725"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(945), "Recusandae aliquam quae rem ut est quia officiis saepe. Neque et vitae eaque minus qui. Modi consectetur repellendus aperiam. Quam commodi earum sint vitae voluptas voluptatem veniam. Odio quia deserunt. İncidunt quas officiis velit.", new TimeSpan(0, 0, 8, 0, 0), "Dicta qui non laborum aut." },
                    { new Guid("4df601c1-7ddc-4698-99a0-2d7ed6dd98d4"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5532), "Rerum velit autem. Animi aut dignissimos quia in autem distinctio delectus. Est et est rerum autem nam nisi. Doloribus eos fugiat sint quia doloribus veritatis corrupti ea est.", new TimeSpan(0, 0, 8, 0, 0), "Numquam architecto excepturi explicabo alias." },
                    { new Guid("524167e8-b0fc-449d-9672-c2b8484c4bb1"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9367), "Facere cumque ab animi. Omnis fugiat quia sequi. Mollitia libero in id voluptates rerum nisi in omnis. İpsa voluptatibus ut quia impedit et tempora.", new TimeSpan(0, 0, 9, 0, 0), "Neque quam ea impedit sed." },
                    { new Guid("58609cc8-9142-4478-8ee8-de8bad37d552"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5280), "Vero et inventore porro delectus saepe veritatis. İpsa sed et voluptas. Qui vero quia aut id repudiandae non animi in maiores. Ducimus aut ut. Aut sed et rerum cumque. Aut et sint corporis sed minima aut laudantium aliquid dolores.", new TimeSpan(0, 0, 10, 0, 0), "Facilis impedit velit unde libero." },
                    { new Guid("5aa46ac4-72e4-420a-b64f-c1b404809356"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5083), "Soluta autem omnis eius quidem est enim rem. Qui harum quae deleniti possimus deleniti suscipit sint neque qui. Et voluptatibus sed nisi consectetur magnam rerum. Reprehenderit necessitatibus et reprehenderit molestias aspernatur id culpa dolores. Et veritatis qui.", new TimeSpan(0, 0, 28, 0, 0), "Totam et quia a voluptatem." },
                    { new Guid("5bdb95f2-b86f-45f6-b67e-8d62effff675"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(549), "Cum laudantium blanditiis atque qui nisi accusantium culpa. Nihil molestiae possimus sunt eligendi ab vitae. Aperiam fugit voluptas reiciendis asperiores non sapiente nobis voluptatibus voluptates.", new TimeSpan(0, 0, 27, 0, 0), "İn est modi et recusandae." },
                    { new Guid("5f035d1a-e490-46d9-b6bd-30b24befed2b"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3432), "Voluptatem ea quo voluptatem ipsum aperiam quisquam quos nemo. Rerum exercitationem aut ex dolor deleniti. Nemo dolor totam ut quis quos non nostrum.", new TimeSpan(0, 0, 10, 0, 0), "Et in ea odio sed." },
                    { new Guid("5f6f9232-7c41-4fdc-b667-d9f496d829c2"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8239), "Nostrum in sit ducimus quo ullam. Sunt in nam officia ea dolor architecto similique. Praesentium eum illo consequuntur voluptate qui aut. Est et iusto velit esse eius unde fugit quibusdam. Est est nobis magni labore et enim est excepturi.", new TimeSpan(0, 0, 22, 0, 0), "Dolor et incidunt similique quia." },
                    { new Guid("6bb2ee00-ef89-4c6c-bcf0-7809882a157e"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3597), "Labore ut rerum neque sed quia. Eveniet enim quia maiores qui optio. Dolorem aperiam temporibus quaerat suscipit placeat porro tempora. Commodi quae nihil quos laborum harum. Saepe sed est aut et.", new TimeSpan(0, 0, 7, 0, 0), "Dolore architecto ex repudiandae voluptas." },
                    { new Guid("6c7b9fb7-185d-4a0e-84d3-647d63398d12"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4195), "Sapiente totam veritatis aut fuga provident. Odit accusamus nisi. Eos iure fugiat quis autem omnis sunt voluptates.", new TimeSpan(0, 0, 9, 0, 0), "Voluptatibus asperiores et neque dolore." },
                    { new Guid("76245e46-2337-442d-a3b5-33e5249cb6a4"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1472), "Aut quasi ad ut perspiciatis ex enim deserunt voluptatem dolore. Qui ducimus aut id soluta libero quibusdam dolorem esse. Est a voluptatem atque quisquam in. Adipisci error eligendi optio mollitia.", new TimeSpan(0, 0, 6, 0, 0), "Ad voluptatem numquam dolor ducimus." },
                    { new Guid("77c59fb0-c9a1-4732-9ab0-5ace71e08a96"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(6633), "Nulla sunt hic veritatis ut doloribus voluptas voluptates aut commodi. Ducimus consequatur molestiae quaerat et sapiente laboriosam architecto. Ut omnis deleniti hic vel rerum. Officiis et consequatur cupiditate ullam. Eligendi fuga voluptate. Temporibus repellendus adipisci non et ipsam cumque id et.", new TimeSpan(0, 0, 29, 0, 0), "Molestias ea aliquid blanditiis omnis." },
                    { new Guid("7a47a160-9468-4dde-b371-8fa92b5d1740"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2723), "Doloremque deserunt harum aut quis. Quo et perspiciatis enim consequatur. İllo molestiae in deserunt doloribus est. Nihil molestiae magni odio. Quia ipsa quisquam ut laborum incidunt. Recusandae tempore in ipsum nostrum modi omnis rerum sit accusamus.", new TimeSpan(0, 0, 38, 0, 0), "Dolor consequatur vel nihil commodi." },
                    { new Guid("7cb86ac2-a4ef-4460-b612-b1c1daf24469"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(393), "Sed fugit omnis aliquam veritatis quia. Optio nemo dolor at. Odio natus aperiam pariatur laudantium rerum odio amet. Corporis consequatur perferendis. Dolor culpa sint et quae est amet eligendi.", new TimeSpan(0, 0, 24, 0, 0), "Excepturi asperiores et sint quo." },
                    { new Guid("7f1b2b64-3631-4697-a631-7ce76523923d"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(6780), "İusto omnis reiciendis labore. Enim delectus et quia possimus enim assumenda. Voluptatibus est nobis aperiam distinctio dolorum non aliquam.", new TimeSpan(0, 0, 20, 0, 0), "Ut molestiae excepturi et earum." },
                    { new Guid("827b9ac7-9a65-4825-a379-861f18e262ce"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8544), "Cumque rem iste omnis. Error quaerat est doloribus nostrum provident ea amet impedit. Harum occaecati corrupti corrupti minima similique mollitia. Voluptatem quasi dolorem ipsa dolorem. Repellendus iure possimus.", new TimeSpan(0, 0, 33, 0, 0), "Sint sapiente delectus ducimus sequi." },
                    { new Guid("833f5885-45e2-4bfc-bd98-27f2fb290aca"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9138), "İure rerum mollitia blanditiis modi dolor eius quidem. Eveniet sint nihil deserunt. Totam voluptatibus asperiores et corporis consequuntur ad voluptas autem. Cupiditate aut et consectetur ut.", new TimeSpan(0, 0, 29, 0, 0), "Quis rerum quo minus occaecati." },
                    { new Guid("8551c44e-239b-4291-bc90-37e4963bdedf"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(267), "Architecto nostrum aut. Molestiae delectus quisquam architecto placeat illo rerum. Voluptas aperiam necessitatibus quibusdam alias quo reiciendis.", new TimeSpan(0, 0, 12, 0, 0), "Ratione incidunt odit aliquid nemo." },
                    { new Guid("875a7c1a-199b-4279-98e8-d02b17911792"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3785), "Et distinctio dolor excepturi doloribus rerum non ut. Facere molestias cumque ut. Ratione sequi quia quia fuga quasi nesciunt.", new TimeSpan(0, 0, 24, 0, 0), "İpsum modi provident doloribus dolor." },
                    { new Guid("8b49a3e3-a374-46bc-a646-7dc2a22e1d38"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(5374), "İpsa dicta sunt qui nisi omnis eos eum illo et. Qui natus illum. Corporis ut iure rerum ducimus est in.", new TimeSpan(0, 0, 22, 0, 0), "İtaque eos praesentium cumque eos." },
                    { new Guid("8d70d696-fea6-4cc0-914f-6e31edea0555"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(861), "Ducimus minima explicabo ea voluptatem dolor voluptates non adipisci ab. Natus dolore laudantium. Eligendi vel deleniti voluptatibus sint. Reiciendis quis aut facere ipsam praesentium dolorem non blanditiis occaecati. Nesciunt pariatur suscipit.", new TimeSpan(0, 0, 13, 0, 0), "Optio rem ullam eaque aut." },
                    { new Guid("8e437035-8ad5-46c3-bc6a-58ef5253ee7f"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2203), "Accusantium repellendus et a. İpsam autem consequuntur saepe saepe. Recusandae at aut ducimus. Eligendi vero totam et.", new TimeSpan(0, 0, 37, 0, 0), "Quas sunt quis eum laborum." },
                    { new Guid("90172a1f-6d6a-470c-a690-757600fcbdb0"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4430), "Veniam vel eum adipisci et alias maiores in magni sunt. Et suscipit sapiente dolor assumenda eligendi eaque corrupti. Velit ullam veniam perspiciatis. İd ea aut.", new TimeSpan(0, 0, 33, 0, 0), "Exercitationem suscipit laudantium quos error." },
                    { new Guid("960ad781-3073-44e1-a015-028596d48bc8"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1050), "Consequatur quos aut dolorem qui qui qui explicabo. Et possimus et aut saepe tempore voluptatem. Nisi dolorem voluptas. Quos natus nihil velit deleniti.", new TimeSpan(0, 0, 18, 0, 0), "Est labore ut culpa ipsa." },
                    { new Guid("9871a5dd-0176-4910-ba87-3173f018ea6b"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(7390), "Architecto consequatur sed exercitationem sunt. Consequatur nemo repellendus aliquid sed quidem ut ad consequuntur asperiores. Error quia est in eveniet perspiciatis qui quas. Architecto qui illo. İn consectetur velit et adipisci et enim ab consequatur.", new TimeSpan(0, 0, 31, 0, 0), "Esse deleniti nemo qui ducimus." },
                    { new Guid("99a1dfa4-6a07-4da3-8c1a-918497514c7d"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(165), "Necessitatibus totam maxime. Nemo inventore aut. Et voluptas et minima cumque.", new TimeSpan(0, 0, 27, 0, 0), "Minima eligendi harum veniam aliquam." },
                    { new Guid("9e307c1c-5679-41ea-a9f2-755103fe19d4"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3293), "Omnis nobis commodi veritatis voluptate enim totam. Et distinctio qui voluptas qui in laborum. Fugit reprehenderit voluptatibus facilis et nesciunt. Animi temporibus nemo qui error. İd labore cumque fuga consequatur.", new TimeSpan(0, 0, 37, 0, 0), "Aut ipsum incidunt quam consequatur." },
                    { new Guid("9f3fbdc1-cb7a-4737-b702-30ebfbf06bc5"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5134), "Ut hic veritatis quibusdam id. Consequatur animi a eos id deserunt quam. Dignissimos cumque repellendus.", new TimeSpan(0, 0, 13, 0, 0), "Hic dicta hic aut eius." },
                    { new Guid("a0402f10-01d9-4548-b32b-b37b24ccafa5"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6196), "Occaecati eum inventore veritatis harum sint quisquam porro. Quia facilis nihil culpa eum cum dolorem. Cumque beatae ipsam qui quis nulla doloremque tempore enim.", new TimeSpan(0, 0, 20, 0, 0), "Et libero et deserunt reprehenderit." },
                    { new Guid("a0e49c3d-f148-4caf-8483-5fe1c47d1fd5"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(6283), "Voluptatem qui dolorem enim ut enim qui consequatur nemo. Exercitationem architecto nesciunt nihil commodi. Quaerat commodi maxime est. Provident aut molestiae qui fuga.", new TimeSpan(0, 0, 27, 0, 0), "Totam sapiente quis tempora cum." },
                    { new Guid("a19eac8f-2146-4fc3-8794-2adb0dcfb7e9"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6510), "Nulla ratione delectus dicta rerum. Sunt veniam minus iste. Facilis tempora et sit. Ut architecto ut modi voluptatem.", new TimeSpan(0, 0, 40, 0, 0), "Officiis fuga voluptatibus vero sequi." },
                    { new Guid("a1ec89b6-3978-4a52-9d80-0b63d559a2bb"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(526), "Commodi modi sit doloribus fugiat tempore eum earum. Deleniti fugit deleniti aut facilis. Laboriosam rerum ut quasi doloremque. Eligendi quo aspernatur placeat officia dolores. Delectus aut eius minima laborum ex est saepe.", new TimeSpan(0, 0, 33, 0, 0), "Eos similique sit impedit repellendus." },
                    { new Guid("a4279a15-76d3-44b3-98f6-0f194b2db27a"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2686), "Atque eveniet minus sit amet. Quia nihil fuga voluptas. Vel maiores labore et et sint tenetur id. Recusandae a officia dolor beatae iusto et sed.", new TimeSpan(0, 0, 31, 0, 0), "Maiores ipsam at eum ipsam." },
                    { new Guid("a4873cc3-7b1a-4954-86b0-59beec84d43c"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1627), "Ducimus dolor minima est porro distinctio placeat. Porro perferendis et qui delectus eum ut accusamus at ut. Sint autem sint dolores quia id.", new TimeSpan(0, 0, 25, 0, 0), "İmpedit placeat enim odit maxime." },
                    { new Guid("a66d8a4f-f4ce-45cc-a5c0-b971714c19ed"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(7896), "Voluptas laudantium dolorem totam fugiat. Et quasi iusto cum voluptates fugit necessitatibus. Earum assumenda est enim hic et animi alias inventore. Et aliquam quidem temporibus commodi. Consequuntur omnis veniam incidunt. Cupiditate et id quos neque.", new TimeSpan(0, 0, 28, 0, 0), "Ut ipsa minus delectus quo." },
                    { new Guid("a9acf1b9-442e-422e-937e-a27ce2c559b9"), new Guid("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9486), "Ut repudiandae magni qui deserunt est cumque quidem modi. Qui est fuga sed optio ducimus aut numquam ut placeat. Eos assumenda temporibus cumque. Voluptatem deleniti incidunt officia voluptatum ratione.", new TimeSpan(0, 0, 38, 0, 0), "Quas aliquid ut magni vitae." },
                    { new Guid("aa4f84c1-f8f7-4e5b-afae-2f873ca79033"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(669), "Consectetur eaque accusantium ipsa deleniti numquam numquam beatae. Esse voluptatem voluptatem voluptates et non ullam qui. Ut occaecati et aut aut suscipit ipsum est.", new TimeSpan(0, 0, 19, 0, 0), "Hic molestias pariatur enim sunt." },
                    { new Guid("aafbc1e1-c0e7-4726-a735-23bd088982dd"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8705), "Repellat ducimus ab voluptatem. Expedita nostrum exercitationem debitis. Omnis qui deleniti sint ullam. Qui voluptatibus doloribus dolor alias velit. Aut cupiditate eius sint est et.", new TimeSpan(0, 0, 24, 0, 0), "Dolores quia voluptas laboriosam fugiat." },
                    { new Guid("ab3e7d69-bb41-4f1b-a4b8-3f78a4d46992"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(3503), "Alias modi eum quasi porro quidem fugit occaecati vitae ipsa. İn quibusdam placeat quos ducimus in ducimus qui iusto velit. Reprehenderit sit labore quia. Amet nihil hic ut dolor officia quos ipsa architecto. Enim quia maiores tempore. Quis velit id laudantium possimus.", new TimeSpan(0, 0, 38, 0, 0), "Totam velit qui alias omnis." },
                    { new Guid("ab67ecdb-1397-4b38-94e1-d826b067cf41"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1949), "İure sapiente aut voluptatem sit sapiente assumenda. Ullam nemo autem ut sunt sed et in. Nulla rerum officia eos unde.", new TimeSpan(0, 0, 7, 0, 0), "Voluptatem ab quia facere et." },
                    { new Guid("abb3105b-deb3-4815-a749-e6af6b89c6a3"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(4714), "Et alias et autem ullam. Consequatur est ratione. İd doloremque itaque. Optio in debitis sunt.", new TimeSpan(0, 0, 11, 0, 0), "Nesciunt non minus commodi perspiciatis." },
                    { new Guid("abdc8b85-0892-490e-869f-944a12dc3d25"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(3724), "A architecto laboriosam distinctio blanditiis debitis sed exercitationem. İncidunt optio illo qui. Ut dolores esse saepe ut omnis. Aut omnis at sed non reprehenderit ipsa quam. Cupiditate aliquid aut velit quisquam dolor ipsa facilis. Ut quae quasi aut explicabo voluptatem nostrum accusantium.", new TimeSpan(0, 0, 28, 0, 0), "Nihil reiciendis et cumque eius." },
                    { new Guid("af6791d4-39bd-4b42-98c5-3c70a342a1b4"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3007), "Libero illo autem iusto. Earum itaque doloribus iure aperiam mollitia possimus nihil et sint. Blanditiis possimus consequuntur officiis animi eius laudantium et. Temporibus accusamus laborum velit.", new TimeSpan(0, 0, 24, 0, 0), "Fugiat sit eos reprehenderit vero." },
                    { new Guid("b736e4ad-c35b-4ec7-b80d-aac5754add3c"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1268), "Consectetur aliquid aperiam facere a. Quia consequatur officiis placeat ullam voluptatem porro eligendi nihil. Rerum error voluptatem quia dolore a. Omnis et maxime similique ex eligendi consequatur voluptatem. Quia aut sed porro nobis error error. Ea vel quia doloribus deleniti adipisci cumque asperiores et.", new TimeSpan(0, 0, 9, 0, 0), "Rerum modi reprehenderit nihil et." },
                    { new Guid("b78d88db-32a6-4a2e-be09-7360966189a1"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2399), "Vero cum autem tempora itaque accusamus non laboriosam ab rerum. Dignissimos aut consequuntur quod animi adipisci omnis. Eligendi qui eveniet est rerum odio quam ipsam. Et in eligendi ab ducimus. Possimus reprehenderit et iure non. Harum laudantium est quia atque est reprehenderit accusamus.", new TimeSpan(0, 0, 31, 0, 0), "Qui maiores accusantium officia necessitatibus." },
                    { new Guid("b8c60554-3c89-4981-bc2a-482bb0c63b75"), new Guid("2dea5bce-36b6-457a-9a31-4626f9b213ec"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5014), "Rerum non ratione iusto culpa consequatur aliquid facere. Eligendi labore et autem voluptatibus tempora consequatur doloremque quam ullam. Commodi nobis quas ea est corrupti itaque ullam rerum.", new TimeSpan(0, 0, 25, 0, 0), "Possimus libero pariatur quibusdam accusantium." },
                    { new Guid("bbe7f3f2-5937-493d-9804-f6c7aa75ed03"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9110), "Error eveniet nesciunt aut dicta. Et sit tempora. Voluptatibus provident maxime architecto asperiores natus est voluptate. Molestias veritatis voluptas non rerum sed. Voluptas itaque quibusdam saepe illum aliquid modi. Et nemo consequatur at est ea.", new TimeSpan(0, 0, 19, 0, 0), "Sed est voluptatem et sed." },
                    { new Guid("be4fe072-bbbd-433d-8c3b-9acd30589129"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5473), "Qui quo minus sint et in iste consequatur ut. Et nihil dicta ipsum repudiandae inventore. Molestias aut impedit. Molestias et earum dolorum sint dolores ut. Temporibus amet accusantium eum. Numquam necessitatibus ipsa repellendus rem voluptates quisquam rerum assumenda.", new TimeSpan(0, 0, 10, 0, 0), "Eos esse aut earum dolor." },
                    { new Guid("bea83c18-b88a-41b3-a3f6-9315e8df63c4"), new Guid("d32f93ae-13f3-452f-97c1-0f9dc7c09300"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(760), "Tempore eaque fuga non. İtaque unde ea alias aut saepe explicabo qui in est. Delectus earum vel harum officiis.", new TimeSpan(0, 0, 13, 0, 0), "Aut nisi eos non quibusdam." },
                    { new Guid("bfa39e61-c7dc-40e5-92c3-8c1bb7728b3c"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1710), "Quae magni animi natus ullam impedit dolor a ex eaque. Suscipit sit magnam eius saepe reprehenderit consequatur dignissimos totam. Libero recusandae dolorem placeat maxime eos dolore. Ullam et earum fugiat qui consequatur consequatur minima voluptatem quo. Maxime et maxime sint. Occaecati cumque dolores autem eos facilis dolores.", new TimeSpan(0, 0, 26, 0, 0), "Autem ut et aut ea." },
                    { new Guid("bffb60b9-9660-4aed-8f8e-efb2eee5e366"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7186), "Consectetur exercitationem perspiciatis mollitia voluptates consequatur rerum laudantium non ut. Consequatur repellendus doloribus laudantium rerum aut nemo qui. Quas quia iusto occaecati qui corporis minima magni est non.", new TimeSpan(0, 0, 22, 0, 0), "Nihil ut sunt cumque saepe." },
                    { new Guid("c4ad7f84-fe4a-4bb9-8243-d0cf416fbf31"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7935), "Numquam magnam omnis placeat soluta est eligendi omnis modi ut. Quae enim expedita ut ut. Nam repellendus cupiditate veritatis sequi non voluptas voluptas eligendi. Deserunt vero nobis vitae modi a. Labore maiores adipisci nobis nulla. Praesentium ut est iusto nulla veniam earum recusandae.", new TimeSpan(0, 0, 9, 0, 0), "Consequuntur rerum ipsa porro eum." },
                    { new Guid("c6d4d883-e77d-4513-bd33-536e57fff69d"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5265), "Ullam et eum minus sint quibusdam quae nihil explicabo facilis. A est veniam ullam voluptatem. Sit rerum provident consequuntur. Nulla culpa adipisci. Voluptatem qui mollitia quasi ab.", new TimeSpan(0, 0, 27, 0, 0), "Nam nisi aliquid delectus eos." },
                    { new Guid("c8ede800-3228-406b-acd3-2328216bfa8e"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(680), "İnventore maiores facilis non. Ducimus vel veritatis ex quia adipisci in iusto ad. Voluptate consequatur ratione qui. Nihil est voluptatum sed consectetur perspiciatis dolorem. Ex voluptatum sed sed provident animi tempora.", new TimeSpan(0, 0, 33, 0, 0), "Ullam quo cum rerum quia." },
                    { new Guid("c9738687-6a13-4b1e-babf-53544cea5ff7"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2051), "Sequi nemo reprehenderit exercitationem. Quasi sequi id non officia enim dolor facere. Aspernatur sunt optio tenetur id esse ut.", new TimeSpan(0, 0, 34, 0, 0), "Ducimus molestiae id hic repellendus." },
                    { new Guid("cbb7732d-9c4f-4e40-9869-528f30855cda"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2275), "Molestias alias officiis reprehenderit. Explicabo quam aut. Sit recusandae provident ex. Aperiam libero inventore blanditiis. Voluptas aut id. Aperiam quaerat facere aut aliquid repellendus necessitatibus.", new TimeSpan(0, 0, 8, 0, 0), "Neque voluptates nam nam nisi." },
                    { new Guid("cbba43ed-cf00-4638-a259-15b71d566959"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2893), "Ex quidem nisi maxime et perferendis quidem molestiae debitis. Et incidunt voluptas voluptas exercitationem repellat. Nostrum dolorum nostrum. İtaque quisquam molestias maxime expedita facere qui corporis iste beatae.", new TimeSpan(0, 0, 33, 0, 0), "Ea consequatur delectus qui in." },
                    { new Guid("ceb492d1-4f7e-49b9-9bfc-5ec807365b56"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(6897), "Voluptate reiciendis id ullam sit. Perferendis soluta repudiandae modi accusamus. Qui temporibus voluptatum itaque dolorum esse ut assumenda quasi harum.", new TimeSpan(0, 0, 26, 0, 0), "Aut nihil omnis molestias non." },
                    { new Guid("d0132e24-7b17-4b42-8eff-0c8266dc8bfb"), new Guid("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(1960), "Labore eveniet dolores nihil magni quaerat. Aut tempora est assumenda ad animi placeat ea sunt. Laudantium a aut quia doloremque occaecati qui.", new TimeSpan(0, 0, 39, 0, 0), "Laudantium impedit nemo molestias assumenda." },
                    { new Guid("d31c6651-b003-4256-8cd5-01dc3d7080ba"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2791), "Sit voluptatum numquam qui reiciendis perferendis ut. Laudantium placeat consequatur corrupti. Et enim aut tenetur quia ea dolor. İncidunt quia repellendus.", new TimeSpan(0, 0, 10, 0, 0), "Odio officia recusandae laboriosam odit." },
                    { new Guid("da515324-c703-40e1-b9c3-257019a75cfd"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8985), "Ut veniam voluptatem enim quis quidem fugit nisi dignissimos voluptas. Alias perspiciatis rem quia totam. Corporis voluptas sit veritatis consequatur ut autem. Veritatis quo dicta saepe natus. İd quasi consectetur cum est vitae unde. İd aut asperiores quo excepturi.", new TimeSpan(0, 0, 8, 0, 0), "Quo necessitatibus voluptatum quam ea." },
                    { new Guid("dabb9b98-ce46-48aa-a8a0-c391604ba8be"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8593), "Cumque culpa est nobis aperiam culpa nisi quo voluptatem. Aut sed recusandae. Et sequi esse repudiandae consequatur aut sed.", new TimeSpan(0, 0, 22, 0, 0), "Quos fugit ut possimus rem." },
                    { new Guid("dbdafc2b-7703-4b05-9d69-48efed98aa51"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4109), "Rerum eveniet enim. Dolorem et quod dolor omnis qui ratione. Quis dolore non. Dolorem repudiandae corporis officiis. Laborum perferendis dolores maxime.", new TimeSpan(0, 0, 27, 0, 0), "Quae rem similique ut provident." },
                    { new Guid("dc0a7c60-313a-48ec-9f93-5619141fa64f"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7046), "Magni quia et facilis mollitia adipisci harum eligendi ipsam labore. Nihil est quia earum non unde nulla quibusdam. Aut doloribus fugiat minima maxime corporis omnis et rerum. Provident et omnis placeat atque quibusdam. Reprehenderit maiores voluptatem eius ipsa. Enim ea tempore et dolore non ipsa reprehenderit porro.", new TimeSpan(0, 0, 18, 0, 0), "Odit qui minima error numquam." },
                    { new Guid("e1b5ce7d-a179-4393-af4a-5421e0752046"), new Guid("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(9886), "Laborum in doloribus et et. Quis architecto sed aperiam sunt. Odit quasi id ea qui error. Culpa at voluptas dolore est. Minus eos amet aliquid expedita incidunt voluptatem doloremque odit. Tempora quibusdam cumque quas consequatur dicta ipsa et impedit neque.", new TimeSpan(0, 0, 17, 0, 0), "A nihil voluptas sunt autem." },
                    { new Guid("e31ba0b2-19ce-4e5c-a42a-960bf2cb42a9"), new Guid("cb89ad2a-473f-47a9-b26d-523e9f9cf807"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8413), "Voluptatem aut voluptates nesciunt similique tempora ex rerum doloremque. Omnis harum sunt vitae eligendi. Omnis vel vel. İnventore est possimus. Et similique quia qui necessitatibus nostrum molestiae aut et dolores.", new TimeSpan(0, 0, 30, 0, 0), "Veritatis consectetur porro et voluptate." },
                    { new Guid("e3fe5073-d5a3-41bb-853c-9acaaac2ee3e"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6092), "Et et expedita atque in quia earum autem. Ut et culpa ut. İste libero quia nostrum non quis optio rerum consequuntur.", new TimeSpan(0, 0, 25, 0, 0), "Molestiae ab eum quas harum." },
                    { new Guid("e473eb38-5534-4255-b741-14d93ac1c3dd"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9611), "Quis sunt in velit. Est repellat quas suscipit exercitationem ut et temporibus voluptatibus. Aliquid provident aut non dolor. Quia consequuntur corrupti perspiciatis rerum dolorem laborum et. Blanditiis non necessitatibus ut aut quo incidunt et asperiores aperiam. Magni ullam aliquam dignissimos modi nobis laborum aspernatur aut.", new TimeSpan(0, 0, 30, 0, 0), "Neque dolorem laborum perspiciatis voluptatibus." },
                    { new Guid("e579b6cf-94b5-4a51-b3f8-a27be08779b3"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1039), "Quod sit qui non quasi libero repellat. Dolores similique nihil in alias repudiandae et. Est mollitia quae assumenda maiores officiis. Quo numquam quo fugit magni. Fugit doloremque sequi quidem nihil est autem dicta.", new TimeSpan(0, 0, 28, 0, 0), "Accusamus sed beatae et asperiores." },
                    { new Guid("ea1329da-43c0-4eaa-98f2-be3c98d4301f"), new Guid("f45bda6a-473f-47a9-b26d-523e9f9cf809"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9932), "Ut quod sint illo. Dolore deleniti qui. Ut sequi doloremque accusamus ipsum est laudantium at.", new TimeSpan(0, 0, 7, 0, 0), "Sapiente modi possimus et perferendis." },
                    { new Guid("edd6b8bd-b379-4ba9-82af-1ae265408b93"), new Guid("a29eac2a-473f-47a9-b26d-523e9f9cf808"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(9247), "Sequi eos ut ipsam ut. Totam ut consequatur voluptatibus rerum qui. Dignissimos molestias perferendis ut omnis fugit. Aut quaerat in ipsum voluptas nihil possimus.", new TimeSpan(0, 0, 11, 0, 0), "İd voluptas pariatur non dignissimos." },
                    { new Guid("f0277aa4-89bb-4b6e-b120-1fd1a93862dc"), new Guid("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2521), "Est fuga aut eius libero perferendis neque non. Eveniet iste excepturi. Nesciunt sed possimus labore nemo quia ducimus ducimus et.", new TimeSpan(0, 0, 11, 0, 0), "Odio qui odio cupiditate voluptates." },
                    { new Guid("f0ceb9ff-0e52-44cb-8ef5-58be8f9ab6bf"), new Guid("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(2519), "Ab perferendis temporibus magnam perspiciatis a et officia. Quos laboriosam reprehenderit distinctio eum est occaecati nihil. Nam magnam consequatur. Dicta nobis veritatis iure eius at accusamus.", new TimeSpan(0, 0, 32, 0, 0), "Aut nesciunt at facilis nobis." },
                    { new Guid("f2835f24-2e13-4546-be85-5f9a4a0460ad"), new Guid("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(5728), "Fuga et dignissimos reprehenderit sit recusandae quia. Quibusdam non veritatis ullam tenetur voluptate ullam corporis libero. Ut illum natus officiis libero labore nemo omnis labore. Officia dignissimos numquam aperiam quae quia minima quis ut. Non delectus autem vel quia consectetur asperiores. Eos sunt itaque corrupti velit quas in quo atque.", new TimeSpan(0, 0, 38, 0, 0), "Sed quasi ab nisi et." },
                    { new Guid("f2f59721-a54b-4f36-902b-174ba73f46d9"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(1351), "Aut architecto aspernatur veniam rerum culpa minima ea a. Sit qui numquam itaque occaecati repellat. Earum vel quas repellendus placeat debitis.", new TimeSpan(0, 0, 23, 0, 0), "Sit nam natus aut ut." },
                    { new Guid("f5087f56-8a95-48ff-ab1e-9196e2719a4d"), new Guid("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3163), "Quibusdam fuga a voluptas a. Et ex ducimus eos quia dolor numquam voluptatum aut. Qui necessitatibus sequi et quasi ex dolores quod. Ab ex sed natus.", new TimeSpan(0, 0, 26, 0, 0), "Expedita fugit ut in molestiae." },
                    { new Guid("f555b8f7-23b5-4d95-a35b-f399c9812afa"), new Guid("b71f2993-7de5-4175-8421-875eb7323b5a"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(3883), "Beatae aut quasi laudantium vitae illo aut. Qui reiciendis labore voluptatum fuga numquam odit et repellat quasi. Vitae ipsam ea iusto illo enim rerum. Repellendus aliquid ab.", new TimeSpan(0, 0, 9, 0, 0), "Officiis temporibus quod voluptatem voluptatibus." },
                    { new Guid("f7750979-7852-4dbd-ad94-cca5d0b7aa23"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(6637), "Similique dolores architecto nemo ab. Et sed exercitationem et ab quasi corrupti. Aut illum iure. Optio id dolorem pariatur saepe veniam ad autem aperiam explicabo. İpsa quidem omnis suscipit.", new TimeSpan(0, 0, 9, 0, 0), "Sed non fugit laudantium sapiente." },
                    { new Guid("f7e2c46e-1bc5-434d-b9f4-9d676192e8d6"), new Guid("7f16ad2a-473f-47a9-b26d-523e9f9cf805"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(7103), "Sunt totam cupiditate. Et et labore quo eum magnam qui ipsa corporis. İncidunt et modi voluptas. Ut et qui quae facere accusantium et fugit. Consequatur natus alias. Temporibus dolores quis voluptatum et quisquam accusamus enim quae.", new TimeSpan(0, 0, 38, 0, 0), "Fugiat aut dolores qui dolores." },
                    { new Guid("f909f99d-12d2-4e28-aa78-5172c4544ecf"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7373), "Labore iusto ad et. Magni quam adipisci itaque voluptate. Sed commodi doloremque rerum accusantium omnis.", new TimeSpan(0, 0, 33, 0, 0), "Alias qui cupiditate ducimus voluptas." },
                    { new Guid("fa18abe4-67d6-4989-8d33-6d1883f50f61"), new Guid("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(8304), "Quis incidunt sapiente vel qui consequatur reprehenderit. Vel et et. Ea delectus inventore repellendus. Autem vitae autem. Et et dolores ut accusamus praesentium. Quo enim et deserunt harum possimus.", new TimeSpan(0, 0, 35, 0, 0), "Quaerat qui dolores dolores nihil." },
                    { new Guid("fdc56900-2f8a-43f9-9f94-403d563d71e7"), new Guid("4bced12f-c5b0-484d-8fd6-a9557329b1e0"), new DateTime(2025, 1, 5, 22, 9, 44, 784, DateTimeKind.Local).AddTicks(2940), "Tempora est blanditiis quae. Atque error laborum totam. Sit libero temporibus magni placeat repellat itaque accusantium. Consequatur quidem numquam similique qui sint autem eaque.", new TimeSpan(0, 0, 38, 0, 0), "Et laborum impedit eum quae." },
                    { new Guid("fe3d9fa8-1a9c-49c1-acf0-76cf81df6155"), new Guid("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(3969), "Magnam dolore omnis molestias id. Reprehenderit voluptatum natus et voluptas ea. Asperiores eaque adipisci repellendus consequatur pariatur tempore. Esse aliquam ut voluptas sunt alias dolorum. Velit explicabo maiores temporibus officia eos ipsum veniam assumenda.", new TimeSpan(0, 0, 16, 0, 0), "Eum numquam sint et repudiandae." },
                    { new Guid("fe926962-5da7-4ef2-bc3b-53a7b7a2633c"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(4726), "Sed non aut assumenda. Excepturi possimus qui voluptates occaecati ducimus. Ab minus sed fugiat est odit est provident in non. Placeat sit sint tempora atque praesentium in in consequuntur. Et eaque aut laboriosam minus.", new TimeSpan(0, 0, 18, 0, 0), "Exercitationem ullam similique minus eum." },
                    { new Guid("fed966f4-7296-4d3a-b9c0-854eb53f590d"), new Guid("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"), new DateTime(2025, 1, 5, 22, 9, 44, 783, DateTimeKind.Local).AddTicks(7569), "Molestiae quis quod laudantium similique nesciunt qui et. Nostrum libero delectus sed incidunt corrupti qui. Voluptas officiis eius voluptas odio. Ea dolorum ipsam est architecto omnis. Sunt consequuntur repellat hic sit rem consequatur.", new TimeSpan(0, 0, 12, 0, 0), "Quo delectus voluptatem vel id." },
                    { new Guid("ff227860-c59c-4ca4-813e-c885c63fd600"), new Guid("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"), new DateTime(2025, 1, 5, 22, 9, 44, 782, DateTimeKind.Local).AddTicks(8033), "Quidem sunt facere culpa tempora asperiores voluptas. A sint error sit voluptatum. Sint molestias sunt non exercitationem labore ipsam et dolores dicta. İusto culpa libero voluptas tempora doloribus et.", new TimeSpan(0, 0, 32, 0, 0), "Et sit voluptas occaecati rerum." }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CourseId", "CreatedDate", "OrderStatus", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e84ecf2-b4a4-442b-b3b1-919043655e45"), new Guid("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6626), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("21afdd85-4df0-44db-8037-864b68904f04"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6623), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("5372e019-b012-4f32-bccb-60c9835f8ff0"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6617), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("5cd27ae9-8eac-4447-9214-8a6df719274c"), new Guid("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6632), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("a0143af2-73bf-4b94-adc0-5f7bdaca75ab"), new Guid("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6606), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("bd208bb0-fb15-44a2-a159-be62081d7025"), new Guid("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6614), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("d51facd3-2c94-4dea-a357-54713ed5fcec"), new Guid("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6620), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") },
                    { new Guid("ff1f7f23-081b-40e1-b5cb-90bc6463d918"), new Guid("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"), new DateTime(2025, 1, 5, 22, 9, 44, 787, DateTimeKind.Local).AddTicks(6629), 2, new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038") }
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

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
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
