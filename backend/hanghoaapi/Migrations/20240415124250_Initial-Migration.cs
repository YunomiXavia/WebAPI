using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hanghoaapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    ma_hanghoa = table.Column<string>(type: "char(9)", maxLength: 9, nullable: false),
                    ten_hanghoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(75)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.ma_hanghoa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");
        }
    }
}
