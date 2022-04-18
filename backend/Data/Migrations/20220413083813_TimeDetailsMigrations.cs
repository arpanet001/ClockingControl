using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class TimeDetailsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClockInTime",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ClockOutTime",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staffs");

            migrationBuilder.CreateTable(
                name: "TimeDetails",
                columns: table => new
                {
                    PersonalFileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClockInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockOutTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDetails", x => x.PersonalFileNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeDetails");

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 6);

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Active", "Department", "DepartmentId", "Designation", "Discriminator", "FirstName", "LastName", "PersonalFileNumber", "Registered" },
                values: new object[,]
                {
                    { 1, "Yes/No", "The Staff's 1 Department is ", "The Staff's 1 DepartmentId is ", "The Staff's 1 Role is ", "Staff", "The Staff's 1 FirstName is ", "The Staff's 1 LastName is  ", "The Staff's 1 PersonalFileNumber is ", "Yes/No" },
                    { 2, "Yes/No", "The Staff's 2 Department is ", "The Staff's 2 DepartmentId is ", "The Staff's 2 Role is ", "Staff", "The Staff's 2 FirstName is ", "The Staff's 2 LastName is  ", "The Staff's 2 PersonalFileNumber is ", "Yes/No" },
                    { 3, "Yes/No", "The Staff's 3 Department is ", "The Staff's 3 DepartmentId is ", "The Staff's 3 Role is ", "Staff", "The Staff's 3 FirstName is ", "The Staff's 3 LastName is  ", "The Staff's 3 PersonalFileNumber is ", "Yes/No" },
                    { 4, "Yes/No", "The Staff's 4 Department is ", "The Staff's 4 DepartmentId is ", "The Staff's 4 Role is ", "Staff", "The Staff's 4 FirstName is ", "The Staff's 4 LastName is  ", "The Staff's 4 PersonalFileNumber is ", "Yes/No" },
                    { 5, "Yes/No", "The Staff's 5 Department is ", "The Staff's 5 DepartmentId is ", "The Staff's 5 Role is ", "Staff", "The Staff's 5 FirstName is ", "The Staff's 5 LastName is  ", "The Staff's 5 PersonalFileNumber is ", "Yes/No" },
                    { 6, "Yes/No", "The Staff's 6 Department is ", "The Staff's 6 DepartmentId is ", "The Staff's 6 Role is ", "Staff", "The Staff's 6 FirstName is ", "The Staff's 6 LastName is  ", "The Staff's 6 PersonalFileNumber is ", "Yes/No" }
                });
        }
    }
}
