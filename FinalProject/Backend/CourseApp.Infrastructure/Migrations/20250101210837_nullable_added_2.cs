using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullable_added_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2d8651fd-3800-48da-a85c-f294282b5180"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c60f1536-d24f-48db-b425-ac7eea51f454", "AQAAAAIAAYagAAAAENvSkKFl1cnx9s8L69O2J+3HOYoaxlM0YiGTdbmniqD6gZCb4t7XuCfxJJbnn731/A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6d2cd2a-a176-4772-8f6b-729face7948b", "AQAAAAIAAYagAAAAEDtxSN/gzR9di9JUUd6a66fD0rACbGoTWJUCiNdguXxW8r0tM1BMLOklF6yR9na1BA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29676186-dd4b-4eb6-8e33-960bd121bdd0", "AQAAAAIAAYagAAAAELusLnZs5BKzRTF/38jSHdFfQ6N4b9dx/UvaNVeLcHU2sK+KIGAVJk2Wo4y59OH75Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f1d809c-9ccf-4479-b1ab-273f6193679b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5922572-adf9-49d0-9424-bc3e3ce090f1", "AQAAAAIAAYagAAAAECCFhEjq4fTSiS7XkxYdGryfIz9nAXJhekuES0Wn9KBfwQJL9BFDSBbp3o6r/sVAnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54039b1c-f914-4171-97a8-f78a9c107935"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fcafbd3-8af1-49f7-a773-a5f9e85f8008", "AQAAAAIAAYagAAAAEFFHuufdA595T+UyrWn6utzReuwEQEOx6HoN5nhnyT2Gd6QK3BwOfImkBrv+EQ7r0Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9beb751f-f3b8-4e45-a938-622ebc1dd038"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3cf09b9-1c05-401e-a10b-30ad5bc79c0f", "AQAAAAIAAYagAAAAEHaEFbWp/fj+aZIKvrGN1KEZ2NkB87dtfBIz9ZVCf4b57TClhKNozSx5QrlSeHFqgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d6a837a-81ad-496b-91e3-d3978a3d0330", "AQAAAAIAAYagAAAAEK2ClMorqRLRseumQGfQ6MeuKVQThTWZ4ZjvO+H6EbjfHfRdjxOLD5BceoJTDgESOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa822f53-daac-4c7b-8fed-eeae7cdfecb1", "AQAAAAIAAYagAAAAEBR//CkmdGaIaNhqBTN+NFOPycjtjWtylWle+RRnAS48gpUDLuFi0IxPMhDvtRvGyQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4290c1e9-2c24-45d1-8d7b-35482a001044"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("551963a2-879e-45a6-99a6-5eb512b775c0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80853207-5355-434f-8cab-80e3269d54c4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b48bba4-8acd-4ff2-b669-f4095c885e90"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2308a61-470a-46e9-ba82-87c3090046fb"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a82c256f-6027-4c22-87ca-22fb85c2daf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a93961af-166d-461c-a6db-263c4d48a55d"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 0, 8, 36, 530, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notification",
                newName: "IX_Notification_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
