using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class tweakedmodels111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Customers",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Customers",
                newName: "createdAt");
        }
    }
}
