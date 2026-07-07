using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoAtivos.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicialFii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradora",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjFundo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segmentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SegmentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdministradoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoFii = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeCotas = table.Column<int>(type: "int", nullable: false),
                    RendimentoUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoCota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPatrimonial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_Administradora_AdministradoraId",
                        column: x => x.AdministradoraId,
                        principalTable: "Administradora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ativos_Segmentos_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_AdministradoraId",
                table: "Ativos",
                column: "AdministradoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_SegmentoId",
                table: "Ativos",
                column: "SegmentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Administradora");

            migrationBuilder.DropTable(
                name: "Segmentos");
        }
    }
}
