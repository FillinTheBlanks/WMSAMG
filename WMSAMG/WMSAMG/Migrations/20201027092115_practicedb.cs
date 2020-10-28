using Microsoft.EntityFrameworkCore.Migrations;

namespace WMSAMG.Migrations
{
    public partial class practicedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dept_Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__8985FE74043BF62F", x => x.Dept_Code);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(unicode: false, nullable: true),
                    Emp_City = table.Column<string>(unicode: false, nullable: true),
                    Emp_Age = table.Column<int>(nullable: true),
                    Dept_Code = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Emp_Id);
                    table.ForeignKey(
                        name: "FK_employees_ToDepartment",
                        column: x => x.Dept_Code,
                        principalTable: "Department",
                        principalColumn: "Dept_Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_Dept_Code",
                table: "employees",
                column: "Dept_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
