using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.DomainModel.Migrations
{
    [DbContext(typeof(TestCaseManagementDbContext))]
    partial class TestCaseManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ModuleTestCaseMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<int>("ModuleId");

                    b.Property<int>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("ModuleTestCaseMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Hardware");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Prerequisite");

                    b.Property<string>("TestEnvironment");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ProjectUserMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<int>("ProjectId");

                    b.Property<int>("Role");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUserMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Scenario");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ScenarioTestCaseMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<int>("ScenarioId");

                    b.Property<int>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("ScenarioTestCaseMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<int?>("DefectId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<bool>("Priority");

                    b.Property<string>("ReviewedUserId");

                    b.Property<string>("TestCaseUniqueId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ReviewedUserId");

                    b.ToTable("TestCase");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseConditions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Condition");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestCaseConditions");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseConditionsVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Condition");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("TestCaseConditionsId");

                    b.Property<int?>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("TestCaseConditionsId");

                    b.ToTable("TestCaseConditionsVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IsDeleted");

                    b.Property<int>("TestCaseStepsId");

                    b.Property<string>("TestInput");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseStepsId");

                    b.ToTable("TestCaseInput");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseInputVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("IsDeleted");

                    b.Property<int>("TestCaseInputId");

                    b.Property<int>("TestCaseStepsId");

                    b.Property<string>("TestInput");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("TestCaseInputId");

                    b.ToTable("TestCaseInputVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseResultHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("TestCaseId");

                    b.Property<int>("TestCaseResult");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestCaseResultHistory");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualResult");

                    b.Property<DateTime?>("ActualResultDate");

                    b.Property<string>("ExpectedResult");

                    b.Property<DateTime>("ExpectedResultDate");

                    b.Property<int>("IsDeleted");

                    b.Property<int>("TestCaseId");

                    b.Property<string>("TestStep");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestCaseSteps");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseStepsVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualResult");

                    b.Property<DateTime?>("ActualResultDate");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("ExpectedResult");

                    b.Property<DateTime>("ExpectedResultDate");

                    b.Property<int>("IsDeleted");

                    b.Property<int>("TestCaseId");

                    b.Property<int>("TestCaseStepsId");

                    b.Property<string>("TestStep");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("TestCaseStepsId");

                    b.ToTable("TestCaseStepsVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<int?>("DefectId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<bool>("Priority");

                    b.Property<int>("TestCaseId");

                    b.Property<string>("TestCaseUniqueId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestCaseVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<string>("RefreshToken")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Module", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Project", "Project")
                        .WithMany("Module")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ModuleTestCaseMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Module", "Module")
                        .WithMany("ModuleTestCaseMapping")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany("ModuleTestCaseMapping")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ProjectUserMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Project", "Project")
                        .WithMany("ProjectUserMapping")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "User")
                        .WithMany("ProjectUserMapping")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Scenario", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Project", "Project")
                        .WithMany("Scenario")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.ScenarioTestCaseMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Scenario", "Scenario")
                        .WithMany("ScenarioTestCaseMapping")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany("ScenarioTestCaseMapping")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "ReviewedUser")
                        .WithMany()
                        .HasForeignKey("ReviewedUserId");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseConditions", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany("TestCaseConditions")
                        .HasForeignKey("TestCaseId");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseConditionsVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCaseConditions", "TestCaseConditions")
                        .WithMany("TestCaseConditionsVersion")
                        .HasForeignKey("TestCaseConditionsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseInput", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCaseSteps", "TestCaseSteps")
                        .WithMany("TestCaseInputs")
                        .HasForeignKey("TestCaseStepsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseInputVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCaseInput", "TestCaseInput")
                        .WithMany("TestCaseInputVersion")
                        .HasForeignKey("TestCaseInputId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseResultHistory", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany("TestCaseResultHistory")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseSteps", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany("TestCaseSteps")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseStepsVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCaseSteps", "TestCaseSteps")
                        .WithMany("TestCaseStepsVersion")
                        .HasForeignKey("TestCaseStepsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCaseVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
