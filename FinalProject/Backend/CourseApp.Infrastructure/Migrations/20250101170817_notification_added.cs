using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class notification_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
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
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d8651fd-3800-48da-a85c-f294282b5180"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b50398d-408a-47f4-a2d1-af899a27aa37", "AQAAAAIAAYagAAAAEDIAR9dpiQZCOW0EyHuhUeDtyjsPt5DQwpe3PE0qTV+H6Ps4jyt4vQm9mZSFa6rO0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "290cd985-ddd8-4277-a83f-9f64bbbb3621", "AQAAAAIAAYagAAAAEM50EGFQgbsHsQdg/6oypmcTVkYk6DCecuBQXmfSYbdOxijSEB3ydAoytmzPlT2IRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0326b312-d3cc-4d54-8c22-f2b6583dcf3c", "AQAAAAIAAYagAAAAEH97wfhn4JOyFq+xnyPaJWEIw7jhMWH+LkQxWsi9VLQkiJ39iZXS1okolHOBiBm4nQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "343d2b73-4b23-4e21-b73a-0f5369b25e4d", "AQAAAAIAAYagAAAAELToMRkwJj4ESdtDMPQNy2V4Ep3CFuqm6MlU1814CyaVk79Nl7ioKeqJ0AgBmM9QVA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54039b1c-f914-4171-97a8-f78a9c107935"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23e979ea-c6f0-4629-a100-847f6c48a624", "AQAAAAIAAYagAAAAEJWvjUWEPJe0IKG3/0rwK4Wb6GMCJdLPSf6oCnlGXzjtiUjbnRdRbX1XgzghN1uf5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26ef8085-fcaa-4d24-a074-bdcb2be74f0a", "AQAAAAIAAYagAAAAEPrSC0Xyo6Ida3L3SGHgEAvtPdONEF8taVXqLSn94NTpabRxnB2+efzPFIqKy71aWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d17f42f2-941f-4c25-b53c-99ef7347e0f3", "AQAAAAIAAYagAAAAEBGR02eOK6odG+UTcAXuA1v5MoqujOuBIajA3IZAmaCd31ewjKi8/udfflOmwPR2tA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2c55429-a241-4537-a7db-4695196538ac", "AQAAAAIAAYagAAAAEBsAylJXIrjn11Eky0fQlvK2mAqDcNKsQoNeP3FZKUK76Hdau6cn3WM+KQqB6SZFTg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 20, 8, 16, 618, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d8651fd-3800-48da-a85c-f294282b5180"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83f229ee-8eb2-4c84-a059-a130b6149e79", "AQAAAAIAAYagAAAAEJqrheVkippD/zxlEJ/zEQ6YaEao8IL0LhZPFGxz+4ZvXbLjF2Q/X7rV13HqayWu5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a39ce119-6fab-4c92-85d9-e75ae579fd30", "AQAAAAIAAYagAAAAEIjaj8JYQEoj1kqYcJ1zsymEny81BvcbN1LnecUpfE+JzKiMnPpUADAqdLCIdCO/yA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d50bfa63-40ec-4bbb-8dd3-21df5ce17675", "AQAAAAIAAYagAAAAEH19c68RDy+nTUUoASc+28Z/x7W14ZvzWBLqMrCOAOAOHreshJSDM+wTdbAETKr/Fg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bee7a2b-2166-45cf-8164-9bb534ae7070", "AQAAAAIAAYagAAAAEAQ2MJIdmxppt664W7SYezooWkJZJQyIhLN6h3U+p65TGqT/5GiBILmJuFPOsZrq5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54039b1c-f914-4171-97a8-f78a9c107935"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6faf2bd-e33a-4c8c-821c-0fdd0dacdb27", "AQAAAAIAAYagAAAAEPLEPNVded8aR7+7hvpX6ZC9sTNuQFyc1cqSTERtRPDTrWnhadyD0GhG1Z0hcJFZ/Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ea26e95-9517-48db-96ba-138e1badeb10", "AQAAAAIAAYagAAAAEOJKYJ26u9WYWk09Ox/MkjADfyD7XAy99UKY7juafqkpkyLnvpM7WRbWih3BeRs83A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3c6ea43-2902-4a6a-b3aa-87d48819a47c", "AQAAAAIAAYagAAAAEJFgNTraw+MbssmpIp0nnR07TTjJz8IKCeWa4rDgXYgPcbiM2bneIxmxiX67iQdQ/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed4c18e1-c5fd-417d-9df6-bde8b27a13ee", "AQAAAAIAAYagAAAAEPCtcyGULpOFUyDjj9KY1h19vNgCyDB9lLlLRdoYfC0vUn98smch6AHUa4D7zhgIQg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 18, 6, 20, 994, DateTimeKind.Local).AddTicks(2179));
        }
    }
}
