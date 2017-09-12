using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace web.Data.Migrations
{
    public partial class a11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeChatId",
                table: "Carinfo");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Carinfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Carinfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "WeChatId",
                table: "Carinfo",
                maxLength: 32,
                nullable: true);
        }
    }
}
