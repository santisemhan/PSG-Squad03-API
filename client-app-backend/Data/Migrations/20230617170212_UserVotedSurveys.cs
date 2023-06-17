using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace client_app_backend.Data.Migrations
{
    public partial class UserVotedSurveys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyUser",
                columns: table => new
                {
                    VotedSurveysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotedUsersEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyUser", x => new { x.VotedSurveysId, x.VotedUsersEmail });
                    table.ForeignKey(
                        name: "FK_SurveyUser_Survey_VotedSurveysId",
                        column: x => x.VotedSurveysId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyUser_User_VotedUsersEmail",
                        column: x => x.VotedUsersEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUser_VotedUsersEmail",
                table: "SurveyUser",
                column: "VotedUsersEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyUser");
        }
    }
}
