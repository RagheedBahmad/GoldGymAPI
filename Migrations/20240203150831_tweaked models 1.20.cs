using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class tweakedmodels120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionIDs",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Subscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<int>>(
                name: "SubscriptionIDs",
                table: "Customers",
                type: "integer[]",
                nullable: false);
        }
    }
}
