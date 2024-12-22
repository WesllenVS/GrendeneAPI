using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeupAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjustesBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "TokenDtCriacao");

            migrationBuilder.AddColumn<int>(
                name: "Cargo",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaHash",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Users",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "TokenDtCriacao",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
