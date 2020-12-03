using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromAddress = table.Column<string>(nullable: true),
                    ToAddress = table.Column<string>(nullable: true),
                    FromRoomCountID = table.Column<int>(nullable: true),
                    FromElevator = table.Column<bool>(nullable: false),
                    FromFloor = table.Column<int>(nullable: true),
                    ToElevator = table.Column<bool>(nullable: false),
                    ToFloor = table.Column<int>(nullable: true),
                    MobileElevatorID = table.Column<int>(nullable: false),
                    PackagingOptionID = table.Column<int>(nullable: false),
                    Montage = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CustomerPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFERS", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 3, 4, 39, 24, 589, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 3, 4, 39, 24, 590, DateTimeKind.Local).AddTicks(2587));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 30, 23, 45, 34, 776, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 30, 23, 45, 34, 777, DateTimeKind.Local).AddTicks(5209));
        }
    }
}
