using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class updatePostModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "Posts",
                newName: "CategoryID");
        }
    }
}
