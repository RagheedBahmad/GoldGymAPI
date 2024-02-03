using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class tweakedmodels10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Services_ServiceId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ServiceId",
                table: "Subscriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ServiceId",
                table: "Subscriptions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Services_ServiceId",
                table: "Subscriptions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
