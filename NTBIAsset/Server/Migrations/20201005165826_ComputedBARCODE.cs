using Microsoft.EntityFrameworkCore.Migrations;

namespace NTBIAsset.Server.Migrations
{
    public partial class ComputedBARCODE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "stocks",
                type: "nvarchar(10)",
                nullable: true,
                computedColumnSql: "('FXT'+right('0000000'+CONVERT([varchar](6),[Id],(0)),(7)))",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "stocks",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true,
                oldComputedColumnSql: "('FXT'+right('0000000'+CONVERT([varchar](6),[Id],(0)),(7)))");
        }
    }
}
