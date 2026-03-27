using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalVote.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingPartyToVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidateId",
                table: "Votes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PartyId",
                table: "Votes",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Candidates_CandidateId",
                table: "Votes",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Parties_PartyId",
                table: "Votes",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Candidates_CandidateId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Parties_PartyId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_CandidateId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_PartyId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Votes");
        }
    }
}
