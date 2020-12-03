using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TransportDate",
                table: "RESERVATIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "RESERVATIONS",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "OFFERS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "OFFERS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "OFFERS",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OfferPrice",
                table: "OFFERS",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransportDate",
                table: "OFFERS",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RESERVATIONS",
                keyColumn: "ID",
                keyValue: 2,
                column: "TransportDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 3, 23, 0, 59, 287, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "SHIPPERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 3, 23, 0, 59, 287, DateTimeKind.Local).AddTicks(7481));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "RESERVATIONS");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "OFFERS");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "OFFERS");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "OFFERS");

            migrationBuilder.DropColumn(
                name: "OfferPrice",
                table: "OFFERS");

            migrationBuilder.DropColumn(
                name: "TransportDate",
                table: "OFFERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransportDate",
                table: "RESERVATIONS",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RESERVATIONS",
                keyColumn: "ID",
                keyValue: 2,
                column: "TransportDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
