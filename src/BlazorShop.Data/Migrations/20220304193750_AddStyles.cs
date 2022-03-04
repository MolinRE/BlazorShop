using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorShop.Data.Migrations
{
    public partial class AddStyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Beers",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_StyleId",
                table: "Beers",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_IsDeleted",
                table: "Styles",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Styles_StyleId",
                table: "Beers",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Styles_StyleId",
                table: "Beers");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Beers_StyleId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Beers");
        }
    }
}
