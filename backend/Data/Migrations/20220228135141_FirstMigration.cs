using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clockingapi.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regnumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
