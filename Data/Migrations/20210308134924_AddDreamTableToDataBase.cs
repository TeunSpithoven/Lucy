using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucy.Data.Migrations
{
    public partial class AddDreamTableToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // maakt tabel in de database
            migrationBuilder.CreateTable(
                name: "Dream",
                columns: table => new
                {
                    // de kolommen in de tabel met hun eigenschappen
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    // constraint dat de primary key id moet zijn
                    table.PrimaryKey("PK_Category", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
