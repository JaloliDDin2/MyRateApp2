using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRateApp2.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    UniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UniId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduateYear = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniId = table.Column<int>(type: "int", nullable: false),
                    UniversityUniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfId);
                    table.ForeignKey(
                        name: "FK_Professor_University_UniversityUniId",
                        column: x => x.UniversityUniId,
                        principalTable: "University",
                        principalColumn: "UniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniverRating",
                columns: table => new
                {
                    UniRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UniId = table.Column<int>(type: "int", nullable: false),
                    UniversityUniId = table.Column<int>(type: "int", nullable: true),
                    Reputation = table.Column<int>(type: "int", nullable: false),
                    Happiness = table.Column<int>(type: "int", nullable: false),
                    Safety = table.Column<int>(type: "int", nullable: false),
                    Opportunities = table.Column<int>(type: "int", nullable: false),
                    Facilities = table.Column<int>(type: "int", nullable: false),
                    Clubs = table.Column<int>(type: "int", nullable: false),
                    Internet = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Social = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniverRating", x => x.UniRatingId);
                    table.ForeignKey(
                        name: "FK_UniverRating_University_UniversityUniId",
                        column: x => x.UniversityUniId,
                        principalTable: "University",
                        principalColumn: "UniId");
                    table.ForeignKey(
                        name: "FK_UniverRating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorRating",
                columns: table => new
                {
                    ProfessorRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Awesome = table.Column<int>(type: "int", nullable: false),
                    Great = table.Column<int>(type: "int", nullable: false),
                    Awful = table.Column<int>(type: "int", nullable: false),
                    Good = table.Column<int>(type: "int", nullable: false),
                    Ok = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attendance = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    Textbook = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingQuality = table.Column<int>(type: "int", nullable: false),
                    RatingDificulty = table.Column<int>(type: "int", nullable: false),
                    WouldTakeAgain = table.Column<bool>(type: "bit", nullable: false),
                    ForCredit = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProfId = table.Column<int>(type: "int", nullable: false),
                    ProfessorProfId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorRating", x => x.ProfessorRatingId);
                    table.ForeignKey(
                        name: "FK_ProfessorRating_Professor_ProfessorProfId",
                        column: x => x.ProfessorProfId,
                        principalTable: "Professor",
                        principalColumn: "ProfId");
                    table.ForeignKey(
                        name: "FK_ProfessorRating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_UniversityUniId",
                table: "Professor",
                column: "UniversityUniId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorRating_ProfessorProfId",
                table: "ProfessorRating",
                column: "ProfessorProfId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorRating_UserId",
                table: "ProfessorRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UniverRating_UniversityUniId",
                table: "UniverRating",
                column: "UniversityUniId");

            migrationBuilder.CreateIndex(
                name: "IX_UniverRating_UserId",
                table: "UniverRating",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorRating");

            migrationBuilder.DropTable(
                name: "UniverRating");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
