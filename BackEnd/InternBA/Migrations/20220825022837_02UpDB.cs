using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class _02UpDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "ID");


            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "UserRoom",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "UserRoom",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserRoom",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms");


            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "Id");
        }
    }
}
