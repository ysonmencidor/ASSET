using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NTBIAsset.Server.Migrations
{
    public partial class UpdateStockModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uom",
                table: "stocks",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Acquired",
                table: "stocks",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "stocks",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uom",
                table: "stocks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date_Acquired",
                table: "stocks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "stocks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
