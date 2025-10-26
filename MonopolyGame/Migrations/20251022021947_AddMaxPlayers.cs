﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyGame.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxPlayers",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "Games");
        }
    }
}
