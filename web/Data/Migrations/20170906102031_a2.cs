using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace web.Data.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BossId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CarStatus = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    CheckTime = table.Column<long>(type: "bigint", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DestinationCity = table.Column<int>(type: "int", nullable: false),
                    DestinationCounty = table.Column<int>(type: "int", nullable: false),
                    DestinationLevel6 = table.Column<int>(type: "int", nullable: false),
                    DestinationProvince = table.Column<int>(type: "int", nullable: false),
                    DestinationTown = table.Column<int>(type: "int", nullable: false),
                    DestinationVillage = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InZone = table.Column<int>(type: "int", nullable: false),
                    JoinTime = table.Column<long>(type: "bigint", nullable: false),
                    LongSize = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PosX = table.Column<double>(type: "float", nullable: false),
                    PosY = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VideoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeChatId = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carinfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carinfo");
        }
    }
}
