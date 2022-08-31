using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternBA.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reaction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attachments_Posts_PostID1",
                        column: x => x.PostID1,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Video = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AttachmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Attachments_AttachmentID",
                        column: x => x.AttachmentID,
                        principalTable: "Attachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reactions_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_PostID1",
                table: "Attachments",
                column: "PostID1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AttachmentID",
                table: "Categories",
                column: "AttachmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PostID",
                table: "Categories",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentID",
                table: "Reactions",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostID",
                table: "Reactions",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
