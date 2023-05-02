using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoMicroServico.HotelService.Migrations
{
    public partial class V3 : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id_City_AddressId_City",
                table: "Address",
                column: "Id_City_AddressId_City");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Id_Address_HotelId_Address",
                table: "Hotel",
                column: "Id_Address_HotelId_Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
