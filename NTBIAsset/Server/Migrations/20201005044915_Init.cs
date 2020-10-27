using Microsoft.EntityFrameworkCore.Migrations;

namespace NTBIAsset.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    Fixed_Asset_Code = table.Column<string>(nullable: false),
                    Fixed_Asset_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Uom = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PO_Number = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DR_Number = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date_Acquired = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Assigned = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stocks_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_DepartmentId",
                table: "stocks",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
