using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "I",
                table: "ROOMCOUNT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MOBILEELEVATOR",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpitonText = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOBILEELEVATOR", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "MOBILEELEVATOR",
                columns: new[] { "ID", "OpitonText", "Price" },
                values: new object[,]
                {
                    { 1, "Sadece Eski Evimde İstiyorum", 200.0 },
                    { 2, "Sadece Yeni Evimde İstiyorum", 200.0 },
                    { 3, "Her İki Evimde İstiyorum", 400.0 },
                    { 4, "Mobil Asansör İstemiyorum", 0.0 }
                });

            migrationBuilder.UpdateData(
                table: "ROOMCOUNT",
                keyColumn: "ID",
                keyValue: 1,
                column: "I",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ROOMCOUNT",
                keyColumn: "ID",
                keyValue: 2,
                column: "I",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 4, 58, 50, 914, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 23, 4, 58, 50, 915, DateTimeKind.Local).AddTicks(2442));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOBILEELEVATOR");

            migrationBuilder.DropColumn(
                name: "I",
                table: "ROOMCOUNT");

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 16, 1, 37, 45, 713, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 10, 16, 1, 37, 45, 714, DateTimeKind.Local).AddTicks(7003));
        }
    }
}
