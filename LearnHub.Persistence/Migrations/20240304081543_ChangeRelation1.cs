using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCourse_Ens_course_Ens_{courseId}",
                table: "subCourse_Ens");

            migrationBuilder.DropIndex(
                name: "IX_subCourse_Ens_{courseId}",
                table: "subCourse_Ens");

            migrationBuilder.DropColumn(
                name: "{courseId}",
                table: "subCourse_Ens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "{courseId}",
                table: "subCourse_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subCourse_Ens_{courseId}",
                table: "subCourse_Ens",
                column: "{courseId}");

            migrationBuilder.AddForeignKey(
                name: "FK_subCourse_Ens_course_Ens_{courseId}",
                table: "subCourse_Ens",
                column: "{courseId}",
                principalTable: "course_Ens",
                principalColumn: "Id");
        }
    }
}
