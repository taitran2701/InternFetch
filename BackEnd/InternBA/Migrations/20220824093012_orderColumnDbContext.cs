using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class orderColumnDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "UserRoom",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "UserRoom",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
