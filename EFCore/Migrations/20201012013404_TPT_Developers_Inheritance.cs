using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class TPT_Developers_Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloudPreference",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "DatabasePreference",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "DatabaseStack",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "ExtraMotivation_Factor",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "FrameworkPreference",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "MobileStack",
                table: "Developer");

            migrationBuilder.CreateTable(
                name: "BackEndDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatabaseStack = table.Column<bool>(type: "bit", nullable: false),
                    DatabasePreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackEndDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackEndDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrontEndDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileStack = table.Column<bool>(type: "bit", nullable: false),
                    FrameworkPreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontEndDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontEndDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FullStackDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CloudPreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraMotivation_Factor = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullStackDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullStackDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackEndDeveloper");

            migrationBuilder.DropTable(
                name: "FrontEndDeveloper");

            migrationBuilder.DropTable(
                name: "FullStackDeveloper");

            migrationBuilder.AddColumn<string>(
                name: "CloudPreference",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatabasePreference",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DatabaseStack",
                table: "Developer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraMotivation_Factor",
                table: "Developer",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrameworkPreference",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MobileStack",
                table: "Developer",
                type: "bit",
                nullable: true);
        }
    }
}
