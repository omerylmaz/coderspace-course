using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class author_id_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 31, 15, 49, 17, 212, DateTimeKind.Local).AddTicks(5134));

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 19, 42, 14, 324, DateTimeKind.Local).AddTicks(6572));
        }
    }
}
