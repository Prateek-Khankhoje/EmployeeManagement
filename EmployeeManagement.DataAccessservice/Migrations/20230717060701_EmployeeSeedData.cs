using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.DataAccessservice.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Age", "EmailId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 50, "TomHanks@gmail.com", "Tom", "Hanks" },
                    { 2, 40, "MattDamon@gmail.com", "Matt", "Damon" },
                    { 3, 70, "MorganFreeman@gmail.com", "Morgan", "Freeman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
