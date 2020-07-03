using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testCore.Migrations
{
    public partial class InitialSkiCardContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkiCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CardHolderFirstName = table.Column<string>(maxLength: 70, nullable: false),
                    CardHolderLastName = table.Column<string>(maxLength: 70, nullable: true),
                    CardHolderBirthDate = table.Column<DateTime>(nullable: false),
                    CardHolderPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkiCards");
        }
    }
}
