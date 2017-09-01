using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class carinfochange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetPos",
                table: "CarInfo");

            migrationBuilder.AddColumn<string>(
                name: "BossId",
                table: "CarInfo",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "CarInfo",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationCity",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationCounty",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationLevel6",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationProvince",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationTown",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationVillage",
                table: "CarInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagePath",
                table: "CarInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CarInfo",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "VideoPath",
                table: "CarInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BossId",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationCity",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationCounty",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationLevel6",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationProvince",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationTown",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "DestinationVillage",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "CarInfo");

            migrationBuilder.AddColumn<string>(
                name: "TargetPos",
                table: "CarInfo",
                nullable: true);
        }
    }
}
