using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekat.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Country_CountryId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_Clients_ClientId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_ClientId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Country");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Clients",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CountryId",
                table: "Clients",
                newName: "IX_Clients_countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Country_countryId",
                table: "Clients",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Country_countryId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Clients",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_countryId",
                table: "Clients",
                newName: "IX_Clients_CountryId");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Country",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_ClientId",
                table: "Country",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Country_CountryId",
                table: "Clients",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Clients_ClientId",
                table: "Country",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
