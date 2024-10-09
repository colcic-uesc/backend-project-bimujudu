using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoRelac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfessorId",
                table: "Students",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Professors_ProfessorId",
                table: "Students",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Professors_ProfessorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProfessorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Students");

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
    }
}
