using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHelper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Detalle = table.Column<string>(type: "TEXT", unicode: false, maxLength: 250, nullable: true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Rut = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3214EC07C1CD3BFD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", unicode: false, maxLength: 250, nullable: true),
                    ValorFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    Propina = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comanda_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ComandaActualId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesa_Comanda",
                        column: x => x.ComandaActualId,
                        principalTable: "Comandas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidosComanda",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    ComandaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PedidoComanda_Comanda",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoComanda_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_UsuarioId",
                table: "Comandas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_ComandaActualId",
                table: "Mesa",
                column: "ComandaActualId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosComanda_ComandaId",
                table: "PedidosComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosComanda_MenuId",
                table: "PedidosComanda",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Mesa",
                table: "Comandas",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Mesa",
                table: "Comandas");

            migrationBuilder.DropTable(
                name: "PedidosComanda");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
