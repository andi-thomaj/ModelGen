using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelGen.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class newcols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleIdToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jwt",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JwtRefresh",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RawDataFileName",
                table: "GeneticData",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UploadedAt",
                table: "GeneticData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleIdToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Jwt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JwtRefresh",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RawDataFileName",
                table: "GeneticData");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "GeneticData");
        }
    }
}
