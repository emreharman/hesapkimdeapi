using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hesapkimdeapi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeBannerId = table.Column<string>(type: "text", nullable: true),
                    FriendsBannerId = table.Column<string>(type: "text", nullable: true),
                    RollBannerId = table.Column<string>(type: "text", nullable: true),
                    RollTimeRewardedId = table.Column<string>(type: "text", nullable: true),
                    RollStartRewardedId = table.Column<string>(type: "text", nullable: true),
                    GroupsBannerId = table.Column<string>(type: "text", nullable: true),
                    SettingsBannerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
