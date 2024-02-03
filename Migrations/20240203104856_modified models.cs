using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifiedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int[]>(
                name: "SubscriptionIDs",
                table: "Customers",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionIDs",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
