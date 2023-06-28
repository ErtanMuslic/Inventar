using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventar.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProstorijaId",
                table: "Radnicis",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Prostorijas",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "IdInventari",
                table: "Prostorijas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRadnika",
                table: "Prostorijas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Sef",
                table: "Prostorijas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "ProstorijaId",
                table: "Inventars",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Radnicis_ProstorijaId",
                table: "Radnicis",
                column: "ProstorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventars_ProstorijaId",
                table: "Inventars",
                column: "ProstorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventars_Prostorijas_ProstorijaId",
                table: "Inventars",
                column: "ProstorijaId",
                principalTable: "Prostorijas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Radnicis_Prostorijas_ProstorijaId",
                table: "Radnicis",
                column: "ProstorijaId",
                principalTable: "Prostorijas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventars_Prostorijas_ProstorijaId",
                table: "Inventars");

            migrationBuilder.DropForeignKey(
                name: "FK_Radnicis_Prostorijas_ProstorijaId",
                table: "Radnicis");

            migrationBuilder.DropIndex(
                name: "IX_Radnicis_ProstorijaId",
                table: "Radnicis");

            migrationBuilder.DropIndex(
                name: "IX_Inventars_ProstorijaId",
                table: "Inventars");

            migrationBuilder.DropColumn(
                name: "ProstorijaId",
                table: "Radnicis");

            migrationBuilder.DropColumn(
                name: "IdInventari",
                table: "Prostorijas");

            migrationBuilder.DropColumn(
                name: "IdRadnika",
                table: "Prostorijas");

            migrationBuilder.DropColumn(
                name: "Sef",
                table: "Prostorijas");

            migrationBuilder.DropColumn(
                name: "ProstorijaId",
                table: "Inventars");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Prostorijas",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
