using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalknerCountyJuvenileCourt.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_CrimeType_CrimeTypeID",
                table: "Crime");

            migrationBuilder.DropTable(
                name: "CrimeType");

            migrationBuilder.RenameColumn(
                name: "CrimeTypeID",
                table: "Crime",
                newName: "OffenseID");

            migrationBuilder.RenameIndex(
                name: "IX_Crime_CrimeTypeID",
                table: "Crime",
                newName: "IX_Crime_OffenseID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IntakeDecision",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gender",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FilingDecision",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Offense",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offense", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_Offense_OffenseID",
                table: "Crime",
                column: "OffenseID",
                principalTable: "Offense",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_Offense_OffenseID",
                table: "Crime");

            migrationBuilder.DropTable(
                name: "Offense");

            migrationBuilder.RenameColumn(
                name: "OffenseID",
                table: "Crime",
                newName: "CrimeTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Crime_OffenseID",
                table: "Crime",
                newName: "IX_Crime_CrimeTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "IntakeDecision",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Gender",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "FilingDecision",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_CrimeType_CrimeTypeID",
                table: "Crime",
                column: "CrimeTypeID",
                principalTable: "CrimeType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
