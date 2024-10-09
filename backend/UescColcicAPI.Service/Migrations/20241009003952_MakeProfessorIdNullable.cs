using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class MakeProfessorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Projects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
