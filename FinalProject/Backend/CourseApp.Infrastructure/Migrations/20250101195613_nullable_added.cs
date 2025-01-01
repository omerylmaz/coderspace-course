using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullable_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldCode",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d8651fd-3800-48da-a85c-f294282b5180"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc83da17-aed8-4c81-9372-409ee57dda65", "AQAAAAIAAYagAAAAEGh2Etr23la3m+fFzZx8ctSXZ4h0EBvRDLP0ksQ+gp6hHK/sjZ86eM9vQ4heC8PFVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da76736a-e494-462b-8e19-72a5b51d7df1", "AQAAAAIAAYagAAAAEBI/RU1uuEh+7zmmlALA3DXMNDTdNtHiegQPwshN8hI1TWxu//GR0SU0DzsP/eYEBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9aa6bd7f-2f84-41de-9036-b88fdae59aac", "AQAAAAIAAYagAAAAEM2cB3BMQd2JnwsYG19pMfh13UW4nj3yYr1hk+o+B3JFzUqllx6QE/Q9FB1GNVJDSw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8ba131f-16ea-44e2-a8b3-f3b525c948c2", "AQAAAAIAAYagAAAAEA6fy8pOHPidGebrbtckqa/ohKCL/b16L1IVgOKBPDuvWyPxGpHPoP5200ysyd7Cbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54039b1c-f914-4171-97a8-f78a9c107935"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efb8ff48-a5b3-429b-afac-0c129e7cd68b", "AQAAAAIAAYagAAAAEIjNAZiZj9Dvpxy8AruVcP9tz90peYA7wStXT8cy+DFDupQRgyvoPf94n4+PQIz/kA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9257ec4-40d1-4c6d-b8fa-83ea867e52ef", "AQAAAAIAAYagAAAAEHZbQCJnRgWPfl/IWEh3QmDFmiR1s0UJFS7lbeJMB6ElrEwcjUi3dSDl6HoXRrveCw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9cedb839-dc22-4451-a480-a40aa6648665", "AQAAAAIAAYagAAAAELgNZOL+LrJKmw1uY4bNfZuPQmohB+AzudgOme3ENcFUqeCVdc5jDSCBe2dcoe3XFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7a7c6ff-6d5e-480a-b937-398171e35d5d", "AQAAAAIAAYagAAAAEM2j/t6GmwnnRiheisL32oz8Atgd5/aod+pPAvU+TKByhQ0k8QiEfc1tD5QEkcRvzw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 1, 22, 56, 12, 457, DateTimeKind.Local).AddTicks(1795));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldCode",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
