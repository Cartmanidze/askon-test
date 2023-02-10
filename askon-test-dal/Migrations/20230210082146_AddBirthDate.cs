﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askon_test_dal.Migrations
{
	/// <inheritdoc />
	public partial class AddBirthDate : Migration
    {
		/// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "UserInfo",
                type: "datetime2",
                nullable: true);
        }

		/// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "UserInfo");
        }
    }
}
