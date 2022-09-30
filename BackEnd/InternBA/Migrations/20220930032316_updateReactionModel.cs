using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class updateReactionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Users_UserID",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_UserID",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Reactions");
        }
    }
}
