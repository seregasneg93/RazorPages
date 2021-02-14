using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Services.Migrations
{
    public partial class AddNewEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spAddNewEmployee
                                @Name nvarchar(100),
                                @Email nvarchar(100),
                                @PhotoPath nvarchar(100),
                                @Dept int
                                AS
                                BEGIN
                                    INSERT INTO Employees (Name,Email,PhotoPath,Departament)
                                    VALUES (@Name,@Email,@PhotoPath,@Dept)
                                END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spAddNewEmployee";

            migrationBuilder.Sql(procedure);
        }
    }
}
