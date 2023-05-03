using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoMicroServico.PackageService.Migrations
{
    public partial class V7 : Migration
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
                name: "Hotel",
                columns: table => new
                {
                    Id_Hotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Hotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Address_HotelId_Address = table.Column<int>(type: "int", nullable: false),
                    DtRegister_Hotel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hotel_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id_Hotel);
                    table.ForeignKey(
                        name: "FK_Hotel_Address_Id_Address_HotelId_Address",
                        column: x => x.Id_Address_HotelId_Address,
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelPackageId_Hotel = table.Column<int>(type: "int", nullable: false),
                    TicketPackageId = table.Column<int>(type: "int", nullable: false),
                    DtRegisterPackage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValuePackage = table.Column<double>(type: "float", nullable: false),
                    ClientPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Client_ClientPackageId",
                        column: x => x.ClientPackageId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Package_Hotel_HotelPackageId_Hotel",
                        column: x => x.HotelPackageId_Hotel,
                        principalTable: "Hotel",
                        principalColumn: "Id_Hotel",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Package_Ticket_TicketPackageId",
                        column: x => x.TicketPackageId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_Hotel_Id_Address_HotelId_Address",
                table: "Hotel",
                column: "Id_Address_HotelId_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ClientPackageId",
                table: "Package",
                column: "ClientPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_HotelPackageId_Hotel",
                table: "Package",
                column: "HotelPackageId_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Package_TicketPackageId",
                table: "Package",
                column: "TicketPackageId");

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
                name: "Package");

            migrationBuilder.DropTable(
                name: "Hotel");

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
