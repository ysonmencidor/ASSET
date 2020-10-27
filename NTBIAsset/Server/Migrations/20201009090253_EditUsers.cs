using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NTBIAsset.Server.Migrations
{
    public partial class EditUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "userAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "userAccounts",
                type: "smalldatetime",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "userAccounts");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "userAccounts");
        }
    }
}
