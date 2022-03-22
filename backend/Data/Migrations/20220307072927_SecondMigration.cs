using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalFileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Registered = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Active", "Department", "DepartmentId", "Designation", "FirstName", "LastName", "PersonalFileNumber", "Registered" },
                values: new object[,]
                {
                    { 1, "Yes/No", "The Staff's 1 Department is ", "The Staff's 1 DepartmentId is ", "The Staff's 1 Role is ", "The Staff's 1 FirstName is ", "The Staff's 1 LastName is  ", "The Staff's 1 PersonalFileNumber is ", "Yes/No" },
                    { 2, "Yes/No", "The Staff's 2 Department is ", "The Staff's 2 DepartmentId is ", "The Staff's 2 Role is ", "The Staff's 2 FirstName is ", "The Staff's 2 LastName is  ", "The Staff's 2 PersonalFileNumber is ", "Yes/No" },
                    { 3, "Yes/No", "The Staff's 3 Department is ", "The Staff's 3 DepartmentId is ", "The Staff's 3 Role is ", "The Staff's 3 FirstName is ", "The Staff's 3 LastName is  ", "The Staff's 3 PersonalFileNumber is ", "Yes/No" },
                    { 4, "Yes/No", "The Staff's 4 Department is ", "The Staff's 4 DepartmentId is ", "The Staff's 4 Role is ", "The Staff's 4 FirstName is ", "The Staff's 4 LastName is  ", "The Staff's 4 PersonalFileNumber is ", "Yes/No" },
                    { 5, "Yes/No", "The Staff's 5 Department is ", "The Staff's 5 DepartmentId is ", "The Staff's 5 Role is ", "The Staff's 5 FirstName is ", "The Staff's 5 LastName is  ", "The Staff's 5 PersonalFileNumber is ", "Yes/No" },
                    { 6, "Yes/No", "The Staff's 6 Department is ", "The Staff's 6 DepartmentId is ", "The Staff's 6 Role is ", "The Staff's 6 FirstName is ", "The Staff's 6 LastName is  ", "The Staff's 6 PersonalFileNumber is ", "Yes/No" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Regnumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "Regnumber", "Role" },
                values: new object[,]
                {
                    { 1, "The User's 1 FirstName is ", "The User's 1 LastName is  ", "The User's 1 RegNumber is ", "The User's 1 Role is " },
                    { 2, "The User's 2 FirstName is ", "The User's 2 LastName is  ", "The User's 2 RegNumber is ", "The User's 2 Role is " },
                    { 3, "The User's 3 FirstName is ", "The User's 3 LastName is  ", "The User's 3 RegNumber is ", "The User's 3 Role is " },
                    { 4, "The User's 4 FirstName is ", "The User's 4 LastName is  ", "The User's 4 RegNumber is ", "The User's 4 Role is " },
                    { 5, "The User's 5 FirstName is ", "The User's 5 LastName is  ", "The User's 5 RegNumber is ", "The User's 5 Role is " },
                    { 6, "The User's 6 FirstName is ", "The User's 6 LastName is  ", "The User's 6 RegNumber is ", "The User's 6 Role is " }
                });
        }
    }
}
