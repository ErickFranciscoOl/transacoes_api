using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transacoes.Migrations
{
    /// <inheritdoc />
    public partial class Teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes");

            migrationBuilder.RenameTable(
                name: "transacoes",
                newName: "Transacoes");

            migrationBuilder.AlterColumn<string>(
                name: "txid",
                table: "Transacoes",
                type: "varchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "pagador_cpf",
                table: "Transacoes",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "e2e_id",
                table: "Transacoes",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_transacao",
                table: "Transacoes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "transacoes");

            migrationBuilder.AlterColumn<string>(
                name: "txid",
                table: "transacoes",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(35)",
                oldMaxLength: 35)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "transacoes",
                keyColumn: "pagador_cpf",
                keyValue: null,
                column: "pagador_cpf",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "pagador_cpf",
                table: "transacoes",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "transacoes",
                keyColumn: "e2e_id",
                keyValue: null,
                column: "e2e_id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "e2e_id",
                table: "transacoes",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_transacao",
                table: "transacoes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes",
                column: "id");
        }
    }
}
