using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeINuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender_Em",
                table: "user_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender_Em",
                table: "user_Ens");
        }
    }
}
