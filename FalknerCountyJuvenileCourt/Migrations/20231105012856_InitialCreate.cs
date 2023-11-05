using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalknerCountyJuvenileCourt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrimeType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilingDecision",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilingDecision", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IntakeDecision",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntakeDecision", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Juveniles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceID = table.Column<int>(type: "INTEGER", nullable: false),
                    GenderID = table.Column<int>(type: "INTEGER", nullable: false),
                    Repeat = table.Column<bool>(type: "INTEGER", nullable: false),
                    RiskID = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juveniles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Juveniles_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Juveniles_Race_RaceID",
                        column: x => x.RaceID,
                        principalTable: "Race",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Juveniles_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Juveniles_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Crime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameID = table.Column<int>(type: "INTEGER", nullable: false),
                    FilingDecisionID = table.Column<int>(type: "INTEGER", nullable: false),
                    IntakeDecisionID = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: true),
                    DrugOffense = table.Column<bool>(type: "INTEGER", nullable: false),
                    DrugCourt = table.Column<bool>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JuvenileID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Crime_CrimeType_NameID",
                        column: x => x.NameID,
                        principalTable: "CrimeType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crime_FilingDecision_FilingDecisionID",
                        column: x => x.FilingDecisionID,
                        principalTable: "FilingDecision",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crime_IntakeDecision_IntakeDecisionID",
                        column: x => x.IntakeDecisionID,
                        principalTable: "IntakeDecision",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crime_Juveniles_JuvenileID",
                        column: x => x.JuvenileID,
                        principalTable: "Juveniles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crime_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crime_FilingDecisionID",
                table: "Crime",
                column: "FilingDecisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_IntakeDecisionID",
                table: "Crime",
                column: "IntakeDecisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_JuvenileID",
                table: "Crime",
                column: "JuvenileID");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_NameID",
                table: "Crime",
                column: "NameID");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_SchoolID",
                table: "Crime",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Juveniles_GenderID",
                table: "Juveniles",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Juveniles_RaceID",
                table: "Juveniles",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Juveniles_RiskID",
                table: "Juveniles",
                column: "RiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Juveniles_SchoolID",
                table: "Juveniles",
                column: "SchoolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crime");

            migrationBuilder.DropTable(
                name: "CrimeType");

            migrationBuilder.DropTable(
                name: "FilingDecision");

            migrationBuilder.DropTable(
                name: "IntakeDecision");

            migrationBuilder.DropTable(
                name: "Juveniles");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
