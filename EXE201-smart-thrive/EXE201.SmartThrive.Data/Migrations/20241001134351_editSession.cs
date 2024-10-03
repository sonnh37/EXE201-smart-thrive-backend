using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201.SmartThrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class editSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "SessionMeeting",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SessionMeeting");
        }
    }
}
