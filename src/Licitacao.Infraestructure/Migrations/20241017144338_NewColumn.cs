﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacao.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class NewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeFisco",
                table: "Lotes",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeFisco",
                table: "Lotes");
        }
    }
}
