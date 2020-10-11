using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class Initial_EFCore_3_1_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    DevType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DatabaseStack = table.Column<bool>(nullable: true),
                    DatabasePreference = table.Column<string>(nullable: true),
                    MobileStack = table.Column<bool>(nullable: true),
                    FrameworkPreference = table.Column<string>(nullable: true),
                    CloudPreference = table.Column<string>(nullable: true),
                    ExtraMotivation_Factor = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motivation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factor = table.Column<string>(nullable: true),
                    DeveloperId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motivation_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DeveloperId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskToDo_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillTaskToDo",
                columns: table => new
                {
                    SkillsId = table.Column<long>(nullable: false),
                    TasksToDoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTaskToDo", x => new { x.SkillsId, x.TasksToDoId });
                    table.ForeignKey(
                        name: "FK_SkillTaskToDo_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTaskToDo_TaskToDo_TasksToDoId",
                        column: x => x.TasksToDoId,
                        principalTable: "TaskToDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motivation_DeveloperId",
                table: "Motivation",
                column: "DeveloperId",
                unique: true,
                filter: "[DeveloperId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTaskToDo_TasksToDoId",
                table: "SkillTaskToDo",
                column: "TasksToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_DeveloperId",
                table: "TaskToDo",
                column: "DeveloperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motivation");

            migrationBuilder.DropTable(
                name: "SkillTaskToDo");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "TaskToDo");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
