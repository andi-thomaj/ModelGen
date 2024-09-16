using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelGen.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addisdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsGoogleAuthenticated",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "GooglePictureUrl",
                table: "Users",
                newName: "PictureUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Users",
                newName: "GooglePictureUrl");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsGoogleAuthenticated");
        }
    }
}
