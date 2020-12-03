using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "ROOMCOUNT");

            migrationBuilder.DropColumn(
                name: "WayDiff",
                table: "FACTORS");

            migrationBuilder.AlterColumn<string>(
                name: "OpitonText",
                table: "MOBILEELEVATOR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "MOBILEELEVATOR",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MobileElevatorFactor",
                table: "FACTORS",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MobileElevatorIncrease",
                table: "FACTORS",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WayFactor",
                table: "FACTORS",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "FACTORS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MobileElevatorFactor", "MobileElevatorIncrease", "WayFactor" },
                values: new object[] { 350.0, 1.2, 3.0 });

            migrationBuilder.UpdateData(
                table: "MOBILEELEVATOR",
                keyColumn: "ID",
                keyValue: 1,
                column: "Text",
                value: "from");

            migrationBuilder.UpdateData(
                table: "MOBILEELEVATOR",
                keyColumn: "ID",
                keyValue: 2,
                column: "Text",
                value: "to");

            migrationBuilder.UpdateData(
                table: "MOBILEELEVATOR",
                keyColumn: "ID",
                keyValue: 3,
                column: "Text",
                value: "both");

            migrationBuilder.UpdateData(
                table: "MOBILEELEVATOR",
                keyColumn: "ID",
                keyValue: 4,
                column: "Text",
                value: "no");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "MOBILEELEVATOR");

            migrationBuilder.DropColumn(
                name: "MobileElevatorFactor",
                table: "FACTORS");

            migrationBuilder.DropColumn(
                name: "MobileElevatorIncrease",
                table: "FACTORS");

            migrationBuilder.DropColumn(
                name: "WayFactor",
                table: "FACTORS");

            migrationBuilder.AddColumn<double>(
                name: "BasePrice",
                table: "ROOMCOUNT",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "OpitonText",
                table: "MOBILEELEVATOR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<double>(
                name: "WayDiff",
                table: "FACTORS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "FACTORS",
                keyColumn: "ID",
                keyValue: 1,
                column: "WayDiff",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "ROOMCOUNT",
                keyColumn: "ID",
                keyValue: 1,
                column: "BasePrice",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ROOMCOUNT",
                keyColumn: "ID",
                keyValue: 2,
                column: "BasePrice",
                value: 500.0);

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
    }
}
