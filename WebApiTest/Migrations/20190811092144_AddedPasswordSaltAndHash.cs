﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTest.Migrations
{
    public partial class AddedPasswordSaltAndHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 10,
                nullable: true);
        }
    }
}
