using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hesapkimdeapi.Migrations
{
    /// <inheritdoc />
    public partial class newStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendsBannerId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "GroupsBannerId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "HomeBannerId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RollBannerId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RollStartRewardedId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RollTimeRewardedId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "SettingsBannerId",
                table: "Ads",
                newName: "AdvertisamentId");

            migrationBuilder.AddColumn<int>(
                name: "AdTypeId",
                table: "Ads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Ads",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScreenId",
                table: "Ads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdTypeId",
                table: "Ads",
                column: "AdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ScreenId",
                table: "Ads",
                column: "ScreenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdTypes_AdTypeId",
                table: "Ads",
                column: "AdTypeId",
                principalTable: "AdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Screens_ScreenId",
                table: "Ads",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdTypes_AdTypeId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Screens_ScreenId",
                table: "Ads");

            migrationBuilder.DropTable(
                name: "AdTypes");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Ads_AdTypeId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_ScreenId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdTypeId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ScreenId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "AdvertisamentId",
                table: "Ads",
                newName: "SettingsBannerId");

            migrationBuilder.AddColumn<string>(
                name: "FriendsBannerId",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupsBannerId",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeBannerId",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RollBannerId",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RollStartRewardedId",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RollTimeRewardedId",
                table: "Ads",
                type: "text",
                nullable: true);
        }
    }
}
