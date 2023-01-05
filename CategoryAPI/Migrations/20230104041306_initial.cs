using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CategoryAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogueBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatelogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatelogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatelogueItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatelogueItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatelogueItems_CatalogueBrands_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogueBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatelogueItems_CatelogTypes_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatelogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatelogueItems_CatalogBrandId",
                table: "CatelogueItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatelogueItems_CatalogTypeId",
                table: "CatelogueItems",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatelogueItems");

            migrationBuilder.DropTable(
                name: "CatalogueBrands");

            migrationBuilder.DropTable(
                name: "CatelogTypes");
        }
    }
}
