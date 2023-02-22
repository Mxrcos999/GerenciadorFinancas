using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciadorFinancas.Infraestrutura.Migrations
{
    public partial class Adicionandotabelasdispesasecategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Usuarios_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ContaFinanceiras_ContaFinanceiraId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaFinanceiras",
                table: "ContaFinanceiras");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "empresas");

            migrationBuilder.RenameTable(
                name: "ContaFinanceiras",
                newName: "contaFinanceiras");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_ContaFinanceiraId",
                table: "usuarios",
                newName: "IX_usuarios_ContaFinanceiraId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_UsuarioId",
                table: "empresas",
                newName: "IX_empresas_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_empresas",
                table: "empresas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contaFinanceiras",
                table: "contaFinanceiras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dispesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Previsao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DispesaId = table.Column<int>(type: "integer", nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categorias_dispesas_DispesaId",
                        column: x => x.DispesaId,
                        principalTable: "dispesas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categorias_DispesaId",
                table: "categorias",
                column: "DispesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_usuarios_UsuarioId",
                table: "empresas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_contaFinanceiras_ContaFinanceiraId",
                table: "usuarios",
                column: "ContaFinanceiraId",
                principalTable: "contaFinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_usuarios_UsuarioId",
                table: "empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_contaFinanceiras_ContaFinanceiraId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "dispesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_empresas",
                table: "empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contaFinanceiras",
                table: "contaFinanceiras");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "empresas",
                newName: "Empresas");

            migrationBuilder.RenameTable(
                name: "contaFinanceiras",
                newName: "ContaFinanceiras");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_ContaFinanceiraId",
                table: "Usuarios",
                newName: "IX_Usuarios_ContaFinanceiraId");

            migrationBuilder.RenameIndex(
                name: "IX_empresas_UsuarioId",
                table: "Empresas",
                newName: "IX_Empresas_UsuarioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaFinanceiras",
                table: "ContaFinanceiras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Usuarios_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_ContaFinanceiras_ContaFinanceiraId",
                table: "Usuarios",
                column: "ContaFinanceiraId",
                principalTable: "ContaFinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
