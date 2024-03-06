using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Change3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "payment_Ens");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "payment_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoursePrice",
                table: "course_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "coursePpurchased_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    purchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursePpurchased_Ens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursePpurchased_Ens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "payment_Ens");

            migrationBuilder.DropColumn(
                name: "CoursePrice",
                table: "course_Ens");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "payment_Ens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
