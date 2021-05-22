using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerComp.Migrations
{
    public partial class InitialCreate_SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BeerEntry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryName = table.Column<string>(nullable: true),
                    ABV = table.Column<double>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerEntry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BeerEntry_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasteScore = table.Column<int>(nullable: false),
                    LookScore = table.Column<int>(nullable: false),
                    OtherScore = table.Column<int>(nullable: false),
                    OverallScore = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: true),
                    VoterID = table.Column<int>(nullable: false),
                    EntryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScoreCard_BeerEntry_EntryID",
                        column: x => x.EntryID,
                        principalTable: "BeerEntry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCard_Voter_VoterID",
                        column: x => x.VoterID,
                        principalTable: "Voter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerEntry_OwnerID",
                table: "BeerEntry",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_EntryID",
                table: "ScoreCard",
                column: "EntryID");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_VoterID",
                table: "ScoreCard",
                column: "VoterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreCard");

            migrationBuilder.DropTable(
                name: "BeerEntry");

            migrationBuilder.DropTable(
                name: "Voter");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
