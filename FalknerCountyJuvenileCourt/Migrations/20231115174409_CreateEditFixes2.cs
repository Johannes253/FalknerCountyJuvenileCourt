using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalknerCountyJuvenileCourt.Migrations
{
    /// <inheritdoc />
    public partial class CreateEditFixes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_FilingDecision_FilingDecisionID",
                table: "Crime");

            migrationBuilder.DropForeignKey(
                name: "FK_Crime_IntakeDecision_IntakeDecisionID",
                table: "Crime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntakeDecision",
                table: "IntakeDecision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilingDecision",
                table: "FilingDecision");

            migrationBuilder.RenameTable(
                name: "IntakeDecision",
                newName: "Intake Decision");

            migrationBuilder.RenameTable(
                name: "FilingDecision",
                newName: "Filing Decision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intake Decision",
                table: "Intake Decision",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filing Decision",
                table: "Filing Decision",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_Filing Decision_FilingDecisionID",
                table: "Crime",
                column: "FilingDecisionID",
                principalTable: "Filing Decision",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_Intake Decision_IntakeDecisionID",
                table: "Crime",
                column: "IntakeDecisionID",
                principalTable: "Intake Decision",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_Filing Decision_FilingDecisionID",
                table: "Crime");

            migrationBuilder.DropForeignKey(
                name: "FK_Crime_Intake Decision_IntakeDecisionID",
                table: "Crime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intake Decision",
                table: "Intake Decision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filing Decision",
                table: "Filing Decision");

            migrationBuilder.RenameTable(
                name: "Intake Decision",
                newName: "IntakeDecision");

            migrationBuilder.RenameTable(
                name: "Filing Decision",
                newName: "FilingDecision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntakeDecision",
                table: "IntakeDecision",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilingDecision",
                table: "FilingDecision",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_FilingDecision_FilingDecisionID",
                table: "Crime",
                column: "FilingDecisionID",
                principalTable: "FilingDecision",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_IntakeDecision_IntakeDecisionID",
                table: "Crime",
                column: "IntakeDecisionID",
                principalTable: "IntakeDecision",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
