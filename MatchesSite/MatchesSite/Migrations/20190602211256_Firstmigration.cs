using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesSite.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
		/*
            migrationBuilder.CreateTable(
                name: "Bookies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Country = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_Countries",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<int>(nullable: true),
                    League = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues",
                        column: x => x.League,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Home = table.Column<int>(nullable: false),
                    Away = table.Column<int>(nullable: false),
                    _1 = table.Column<double>(name: "1", nullable: false),
                    X = table.Column<double>(nullable: false),
                    _2 = table.Column<double>(name: "2", nullable: false),
                    Id1 = table.Column<int>(nullable: false),
                    IdX = table.Column<int>(nullable: false),
                    Id2 = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    League = table.Column<int>(nullable: true),
                    Country = table.Column<int>(nullable: true),
                    Hash = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Away",
                        column: x => x.Away,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_Countries",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Home",
                        column: x => x.Home,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_1",
                        column: x => x.Id1,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_2",
                        column: x => x.Id2,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_X",
                        column: x => x.IdX,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_Leagues",
                        column: x => x.League,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Home = table.Column<int>(nullable: false),
                    Away = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Bookie = table.Column<int>(nullable: false),
                    _1 = table.Column<double>(name: "1", nullable: false),
                    X = table.Column<double>(nullable: false),
                    _2 = table.Column<double>(name: "2", nullable: false),
                    League = table.Column<int>(nullable: true),
                    Country = table.Column<int>(nullable: true),
                    Hash = table.Column<string>(maxLength: 50, nullable: false),
                    OpportunityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Away",
                        column: x => x.Away,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Bookies",
                        column: x => x.Bookie,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Countries",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Home",
                        column: x => x.Home,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Leagues",
                        column: x => x.League,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Opportunities",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPossible = table.Column<double>(nullable: false),
                    Percent1 = table.Column<double>(nullable: false),
                    PercentX = table.Column<double>(nullable: false),
                    Percent2 = table.Column<double>(nullable: false),
                    ROI = table.Column<double>(nullable: false),
                    OpportunityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profits_Opportunities",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Country",
                table: "Leagues",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Away",
                table: "Matches",
                column: "Away");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Bookie",
                table: "Matches",
                column: "Bookie");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Country",
                table: "Matches",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "UQ_Matches",
                table: "Matches",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Home",
                table: "Matches",
                column: "Home");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_League",
                table: "Matches",
                column: "League");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OpportunityId",
                table: "Matches",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Away",
                table: "Opportunities",
                column: "Away");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Country",
                table: "Opportunities",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "UQ_Opportunities",
                table: "Opportunities",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Home",
                table: "Opportunities",
                column: "Home");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Id1",
                table: "Opportunities",
                column: "Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Id2",
                table: "Opportunities",
                column: "Id2");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_IdX",
                table: "Opportunities",
                column: "IdX");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_League",
                table: "Opportunities",
                column: "League");

            migrationBuilder.CreateIndex(
                name: "IX_Profits_OpportunityId",
                table: "Profits",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Country",
                table: "Teams",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_League",
                table: "Teams",
                column: "League");
		*/
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
		/*
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Profits");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Bookies");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Countries");
		*/
        }
    }
}
