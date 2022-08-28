using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class updateEntityDbContext : Migration
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
                name: "CreatedDate",
                table: "UserRoom",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserRoom");

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
