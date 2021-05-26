using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIB.PhoneBook.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneBookEntry",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBookEntry", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBookEntry_Name",
                table: "PhoneBookEntry",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBookEntry");
        }
    }
}
