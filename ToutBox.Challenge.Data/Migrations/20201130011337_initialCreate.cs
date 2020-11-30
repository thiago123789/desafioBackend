using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToutBox.Challenge.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryCalcEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceZipCode_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationZipCode_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCalcEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePriceTimes",
                columns: table => new
                {
                    DeliveryServicePriceTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryService_ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryService_ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePriceTimes", x => new { x.DeliveryServicePriceTimeId, x.Id });
                    table.ForeignKey(
                        name: "FK_ServicePriceTimes_DeliveryCalcEvent_DeliveryServicePriceTimeId",
                        column: x => x.DeliveryServicePriceTimeId,
                        principalTable: "DeliveryCalcEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePriceTimes");

            migrationBuilder.DropTable(
                name: "DeliveryCalcEvent");
        }
    }
}
