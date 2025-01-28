using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    var workCategoryId = Guid.NewGuid();
    var personalCategoryId = Guid.NewGuid();
    var healthCategoryId = Guid.NewGuid();

    migrationBuilder.InsertData(
        table: "Categories",
        columns: new[] { "Id", "Name" },
        values: new object[,]
        {
            { workCategoryId, "Work" },
            { personalCategoryId, "Personal" },
            { healthCategoryId, "Health" }
        });

    migrationBuilder.InsertData(
        table: "ToDoItems",
        columns: new[] { "Id", "Title", "IsCompleted", "CategoryId" },
        values: new object[,]
        {
            { Guid.NewGuid(), "Complete project report", false, workCategoryId },
            { Guid.NewGuid(), "Buy groceries", false, personalCategoryId },
            { Guid.NewGuid(), "Go to the gym", true, healthCategoryId },
            { Guid.NewGuid(), "Plan vacation", false, personalCategoryId }
        });
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DeleteData(
        table: "ToDoItems",
        keyColumn: "Title",
        keyValues: new object[]
        {
            "Complete project report",
            "Buy groceries",
            "Go to the gym",
            "Plan vacation"
        });

    migrationBuilder.DeleteData(
        table: "Categories",
        keyColumn: "Name",
        keyValues: new object[]
        {
            "Work",
            "Personal",
            "Health"
        });
}

    }
}
