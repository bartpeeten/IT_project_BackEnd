using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KBVB.API.Migrations
{
    public partial class Player_model_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ShirtNumber",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlaceOfBirth",
                table: "Players",
                newName: "DidYouKnow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DidYouKnow",
                table: "Players",
                newName: "PlaceOfBirth");

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShirtNumber",
                table: "Players",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);
        }
    }
}
