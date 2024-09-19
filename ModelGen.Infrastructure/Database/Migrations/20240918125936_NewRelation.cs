using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelGen.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneticData_Orders_OrderId",
                table: "GeneticData");

            migrationBuilder.DropTable(
                name: "GeneticDataUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "GeneticData",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GeneticData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GeneticData_UserId",
                table: "GeneticData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneticData_Orders_OrderId",
                table: "GeneticData",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneticData_Users_UserId",
                table: "GeneticData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneticData_Orders_OrderId",
                table: "GeneticData");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneticData_Users_UserId",
                table: "GeneticData");

            migrationBuilder.DropIndex(
                name: "IX_GeneticData_UserId",
                table: "GeneticData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GeneticData");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "GeneticData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GeneticDataUsers",
                columns: table => new
                {
                    GeneticDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticDataUsers", x => new { x.GeneticDataId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GeneticDataUsers_GeneticData_GeneticDataId",
                        column: x => x.GeneticDataId,
                        principalTable: "GeneticData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticDataUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneticDataUsers_UsersId",
                table: "GeneticDataUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneticData_Orders_OrderId",
                table: "GeneticData",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
