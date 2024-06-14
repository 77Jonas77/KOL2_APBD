using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KOL2_APBD_S27523.Migrations
{
    /// <inheritdoc />
    public partial class p1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    current_weig = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<int>(type: "int", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    weig = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nam = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Backpack_Slots",
                columns: table => new
                {
                    FK_item = table.Column<int>(type: "int", nullable: false),
                    FK_character = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack_Slots", x => new { x.FK_character, x.FK_item });
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Characters_FK_character",
                        column: x => x.FK_character,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Items_FK_item",
                        column: x => x.FK_item,
                        principalTable: "Items",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character_Titles",
                columns: table => new
                {
                    FK_charact = table.Column<int>(type: "int", nullable: false),
                    FK_title = table.Column<int>(type: "int", nullable: false),
                    aquire_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Titles", x => new { x.FK_charact, x.FK_title });
                    table.ForeignKey(
                        name: "FK_Character_Titles_Characters_FK_charact",
                        column: x => x.FK_charact,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Titles_Titles_FK_title",
                        column: x => x.FK_title,
                        principalTable: "Titles",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "PK", "current_weig", "first_name", "last_name", "max_weight", "money" },
                values: new object[,]
                {
                    { 1, 20, "Geralt", "of Rivia", 100, 1000 },
                    { 2, 10, "Yennefer", "of Vengerberg", 80, 500 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "PK", "name", "weig" },
                values: new object[,]
                {
                    { 1, "Steel Sword", 5 },
                    { 2, "Silver Sword", 6 },
                    { 3, "Witcher Medallion", 1 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "PK", "nam" },
                values: new object[,]
                {
                    { 1, "Witcher" },
                    { 2, "Sorceress" }
                });

            migrationBuilder.InsertData(
                table: "Backpack_Slots",
                columns: new[] { "FK_character", "FK_item", "PK" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 2, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Character_Titles",
                columns: new[] { "FK_charact", "FK_title", "aquire_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 15, 14, 30, 31, 718, DateTimeKind.Local).AddTicks(2030) },
                    { 2, 2, new DateTime(2024, 5, 25, 14, 30, 31, 718, DateTimeKind.Local).AddTicks(2120) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_FK_item",
                table: "Backpack_Slots",
                column: "FK_item");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Titles_FK_title",
                table: "Character_Titles",
                column: "FK_title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack_Slots");

            migrationBuilder.DropTable(
                name: "Character_Titles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
