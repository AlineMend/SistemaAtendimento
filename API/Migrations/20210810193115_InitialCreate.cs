using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataExecucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeAtendimentoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tecnicos_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: true),
                    AtendimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposDeAtendimento_Atendimentos_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TiposDeAtendimento_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoTecnico",
                columns: table => new
                {
                    AtendimentosId = table.Column<int>(type: "int", nullable: false),
                    TecnicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoTecnico", x => new { x.AtendimentosId, x.TecnicosId });
                    table.ForeignKey(
                        name: "FK_AtendimentoTecnico_Atendimentos_AtendimentosId",
                        column: x => x.AtendimentosId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoTecnico_Tecnicos_TecnicosId",
                        column: x => x.TecnicosId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: false),
                    TecnicoSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GestrorSenha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => new { x.TecnicoId, x.GestorId });
                    table.ForeignKey(
                        name: "FK_Login_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Login_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Atendimentos",
                columns: new[] { "Id", "DataExecucao", "NomeCliente", "Observacao", "TecnicoNome", "TipoDeAtendimentoTipo" },
                values: new object[] { 1, new DateTime(2021, 8, 9, 13, 45, 0, 0, DateTimeKind.Unspecified), "Maria Aparecida", "Resolvido", " Ana Couto", "Telefone" });

            migrationBuilder.InsertData(
                table: "Gestores",
                columns: new[] { "Id", "Nome", "Senha" },
                values: new object[] { 1, "Joaguim Pedrosa", "qwe345" });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Ativo", "GestorId", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, true, null, " Francisco Couto", "asd123" },
                    { 2, true, null, " Ana Couto", "fgh456" },
                    { 3, true, null, " Arthur Menezes", "jkl789" },
                    { 4, true, null, " Flavia Santos", "zxc012" }
                });

            migrationBuilder.InsertData(
                table: "TiposDeAtendimento",
                columns: new[] { "Id", "AtendimentoId", "Ativo", "GestorId", "Tipo" },
                values: new object[,]
                {
                    { 1, null, true, null, "Presencial" },
                    { 2, null, true, null, "Telefone" },
                    { 3, null, true, null, "Email" },
                    { 4, null, true, null, "Chat" },
                    { 5, null, true, null, "Redes Sociais" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoTecnico_TecnicosId",
                table: "AtendimentoTecnico",
                column: "TecnicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_GestorId",
                table: "Login",
                column: "GestorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_TecnicoId",
                table: "Login",
                column: "TecnicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_GestorId",
                table: "Tecnicos",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeAtendimento_AtendimentoId",
                table: "TiposDeAtendimento",
                column: "AtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeAtendimento_GestorId",
                table: "TiposDeAtendimento",
                column: "GestorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoTecnico");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "TiposDeAtendimento");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Gestores");
        }
    }
}
