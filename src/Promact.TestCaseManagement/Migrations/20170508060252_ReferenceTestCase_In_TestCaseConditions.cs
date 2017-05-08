using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Promact.TestCaseManagement.Web.Migrations
{
    public partial class ReferenceTestCase_In_TestCaseConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCaseConditions_TestCase_TestCaseId",
                table: "TestCaseConditions");

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "TestCaseConditionsVersion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTestCaseId",
                table: "TestCaseConditionsVersion",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "TestCaseConditions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTestCaseId",
                table: "TestCaseConditions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseConditions_ReferenceTestCaseId",
                table: "TestCaseConditions",
                column: "ReferenceTestCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCaseConditions_TestCase_ReferenceTestCaseId",
                table: "TestCaseConditions",
                column: "ReferenceTestCaseId",
                principalTable: "TestCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCaseConditions_TestCase_TestCaseId",
                table: "TestCaseConditions",
                column: "TestCaseId",
                principalTable: "TestCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCaseConditions_TestCase_ReferenceTestCaseId",
                table: "TestCaseConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCaseConditions_TestCase_TestCaseId",
                table: "TestCaseConditions");

            migrationBuilder.DropIndex(
                name: "IX_TestCaseConditions_ReferenceTestCaseId",
                table: "TestCaseConditions");

            migrationBuilder.DropColumn(
                name: "ReferenceTestCaseId",
                table: "TestCaseConditionsVersion");

            migrationBuilder.DropColumn(
                name: "ReferenceTestCaseId",
                table: "TestCaseConditions");

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "TestCaseConditionsVersion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "TestCaseConditions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TestCaseConditions_TestCase_TestCaseId",
                table: "TestCaseConditions",
                column: "TestCaseId",
                principalTable: "TestCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
