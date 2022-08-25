using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class updateAttachmentStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_PostID1",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Attachments_AttachmentID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AttachmentID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PostID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_PostID1",
                table: "Attachments");

            

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AttachmentID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostID1",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Attachments",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReactionID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Attachments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CategoryId",
                table: "Attachments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_PostID",
                table: "Attachments",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Categories_CategoryId",
                table: "Attachments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Posts_PostID",
                table: "Attachments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Categories_CategoryId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_PostID",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CategoryId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_PostID",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Attachments",
                newName: "CategoryID");

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommentID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReactionID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentID",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostID1",
                table: "Attachments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AttachmentID",
                table: "Categories",
                column: "AttachmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PostID",
                table: "Categories",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_PostID1",
                table: "Attachments",
                column: "PostID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Posts_PostID1",
                table: "Attachments",
                column: "PostID1",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Attachments_AttachmentID",
                table: "Categories",
                column: "AttachmentID",
                principalTable: "Attachments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_PostID",
                table: "Categories",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID");
        }
    }
}
