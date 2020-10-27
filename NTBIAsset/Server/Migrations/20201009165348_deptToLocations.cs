using Microsoft.EntityFrameworkCore.Migrations;

namespace NTBIAsset.Server.Migrations
{
    public partial class deptToLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_departments_DepartmentId",
                table: "stocks");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropIndex(
                name: "IX_stocks_DepartmentId",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "stocks");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_LocationId",
                table: "stocks",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_locations_LocationId",
                table: "stocks",
                column: "LocationId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_locations_LocationId",
                table: "stocks");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropIndex(
                name: "IX_stocks_LocationId",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "stocks");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "stocks",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_DepartmentId",
                table: "stocks",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_departments_DepartmentId",
                table: "stocks",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
