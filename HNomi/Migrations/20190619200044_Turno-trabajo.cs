using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HNomi.Migrations
{
    public partial class Turnotrabajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnosTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EsTurnoPartido = table.Column<bool>(nullable: false, defaultValue: false),
                    HoraDesdeTurno1 = table.Column<DateTime>(nullable: false),
                    HoraDesdeTurno2 = table.Column<DateTime>(nullable: false),
                    HoraHastaTurno1 = table.Column<DateTime>(nullable: true),
                    HoraHastaTurno2 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnosTrabajo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnosTrabajo");
        }
    }
}
