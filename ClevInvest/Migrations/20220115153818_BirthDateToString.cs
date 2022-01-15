using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClevInvest.Migrations
{
    public partial class BirthDateToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
