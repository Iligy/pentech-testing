using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenchmarkDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PerformanceNotes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankNotes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelephoneAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelephoneNotes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesNoAnnotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformanceNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesNoAnnotations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeesNoAnnotations");
        }
    }
}
