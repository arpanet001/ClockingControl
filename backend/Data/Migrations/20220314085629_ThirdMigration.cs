using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staffs");
        }
    }
}
