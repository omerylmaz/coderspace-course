using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım" },
                    { new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finans" },
                    { new Guid("80853207-5355-434f-8cab-80e3269d54c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proje Yönetimi" },
                    { new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hayat Tarzı" },
                    { new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing" },
                    { new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dizayn" },
                    { new Guid("a93961af-166d-461c-a6db-263c4d48a55d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fotoğrafçılık" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"));
        }
    }
}
