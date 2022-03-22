using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInTime",
                table: "Staffs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutTime",
                table: "Staffs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClockInTime",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ClockOutTime",
                table: "Staffs");
        }
    }
}
