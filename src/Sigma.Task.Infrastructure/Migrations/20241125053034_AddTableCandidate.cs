using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigma.Task.Infrastructure.Migrations
{
    public partial class AddTableCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CallSchedule = table.Column<DateTime>(type: "datetime", nullable: true),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GitHubProfile = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
