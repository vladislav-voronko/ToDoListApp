using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class SetRuleOnDeleteCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Categories_CategoryId",
                table: "ToDoItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Categories_CategoryId",
                table: "ToDoItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Categories_CategoryId",
                table: "ToDoItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Categories_CategoryId",
                table: "ToDoItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
