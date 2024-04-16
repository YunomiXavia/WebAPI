using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hanghoaapi.Migrations
{
    /// <inheritdoc />
    public partial class AddIDColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "HangHoas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas");

            migrationBuilder.DropColumn(
                name: "id",
                table: "HangHoas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas",
                column: "ma_hanghoa");
        }
    }
}
