using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRORegister.Migrations
{
    public partial class DAIF2020DaaModesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArenaStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArenaNumber = table.Column<string>(nullable: true),
                    ArenaName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    ArenaStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arena_ArenaStatus_ArenaStatusId",
                        column: x => x.ArenaStatusId,
                        principalTable: "ArenaStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arena_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    SeriesStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_SeriesStatus_SeriesStatusId",
                        column: x => x.SeriesStatusId,
                        principalTable: "SeriesStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubNumber = table.Column<string>(nullable: true),
                    ClubName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ClubStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Club_ClubStatus_ClubStatusId",
                        column: x => x.ClubStatusId,
                        principalTable: "ClubStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Club_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefRoleId = table.Column<int>(nullable: true),
                    RefStatusId = table.Column<int>(nullable: true),
                    RefTypeId = table.Column<int>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Ssn = table.Column<string>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SwishNumber = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ref_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ref_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ref_RefRole_RefRoleId",
                        column: x => x.RefRoleId,
                        principalTable: "RefRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ref_RefStatus_RefStatusId",
                        column: x => x.RefStatusId,
                        principalTable: "RefStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ref_RefType_RefTypeId",
                        column: x => x.RefTypeId,
                        principalTable: "RefType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDateTime = table.Column<DateTime>(nullable: true),
                    GameNumber = table.Column<string>(nullable: true),
                    TSMNumber = table.Column<string>(nullable: true),
                    GameCategoryId = table.Column<int>(nullable: true),
                    GameStatusId = table.Column<int>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    ClubId1 = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    RefId = table.Column<int>(nullable: true),
                    RefId1 = table.Column<int>(nullable: true),
                    RefId2 = table.Column<int>(nullable: true),
                    RefId3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Club_ClubId1",
                        column: x => x.ClubId1,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameCategory_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameStatus_GameStatusId",
                        column: x => x.GameStatusId,
                        principalTable: "GameStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameType_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Ref_RefId",
                        column: x => x.RefId,
                        principalTable: "Ref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Ref_RefId1",
                        column: x => x.RefId1,
                        principalTable: "Ref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Ref_RefId2",
                        column: x => x.RefId2,
                        principalTable: "Ref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Ref_RefId3",
                        column: x => x.RefId3,
                        principalTable: "Ref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arena_ArenaStatusId",
                table: "Arena",
                column: "ArenaStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Arena_DistrictId",
                table: "Arena",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_ArenaId",
                table: "Club",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_ClubStatusId",
                table: "Club",
                column: "ClubStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_DistrictId",
                table: "Club",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ArenaId",
                table: "Game",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ClubId",
                table: "Game",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ClubId1",
                table: "Game",
                column: "ClubId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameCategoryId",
                table: "Game",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameStatusId",
                table: "Game",
                column: "GameStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameTypeId",
                table: "Game",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefId",
                table: "Game",
                column: "RefId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefId1",
                table: "Game",
                column: "RefId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefId2",
                table: "Game",
                column: "RefId2");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefId3",
                table: "Game",
                column: "RefId3");

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeriesId",
                table: "Game",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ref_ClubId",
                table: "Ref",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Ref_DistrictId",
                table: "Ref",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Ref_RefRoleId",
                table: "Ref",
                column: "RefRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ref_RefStatusId",
                table: "Ref",
                column: "RefStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ref_RefTypeId",
                table: "Ref",
                column: "RefTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_DistrictId",
                table: "Series",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_SeriesStatusId",
                table: "Series",
                column: "SeriesStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameCategory");

            migrationBuilder.DropTable(
                name: "GameStatus");

            migrationBuilder.DropTable(
                name: "GameType");

            migrationBuilder.DropTable(
                name: "Ref");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "RefRole");

            migrationBuilder.DropTable(
                name: "RefStatus");

            migrationBuilder.DropTable(
                name: "RefType");

            migrationBuilder.DropTable(
                name: "SeriesStatus");

            migrationBuilder.DropTable(
                name: "Arena");

            migrationBuilder.DropTable(
                name: "ClubStatus");

            migrationBuilder.DropTable(
                name: "ArenaStatus");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}
