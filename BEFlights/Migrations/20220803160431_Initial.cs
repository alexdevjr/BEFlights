using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEFlights.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "varchar(20)", nullable: false),
                    Destination = table.Column<string>(type: "varchar(20)", nullable: false),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    Airline = table.Column<string>(type: "varchar(20)", nullable: false),
                    Depart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nonstop = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
