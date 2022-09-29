using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class updatePostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories");

            

            migrationBuilder.AlterColumn<Guid>(
                name: "PostID",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PostID",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
