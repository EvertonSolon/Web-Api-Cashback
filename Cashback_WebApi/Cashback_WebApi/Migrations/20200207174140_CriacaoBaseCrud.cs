using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cashback_WebApi.Migrations
{
    public partial class CriacaoBaseCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Compras",
                newName: "DataCompra");

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Compras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Compras",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Cashbackes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Cashbackes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Cashbackes");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Cashbackes");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "Compras",
                newName: "Data");
        }
    }
}
