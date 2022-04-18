using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class TimeidMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeDetails",
                table: "TimeDetails");

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "TimeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeDetails",
                table: "TimeDetails",
                column: "TimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeDetails",
                table: "TimeDetails");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "TimeDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeDetails",
                table: "TimeDetails",
                column: "PersonalFileNumber");
        }
    }
}
