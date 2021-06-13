using Microsoft.EntityFrameworkCore.Migrations;

namespace View.Migrations
{
    public partial class AddDreamIdToCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DreamId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DreamId",
                table: "Comment");
        }
    }
}
