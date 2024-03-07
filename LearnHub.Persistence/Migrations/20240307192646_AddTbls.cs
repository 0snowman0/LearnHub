using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminProfile_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminProfile_Ens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentProfile_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentProfile_Ens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teacherProfile_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherProfile_Ens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permistion_Ens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Support = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<bool>(type: "bit", nullable: false),
                    Financial = table.Column<bool>(type: "bit", nullable: false),
                    Course = table.Column<bool>(type: "bit", nullable: false),
                    AdminProfile_EnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permistion_Ens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permistion_Ens_adminProfile_Ens_AdminProfile_EnId",
                        column: x => x.AdminProfile_EnId,
                        principalTable: "adminProfile_Ens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_permistion_Ens_AdminProfile_EnId",
                table: "permistion_Ens",
                column: "AdminProfile_EnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permistion_Ens");

            migrationBuilder.DropTable(
                name: "studentProfile_Ens");

            migrationBuilder.DropTable(
                name: "teacherProfile_Ens");

            migrationBuilder.DropTable(
                name: "adminProfile_Ens");
        }
    }
}
