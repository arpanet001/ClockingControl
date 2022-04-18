using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class clockingmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clockings",
                columns: table => new
                {
                    PersonalFileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clockings", x => x.PersonalFileNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clockings");
        }
    }
}
