using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameyMcThingy.Data.Migrations
{
    public partial class AddUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OwnerId",
                table: "Ratings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserEntityId",
                table: "Ratings",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Ratings_OwnerId",
                table: "Ratings",
                column: "OwnerId",
                principalTable: "Ratings",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserEntityId",
                table: "Ratings",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Ratings_OwnerId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserEntityId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_OwnerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserEntityId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Ratings");
        }
    }
}
