using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABDWNSprint1.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Uf = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Medico = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataEnvioRelatorio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorConsulta = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Imagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Relatorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    NmrCarteiraOdonto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    QuantidadeConsultas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FotoCliente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Clientes_TB_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Clinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    RazaoSocial = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    FotoClinica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Clinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Clinicas_TB_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Clientes_EnderecoId",
                table: "TB_Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Clinicas_EnderecoId",
                table: "TB_Clinicas",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Clientes");

            migrationBuilder.DropTable(
                name: "TB_Clinicas");

            migrationBuilder.DropTable(
                name: "TB_Relatorios");

            migrationBuilder.DropTable(
                name: "TB_Enderecos");
        }
    }
}
