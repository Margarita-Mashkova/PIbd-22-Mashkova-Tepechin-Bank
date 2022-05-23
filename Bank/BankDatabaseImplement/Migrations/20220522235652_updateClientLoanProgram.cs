using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDatabaseImplement.Migrations
{
    public partial class updateClientLoanProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ClientLoanPrograms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ClientLoanPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
