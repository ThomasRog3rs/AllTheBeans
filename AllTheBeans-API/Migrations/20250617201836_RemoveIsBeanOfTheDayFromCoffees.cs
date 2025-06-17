using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllTheBeans_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsBeanOfTheDayFromCoffees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBeanOfTheDay",
                table: "Coffees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBeanOfTheDay",
                table: "Coffees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
