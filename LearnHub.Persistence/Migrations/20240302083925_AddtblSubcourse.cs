using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddtblSubcourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subCourse_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCourse = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    courseId0 = table.Column<int>(name: "{courseId}", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCourse_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subCourse_Ens_course_Ens_{courseId}",
                        column: x => x.courseId0,
                        principalTable: "course_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_subCourse_Ens_{courseId}",
                table: "subCourse_Ens",
                column: "{courseId}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subCourse_Ens");
        }
    }
}
