using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashTag = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hashtags_Hashtags_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarUrl50 = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false),
                    NetworkId = table.Column<string>(nullable: true),
                    ProfileId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MediaType = table.Column<int>(nullable: false),
                    MessageText = table.Column<string>(nullable: true),
                    NetworkId = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaggedMessages",
                columns: table => new
                {
                    HashTagEntityId = table.Column<long>(nullable: false),
                    MessageEntityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedMessages", x => new { x.HashTagEntityId, x.MessageEntityId });
                    table.ForeignKey(
                        name: "FK_TaggedMessages_Hashtags_HashTagEntityId",
                        column: x => x.HashTagEntityId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedMessages_Messages_MessageEntityId",
                        column: x => x.MessageEntityId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_HashTag",
                table: "Hashtags",
                column: "HashTag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_ParentId",
                table: "Hashtags",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_NetworkId_UserId",
                table: "Messages",
                columns: new[] { "NetworkId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaggedMessages_MessageEntityId",
                table: "TaggedMessages",
                column: "MessageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NetworkId_MediaType",
                table: "Users",
                columns: new[] { "NetworkId", "MediaType" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaggedMessages");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
