using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeftStep",
                table: "CUSTOMER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "STEPEXPLANATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepI = table.Column<int>(nullable: false),
                    Explanation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STEPEXPLANATION", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ROOMCOUNT",
                columns: new[] { "ID", "Count", "I" },
                values: new object[] { 5, "1+0", 1 });

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 20, 13, 32, 280, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 20, 13, 32, 281, DateTimeKind.Local).AddTicks(1394));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STEPEXPLANATION");

            migrationBuilder.DeleteData(
                table: "ROOMCOUNT",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "LeftStep",
                table: "CUSTOMER");

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 24, 0, 48, 10, 774, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 24, 0, 48, 10, 774, DateTimeKind.Local).AddTicks(7616));
        }
    }
}
