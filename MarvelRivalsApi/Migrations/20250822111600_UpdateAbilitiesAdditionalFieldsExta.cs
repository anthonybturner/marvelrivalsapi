using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAbilitiesAdditionalFieldsExta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Casting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumEnergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovementBoost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyRecoverySpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialEffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraFieldsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kills = table.Column<int>(type: "int", nullable: true),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    PlayTime = table.Column<double>(type: "float", nullable: true),
                    TotalHeroDamage = table.Column<double>(type: "float", nullable: true),
                    TotalDamageTaken = table.Column<double>(type: "float", nullable: true),
                    TotalHeroHeal = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddScore = table.Column<double>(type: "float", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    NewLevel = table.Column<int>(type: "int", nullable: true),
                    NewScore = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScoreInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zero = table.Column<int>(type: "int", nullable: false),
                    One = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMapId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WinInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCollab = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalFieldsId = table.Column<int>(type: "int", nullable: true),
                    HeroId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransformationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Health = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovementSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostumeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    QualityId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameMapId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompetitive = table.Column<bool>(type: "bit", nullable: false),
                    SubMapId = table.Column<int>(type: "int", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerUid = table.Column<long>(type: "bigint", nullable: true),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Disconnected = table.Column<bool>(type: "bit", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camp = table.Column<int>(type: "int", nullable: true),
                    IsWinId = table.Column<int>(type: "int", nullable: false),
                    ScoreInfoId = table.Column<int>(type: "int", nullable: false),
                    PlayerHeroId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchMapId = table.Column<int>(type: "int", nullable: false),
                    MatchMapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchPlayDuration = table.Column<double>(type: "float", nullable: false),
                    MatchSeason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchWinnerSide = table.Column<int>(type: "int", nullable: false),
                    MvpUid = table.Column<int>(type: "int", nullable: false),
                    SvpUid = table.Column<int>(type: "int", nullable: false),
                    MatchTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PlayModeId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false),
                    MatchPlayerId = table.Column<int>(type: "int", nullable: false),
                    ScoreInfoId = table.Column<int>(type: "int", nullable: true)
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
                unique: true,
                filter: "[AdditionalFieldsId] IS NOT NULL");

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
