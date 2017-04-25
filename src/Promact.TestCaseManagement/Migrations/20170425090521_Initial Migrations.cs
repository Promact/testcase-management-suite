using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Promact.TestCaseManagement.Web.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Hardware = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Prerequisite = table.Column<string>(nullable: true),
                    TestEnvironment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenario_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUserMapping_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserMapping_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    DefectId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<bool>(nullable: false),
                    ReviewedUserId = table.Column<string>(nullable: true),
                    TestCaseUniqueId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCase_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCase_UserInfo_ReviewedUserId",
                        column: x => x.ReviewedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleTestCaseMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    TestCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleTestCaseMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleTestCaseMapping_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleTestCaseMapping_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioTestCaseMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    ScenarioId = table.Column<int>(nullable: false),
                    TestCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioTestCaseMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScenarioTestCaseMapping_Scenario_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScenarioTestCaseMapping_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condition = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseConditions_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseResultHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    TestCaseId = table.Column<int>(nullable: false),
                    TestCaseResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseResultHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseResultHistory_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseResultHistory_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpectedResult = table.Column<string>(nullable: true),
                    ExpectedResultDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseId = table.Column<int>(nullable: false),
                    TestStep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseSteps_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    DefectId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<bool>(nullable: false),
                    TestCaseId = table.Column<int>(nullable: false),
                    TestCaseUniqueId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseVersion_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseVersion_TestCase_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseConditionsVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condition = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseConditionsId = table.Column<int>(nullable: false),
                    TestCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseConditionsVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseConditionsVersion_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseConditionsVersion_TestCaseConditions_TestCaseConditionsId",
                        column: x => x.TestCaseConditionsId,
                        principalTable: "TestCaseConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseStepsId = table.Column<int>(nullable: false),
                    TestInput = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseInput_TestCaseSteps_TestCaseStepsId",
                        column: x => x.TestCaseStepsId,
                        principalTable: "TestCaseSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseStepsResultHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualResult = table.Column<string>(nullable: true),
                    ActualResultDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    TestCaseStepsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseStepsResultHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseStepsResultHistory_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseStepsResultHistory_TestCaseSteps_TestCaseStepsId",
                        column: x => x.TestCaseStepsId,
                        principalTable: "TestCaseSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseStepsVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    ExpectedResult = table.Column<string>(nullable: true),
                    ExpectedResultDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseId = table.Column<int>(nullable: false),
                    TestCaseStepsId = table.Column<int>(nullable: false),
                    TestStep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseStepsVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseStepsVersion_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseStepsVersion_TestCaseSteps_TestCaseStepsId",
                        column: x => x.TestCaseStepsId,
                        principalTable: "TestCaseSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseInputVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    TestCaseInputId = table.Column<int>(nullable: false),
                    TestCaseStepsId = table.Column<int>(nullable: false),
                    TestInput = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseInputVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseInputVersion_UserInfo_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseInputVersion_TestCaseInput_TestCaseInputId",
                        column: x => x.TestCaseInputId,
                        principalTable: "TestCaseInput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_ProjectId",
                table: "Module",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTestCaseMapping_ModuleId",
                table: "ModuleTestCaseMapping",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTestCaseMapping_TestCaseId",
                table: "ModuleTestCaseMapping",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMapping_ProjectId",
                table: "ProjectUserMapping",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMapping_UserId",
                table: "ProjectUserMapping",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_ProjectId",
                table: "Scenario",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioTestCaseMapping_ScenarioId",
                table: "ScenarioTestCaseMapping",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioTestCaseMapping_TestCaseId",
                table: "ScenarioTestCaseMapping",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_CreatedUserId",
                table: "TestCase",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_ReviewedUserId",
                table: "TestCase",
                column: "ReviewedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseConditions_TestCaseId",
                table: "TestCaseConditions",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseConditionsVersion_CreatedUserId",
                table: "TestCaseConditionsVersion",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseConditionsVersion_TestCaseConditionsId",
                table: "TestCaseConditionsVersion",
                column: "TestCaseConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseInput_TestCaseStepsId",
                table: "TestCaseInput",
                column: "TestCaseStepsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseInputVersion_CreatedUserId",
                table: "TestCaseInputVersion",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseInputVersion_TestCaseInputId",
                table: "TestCaseInputVersion",
                column: "TestCaseInputId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseResultHistory_CreatedUserId",
                table: "TestCaseResultHistory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseResultHistory_TestCaseId",
                table: "TestCaseResultHistory",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseSteps_TestCaseId",
                table: "TestCaseSteps",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseStepsResultHistory_CreatedUserId",
                table: "TestCaseStepsResultHistory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseStepsResultHistory_TestCaseStepsId",
                table: "TestCaseStepsResultHistory",
                column: "TestCaseStepsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseStepsVersion_CreatedUserId",
                table: "TestCaseStepsVersion",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseStepsVersion_TestCaseStepsId",
                table: "TestCaseStepsVersion",
                column: "TestCaseStepsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseVersion_CreatedUserId",
                table: "TestCaseVersion",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseVersion_TestCaseId",
                table: "TestCaseVersion",
                column: "TestCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleTestCaseMapping");

            migrationBuilder.DropTable(
                name: "ProjectUserMapping");

            migrationBuilder.DropTable(
                name: "ScenarioTestCaseMapping");

            migrationBuilder.DropTable(
                name: "TestCaseConditionsVersion");

            migrationBuilder.DropTable(
                name: "TestCaseInputVersion");

            migrationBuilder.DropTable(
                name: "TestCaseResultHistory");

            migrationBuilder.DropTable(
                name: "TestCaseStepsResultHistory");

            migrationBuilder.DropTable(
                name: "TestCaseStepsVersion");

            migrationBuilder.DropTable(
                name: "TestCaseVersion");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.DropTable(
                name: "TestCaseConditions");

            migrationBuilder.DropTable(
                name: "TestCaseInput");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TestCaseSteps");

            migrationBuilder.DropTable(
                name: "TestCase");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
