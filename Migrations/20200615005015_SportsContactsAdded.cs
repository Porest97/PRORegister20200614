using Microsoft.EntityFrameworkCore.Migrations;

namespace PRORegister.Migrations
{
    public partial class SportsContactsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportsContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Club = table.Column<string>(nullable: true),
                    Team = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Sport = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LatsName = table.Column<string>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    Season = table.Column<string>(nullable: true),
                    AgeCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsContact", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsContact");
        }
    }
}
