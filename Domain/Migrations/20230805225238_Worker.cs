using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Worker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Workers_workerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_workerId",
                table: "Rooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "workerId",
                table: "Rooms",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_workerId",
                table: "Rooms",
                column: "workerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Workers_workerId",
                table: "Rooms",
                column: "workerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Workers_workerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_workerId",
                table: "Rooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "workerId",
                table: "Rooms",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_workerId",
                table: "Rooms",
                column: "workerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Workers_workerId",
                table: "Rooms",
                column: "workerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
