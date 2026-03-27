using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalVote.API.Migrations
{
    /// <inheritdoc />
    public partial class NormalizingPartiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateImageUrl",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PartyLogoUrl",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Party",
                table: "Candidates",
                newName: "CandidateImg");

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PartyId",
                table: "Candidates",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Parties_PartyId",
                table: "Candidates",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Parties_PartyId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_PartyId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "CandidateImg",
                table: "Candidates",
                newName: "Party");

            migrationBuilder.AddColumn<string>(
                name: "CandidateImageUrl",
                table: "Candidates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PartyLogoUrl",
                table: "Candidates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
