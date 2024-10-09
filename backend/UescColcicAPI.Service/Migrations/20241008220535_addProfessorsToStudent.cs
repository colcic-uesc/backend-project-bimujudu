using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class addProfessorsToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Professors_StudentId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessoId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfessoId",
                table: "Students",
                column: "ProfessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Professors_ProfessoId",
                table: "Students",
                column: "ProfessoId",
                principalTable: "Professors",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Professors_ProfessoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProfessoId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfessoId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Professors_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "Professors",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
