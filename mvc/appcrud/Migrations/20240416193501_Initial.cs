using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appcrud.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_hanghoa = table.Column<string>(type: "char(9)", nullable: false),
                    ten_hanghoa = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(75)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");
        }
    }
}
