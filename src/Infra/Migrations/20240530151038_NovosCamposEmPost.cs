using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NossosPosts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NovosCamposEmPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Post",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Post",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Post",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Post");
        }
    }
}
