using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagenTercero",
                columns: table => new
                {
                    ImagenTerceroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenTercero", x => x.ImagenTerceroID);
                });

            migrationBuilder.CreateTable(
                name: "Terceros",
                columns: table => new
                {
                    TerceroIdentificacion = table.Column<string>(nullable: false),
                    TerceroID = table.Column<int>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    NombreTercero = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    NombreFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terceros", x => x.TerceroIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerceroIdentificacion = table.Column<string>(nullable: true),
                    TipoPago = table.Column<string>(nullable: true),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoID);
                    table.ForeignKey(
                        name: "FK_Pagos_Terceros_TerceroIdentificacion",
                        column: x => x.TerceroIdentificacion,
                        principalTable: "Terceros",
                        principalColumn: "TerceroIdentificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TerceroIdentificacion",
                table: "Pagos",
                column: "TerceroIdentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenTercero");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Terceros");
        }
    }
}
