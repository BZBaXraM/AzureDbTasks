using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniTurboAz.Mvc.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { new Guid("b52180f4-df96-40d7-a001-0d68778ea6c0"), "Aston Martin Lagonda Global Holdings plc is a British independent manufacturer of luxury sports cars and grand tourers. It was founded in 1913 by Lionel Martin and Robert Bamford. Steered from 1947 by David Brown, it became associated with expensive grand touring cars in the 1950s and 1960s, and with the fictional character James Bond following his use of a DB5 model in the 1964 film Goldfinger.", "https://myturbo.blob.core.windows.net/cars/Aston_Martin_Vantage_V8.jpeg", "Aston Martin" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { new Guid("ca0e0f54-3b09-47f8-8f41-ce438efbd9c6"), "Mercedes-Benz is both a German automotive marque and, from late 2019 onwards, a subsidiary – as Mercedes-Benz AG – of Daimler AG. Mercedes-Benz is known for producing luxury vehicles and commercial vehicles. The headquarters is in Stuttgart, Baden-Württemberg. The name first appeared in 1926 as Daimler-Benz.", "https://myturbo.blob.core.windows.net/cars/Mercedes-Benz-S-class-W223-2021-carhirebaku-1.jpeg", "Mercedes-Benz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
