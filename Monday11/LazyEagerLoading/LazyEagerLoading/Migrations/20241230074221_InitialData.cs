using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LazyEagerLoading.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "Id", "CompanyName" },
                values: new object[,]
                {
                    { 1, "TCS" },
                    { 2, "Nimap" },
                    { 3, "Fyntune" },
                    { 4, "IDZ Digital" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "Id", "CompanyId", "EmpName" },
                values: new object[,]
                {
                    { 1, 1, "Swapnil" },
                    { 2, 1, "Mayur" },
                    { 3, 1, "Omkar" },
                    { 4, 2, "Omkar" },
                    { 5, 2, "Bhavesh" },
                    { 6, 2, "Jitesh Sir" },
                    { 7, 3, "Deepak" },
                    { 8, 3, "Vinay" },
                    { 9, 3, "Rahul" },
                    { 10, 4, "Yash" },
                    { 11, 4, "Rohit" },
                    { 12, 4, "Virat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_CompanyId",
                table: "employee",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
