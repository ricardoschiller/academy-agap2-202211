﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agap2IT.Labs.MusicLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class albumdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Albums",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Albums");
        }
    }
}
