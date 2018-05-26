using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fitness.Web.Data.Migrations
{
    public partial class AddedWorkoutsForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Workout",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workout_ApplicationUserId",
                table: "Workout",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_AspNetUsers_ApplicationUserId",
                table: "Workout",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_AspNetUsers_ApplicationUserId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_ApplicationUserId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Workout");
        }
    }
}
