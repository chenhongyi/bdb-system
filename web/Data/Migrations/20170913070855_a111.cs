using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace web.Data.Migrations
{
    public partial class a111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DealCarData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auto = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BuyOrSell = table.Column<int>(type: "int", nullable: false),
                    CarBrand = table.Column<int>(type: "int", nullable: false),
                    CarStatus = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    CheckTime = table.Column<long>(type: "bigint", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Displacement = table.Column<double>(type: "float", nullable: false),
                    InZone = table.Column<int>(type: "int", nullable: false),
                    JoinTime = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Procedure = table.Column<int>(type: "int", nullable: false),
                    RegTime = table.Column<long>(type: "bigint", nullable: false),
                    RunRoadCount = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Years = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCarData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealCarData");
        }
    }
}
