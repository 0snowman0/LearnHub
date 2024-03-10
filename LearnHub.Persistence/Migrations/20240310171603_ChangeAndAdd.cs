using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAndAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permistion_Ens_adminProfile_Ens_AdminProfile_EnId",
                table: "permistion_Ens");

            migrationBuilder.DropIndex(
                name: "IX_permistion_Ens_AdminProfile_EnId",
                table: "permistion_Ens");

            migrationBuilder.DropColumn(
                name: "AdminProfile_EnId",
                table: "permistion_Ens");

            migrationBuilder.AddColumn<int>(
                name: "role_Em",
                table: "user_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "permistion_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "permistion_EnId",
                table: "adminProfile_Ens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_adminProfile_Ens_permistion_EnId",
                table: "adminProfile_Ens",
                column: "permistion_EnId");

            migrationBuilder.AddForeignKey(
                name: "FK_adminProfile_Ens_permistion_Ens_permistion_EnId",
                table: "adminProfile_Ens",
                column: "permistion_EnId",
                principalTable: "permistion_Ens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adminProfile_Ens_permistion_Ens_permistion_EnId",
                table: "adminProfile_Ens");

            migrationBuilder.DropIndex(
                name: "IX_adminProfile_Ens_permistion_EnId",
                table: "adminProfile_Ens");

            migrationBuilder.DropColumn(
                name: "role_Em",
                table: "user_Ens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "permistion_Ens");

            migrationBuilder.DropColumn(
                name: "permistion_EnId",
                table: "adminProfile_Ens");

            migrationBuilder.AddColumn<int>(
                name: "AdminProfile_EnId",
                table: "permistion_Ens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_permistion_Ens_AdminProfile_EnId",
                table: "permistion_Ens",
                column: "AdminProfile_EnId");

            migrationBuilder.AddForeignKey(
                name: "FK_permistion_Ens_adminProfile_Ens_AdminProfile_EnId",
                table: "permistion_Ens",
                column: "AdminProfile_EnId",
                principalTable: "adminProfile_Ens",
                principalColumn: "Id");
        }
    }
}
