using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpBelt.Migrations
{
    public partial class activities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    activity_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    time = table.Column<TimeSpan>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    durationType = table.Column<string>(nullable: false),
                    coordinator_id = table.Column<int>(nullable: false),
                    Coordinatoruser_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_Activities_Users_Coordinatoruser_id",
                        column: x => x.Coordinatoruser_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    plan_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activity_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.plan_id);
                    table.ForeignKey(
                        name: "FK_Plans_Activities_activity_id",
                        column: x => x.activity_id,
                        principalTable: "Activities",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Coordinatoruser_id",
                table: "Activities",
                column: "Coordinatoruser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_activity_id",
                table: "Plans",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_user_id",
                table: "Plans",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
