using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestAPIDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestId);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "PersonInterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Playing football on weekends", "Football" },
                    { 2, "Trying out new recipes", "Cooking" },
                    { 3, "Landscape photography", "Photography" },
                    { 4, "Reading novels and articles", "Reading" },
                    { 5, "Video games and board games", "Gaming" },
                    { 6, "Playing instruments or singing", "Music" },
                    { 7, "Exploring nature trails", "Hiking" },
                    { 8, "Creating artwork", "Painting" },
                    { 9, "Visiting new countries and cities", "Traveling" },
                    { 10, "Swimming in pools and lakes", "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Alice", "Andersson", "0701000001" },
                    { 2, "Bob", "Berg", "0701000002" },
                    { 3, "Charlie", "Carlsson", "0701000003" },
                    { 4, "Diana", "Dahl", "0701000004" },
                    { 5, "Erik", "Eklund", "0701000005" },
                    { 6, "Fiona", "Fredriksson", "0701000006" },
                    { 7, "Gustav", "Gustafsson", "0701000007" },
                    { 8, "Hanna", "Hansson", "0701000008" },
                    { 9, "Isak", "Ivarsson", "0701000009" },
                    { 10, "Julia", "Johansson", "0701000010" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestId", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 2 },
                    { 5, 4, 3 },
                    { 6, 5, 3 },
                    { 7, 6, 4 },
                    { 8, 7, 5 },
                    { 9, 8, 6 },
                    { 10, 9, 7 },
                    { 11, 10, 8 },
                    { 12, 1, 9 },
                    { 13, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://www.football.com" },
                    { 2, 2, "https://www.recipes.com" },
                    { 3, 3, "https://www.cookingblog.com" },
                    { 4, 4, "https://www.photography.com" },
                    { 5, 5, "https://www.reading.com" },
                    { 6, 6, "https://www.gaming.com" },
                    { 7, 7, "https://www.music.com" },
                    { 8, 8, "https://www.hiking.com" },
                    { 9, 9, "https://www.painting.com" },
                    { 10, 10, "https://www.traveling.com" },
                    { 11, 11, "https://www.swimming.com" },
                    { 12, 12, "https://www.footballnews.com" },
                    { 13, 13, "https://www.cookingfun.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links",
                column: "PersonInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
