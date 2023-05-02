using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoMicroServico.TicketService.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id_City = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtRegister_City = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id_City);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id_Address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_City_AddressId_City = table.Column<int>(type: "int", nullable: false),
                    DtRegister_Address = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id_Address);
                    table.ForeignKey(
                        name: "FK_Address_City_Id_City_AddressId_City",
                        column: x => x.Id_City_AddressId_City,
                        principalTable: "City",
                        principalColumn: "Id_City",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressClientId_Address = table.Column<int>(type: "int", nullable: false),
                    DtRegisterClient = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Address_AddressClientId_Address",
                        column: x => x.AddressClientId_Address,
                        principalTable: "Address",
                        principalColumn: "Id_Address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId_Address = table.Column<int>(type: "int", nullable: false),
                    DestinyId_Address = table.Column<int>(type: "int", nullable: false),
                    ClientTicketId = table.Column<int>(type: "int", nullable: false),
                    DateTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValueTicket = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Address_DestinyId_Address",
                        column: x => x.DestinyId_Address,
                        principalTable: "Address",
                        principalColumn: "Id_Address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Address_OriginId_Address",
                        column: x => x.OriginId_Address,
                        principalTable: "Address",
                        principalColumn: "Id_Address",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ticket_Client_ClientTicketId",
                        column: x => x.ClientTicketId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id_City_AddressId_City",
                table: "Address",
                column: "Id_City_AddressId_City");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressClientId_Address",
                table: "Client",
                column: "AddressClientId_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClientTicketId",
                table: "Ticket",
                column: "ClientTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DestinyId_Address",
                table: "Ticket",
                column: "DestinyId_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OriginId_Address",
                table: "Ticket",
                column: "OriginId_Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
