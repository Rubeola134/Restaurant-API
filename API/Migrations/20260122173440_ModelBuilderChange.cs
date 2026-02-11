using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModelBuilderChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId1",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestaurantId1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Dishes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId1",
                table: "Dishes",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId1",
                table: "Dishes",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
