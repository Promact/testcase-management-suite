using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Promact.TestCaseManagement.DomainModel.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Hardware = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Prerequisite = table.Column<string>(nullable: true),
                    TestEnvironment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseResultHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TestCaseId = table.Column<int>(nullable: false),
                    TestCaseResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseResultHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DefectId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PostCondition = table.Column<string>(nullable: true),
                    PreCondition = table.Column<string>(nullable: true),
                    PreparedBy = table.Column<int>(nullable: false),
                    Priority = table.Column<bool>(nullable: false),
                    ReviewedBy = table.Column<int>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: false),
                    TestCaseId = table.Column<string>(nullable: true),
                    TestCaseResultHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCase_UserInfo_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCase_UserInfo_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCase_TestCaseResultHistory_TestCaseResultHistoryId",
                        column: x => x.TestCaseResultHistoryId,
                        principalTable: "TestCaseResultHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
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
                name: "ModuleTestCaseMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
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
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
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
                name: "TestCaseSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualResult = table.Column<string>(nullable: true),
                    ActualResultDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ExpectedResult = table.Column<string>(nullable: true),
                    ExpectedResultDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
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
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DefectId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PostCondition = table.Column<string>(nullable: true),
                    PreCondition = table.Column<string>(nullable: true),
                    PreparedBy = table.Column<int>(nullable: false),
                    Priority = table.Column<bool>(nullable: false),
                    ReviewedBy = table.Column<int>(nullable: true),
                    SerialNumber = table.Column<int>(nullable: false),
                    TCId = table.Column<int>(nullable: false),
                    TestCaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseVersion_UserInfo_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseVersion_UserInfo_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCaseVersion_TestCase_TCId",
                        column: x => x.TCId,
                        principalTable: "TestCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
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
                name: "TestCaseStepsVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualResult = table.Column<string>(nullable: true),
                    ActualResultDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ExpectedResult = table.Column<string>(nullable: true),
                    ExpectedResultDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TestCaseStepsId = table.Column<int>(nullable: false),
                    TestStep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseStepsVersion", x => x.Id);
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
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TestCaseInputId = table.Column<int>(nullable: false),
                    TestInput = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseInputVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseInputVersion_TestCaseInput_TestCaseInputId",
                        column: x => x.TestCaseInputId,
                        principalTable: "TestCaseInput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTestCaseMapping_ModuleId",
                table: "ModuleTestCaseMapping",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTestCaseMapping_TestCaseId",
                table: "ModuleTestCaseMapping",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioTestCaseMapping_ScenarioId",
                table: "ScenarioTestCaseMapping",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioTestCaseMapping_TestCaseId",
                table: "ScenarioTestCaseMapping",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_CreatedBy",
                table: "TestCase",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_ModifiedBy",
                table: "TestCase",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_TestCaseResultHistoryId",
                table: "TestCase",
                column: "TestCaseResultHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseInput_TestCaseStepsId",
                table: "TestCaseInput",
                column: "TestCaseStepsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseInputVersion_TestCaseInputId",
                table: "TestCaseInputVersion",
                column: "TestCaseInputId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseSteps_TestCaseId",
                table: "TestCaseSteps",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseStepsVersion_TestCaseStepsId",
                table: "TestCaseStepsVersion",
                column: "TestCaseStepsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseVersion_CreatedBy",
                table: "TestCaseVersion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseVersion_ModifiedBy",
                table: "TestCaseVersion",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseVersion_TCId",
                table: "TestCaseVersion",
                column: "TCId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMapping_ProjectId",
                table: "ProjectUserMapping",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserMapping_UserId",
                table: "ProjectUserMapping",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleTestCaseMapping");

            migrationBuilder.DropTable(
                name: "ScenarioTestCaseMapping");

            migrationBuilder.DropTable(
                name: "TestCaseInputVersion");

            migrationBuilder.DropTable(
                name: "TestCaseStepsVersion");

            migrationBuilder.DropTable(
                name: "TestCaseVersion");

            migrationBuilder.DropTable(
                name: "ProjectUserMapping");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Scenario");

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

            migrationBuilder.DropTable(
                name: "TestCaseResultHistory");
        }
    }
}
