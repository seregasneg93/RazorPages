using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Services.Migrations
{
    public partial class CodeFirstSpGetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure CodeFirstSpGetEmployeeById
                                 @Id int
                                 AS
                                 BEGIN
                                    SELECT * from Employees
                                    WHERE Id = @Id
                                 END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure CodeFirstSpGetEmployeeById";

            migrationBuilder.Sql(procedure);
        }
    }
}
