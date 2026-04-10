using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalVote.API.Migrations
{
    public partial class NormalizingPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.Sql("INSERT INTO Positions (Name) VALUES ('Presidente');");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("UPDATE Candidates SET PositionId = 1 WHERE Position = 'Presidente';");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Candidates");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Candidates",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PositionId",
                table: "Candidates",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_PositionId",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Candidates",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.Sql("UPDATE Candidates c INNER JOIN Positions p ON c.PositionId = p.Id SET c.Position = p.Name;");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}