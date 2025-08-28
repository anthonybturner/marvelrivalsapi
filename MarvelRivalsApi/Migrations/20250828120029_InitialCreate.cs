using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarvelRivalsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Casting = table.Column<string>(type: "text", nullable: true),
                    EnergyCost = table.Column<string>(type: "text", nullable: true),
                    MaximumEnergy = table.Column<string>(type: "text", nullable: true),
                    MovementBoost = table.Column<string>(type: "text", nullable: true),
                    EnergyRecoverySpeed = table.Column<string>(type: "text", nullable: true),
                    SpecialEffect = table.Column<string>(type: "text", nullable: true),
                    ExtraFieldsJson = table.Column<string>(type: "text", nullable: true),
                    AbilityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RealName = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    AttackType = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Lore = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: true),
                    HeroName = table.Column<string>(type: "text", nullable: true),
                    HeroType = table.Column<string>(type: "text", nullable: true),
                    Kills = table.Column<int>(type: "integer", nullable: true),
                    Deaths = table.Column<int>(type: "integer", nullable: true),
                    Assists = table.Column<int>(type: "integer", nullable: true),
                    PlayTime = table.Column<double>(type: "double precision", nullable: true),
                    TotalHeroDamage = table.Column<double>(type: "double precision", nullable: true),
                    TotalDamageTaken = table.Column<double>(type: "double precision", nullable: true),
                    TotalHeroHeal = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddScore = table.Column<double>(type: "double precision", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: true),
                    NewLevel = table.Column<int>(type: "integer", nullable: true),
                    NewScore = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScoreInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Zero = table.Column<int>(type: "integer", nullable: false),
                    One = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubMapId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Thumbnail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WinInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    IsWin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AbilityId = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    IsCollab = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AdditionalFieldsId = table.Column<int>(type: "integer", nullable: true),
                    HeroId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ability_AdditionalFields_AdditionalFieldsId",
                        column: x => x.AdditionalFieldsId,
                        principalTable: "AdditionalFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransformationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Health = table.Column<string>(type: "text", nullable: true),
                    MovementSpeed = table.Column<string>(type: "text", nullable: true),
                    HeroId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transformation_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Costume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CostumeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Appearance = table.Column<string>(type: "text", nullable: true),
                    HeroId = table.Column<int>(type: "integer", nullable: true),
                    QualityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costume_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Costume_Quality_QualityId",
                        column: x => x.QualityId,
                        principalTable: "Quality",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameMapId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    GameMode = table.Column<string>(type: "text", nullable: true),
                    IsCompetitive = table.Column<bool>(type: "boolean", nullable: false),
                    SubMapId = table.Column<int>(type: "integer", nullable: true),
                    Video = table.Column<string>(type: "text", nullable: true),
                    Images = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMaps_SubMap_SubMapId",
                        column: x => x.SubMapId,
                        principalTable: "SubMap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerUid = table.Column<long>(type: "bigint", nullable: true),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    Deaths = table.Column<int>(type: "integer", nullable: false),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    Disconnected = table.Column<bool>(type: "boolean", nullable: false),
                    PlayerName = table.Column<string>(type: "text", nullable: false),
                    Camp = table.Column<int>(type: "integer", nullable: true),
                    IsWinId = table.Column<int>(type: "integer", nullable: false),
                    ScoreInfoId = table.Column<int>(type: "integer", nullable: false),
                    PlayerHeroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerHero_PlayerHeroId",
                        column: x => x.PlayerHeroId,
                        principalTable: "PlayerHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerScoreInfo_ScoreInfoId",
                        column: x => x.ScoreInfoId,
                        principalTable: "PlayerScoreInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_WinInfo_IsWinId",
                        column: x => x.IsWinId,
                        principalTable: "WinInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchUid = table.Column<string>(type: "text", nullable: false),
                    MatchMapId = table.Column<int>(type: "integer", nullable: false),
                    MatchMapName = table.Column<string>(type: "text", nullable: false),
                    MapThumbnail = table.Column<string>(type: "text", nullable: false),
                    MatchPlayDuration = table.Column<double>(type: "double precision", nullable: false),
                    MatchSeason = table.Column<string>(type: "text", nullable: false),
                    MatchWinnerSide = table.Column<int>(type: "integer", nullable: false),
                    MvpUid = table.Column<int>(type: "integer", nullable: false),
                    SvpUid = table.Column<int>(type: "integer", nullable: false),
                    MatchTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PlayModeId = table.Column<int>(type: "integer", nullable: false),
                    GameModeId = table.Column<int>(type: "integer", nullable: false),
                    MatchPlayerId = table.Column<int>(type: "integer", nullable: false),
                    ScoreInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchHistory_MatchPlayer_MatchPlayerId",
                        column: x => x.MatchPlayerId,
                        principalTable: "MatchPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchHistory_ScoreInfo_ScoreInfoId",
                        column: x => x.ScoreInfoId,
                        principalTable: "ScoreInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_AdditionalFieldsId",
                table: "Ability",
                column: "AdditionalFieldsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ability_HeroId",
                table: "Ability",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Costume_HeroId",
                table: "Costume",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Costume_QualityId",
                table: "Costume",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMaps_SubMapId",
                table: "GameMaps",
                column: "SubMapId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_MatchPlayerId",
                table: "MatchHistory",
                column: "MatchPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_ScoreInfoId",
                table: "MatchHistory",
                column: "ScoreInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_IsWinId",
                table: "MatchPlayer",
                column: "IsWinId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayerHeroId",
                table: "MatchPlayer",
                column: "PlayerHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_ScoreInfoId",
                table: "MatchPlayer",
                column: "ScoreInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transformation_HeroId",
                table: "Transformation",
                column: "HeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Costume");

            migrationBuilder.DropTable(
                name: "GameMaps");

            migrationBuilder.DropTable(
                name: "MatchHistory");

            migrationBuilder.DropTable(
                name: "Transformation");

            migrationBuilder.DropTable(
                name: "AdditionalFields");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropTable(
                name: "SubMap");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "ScoreInfo");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "PlayerHero");

            migrationBuilder.DropTable(
                name: "PlayerScoreInfo");

            migrationBuilder.DropTable(
                name: "WinInfo");
        }
    }
}
