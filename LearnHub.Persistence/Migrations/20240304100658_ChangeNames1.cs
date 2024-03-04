using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNames1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseVideo",
                table: "course_Ens",
                newName: "CourseVideoName");

            migrationBuilder.RenameColumn(
                name: "CourseImage",
                table: "course_Ens",
                newName: "CourseImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseVideoName",
                table: "course_Ens",
                newName: "CourseVideo");

            migrationBuilder.RenameColumn(
                name: "CourseImageName",
                table: "course_Ens",
                newName: "CourseImage");
        }
    }
}
