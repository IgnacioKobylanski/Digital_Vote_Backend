using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalVote.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoterId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "Votes");
        }
    }
}
