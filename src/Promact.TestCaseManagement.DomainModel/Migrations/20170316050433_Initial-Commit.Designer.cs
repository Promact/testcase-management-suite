﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.DomainModel.Migrations
{
    [DbContext(typeof(TestCaseManagementDbContext))]
    [Migration("20170316050433_Initial-Commit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Module.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Module.ModuleTestCaseMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ModuleId");

                    b.Property<int>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("ModuleTestCaseMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Project.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Hardware");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Prerequisite");

                    b.Property<string>("TestEnvironment");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Scenario.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Scenario");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Scenario.ScenarioTestCaseMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ScenarioId");

                    b.Property<int>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("ScenarioTestCaseMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DefectId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PostCondition");

                    b.Property<string>("PreCondition");

                    b.Property<int>("PreparedBy");

                    b.Property<bool>("Priority");

                    b.Property<int?>("ReviewedBy");

                    b.Property<int>("SerialNumber");

                    b.Property<string>("TestCaseId");

                    b.Property<int>("TestCaseResultHistoryId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("TestCaseResultHistoryId")
                        .IsUnique();

                    b.ToTable("TestCase");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TestCaseStepsId");

                    b.Property<string>("TestInput");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseStepsId");

                    b.ToTable("TestCaseInput");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseInputVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TestCaseInputId");

                    b.Property<string>("TestInput");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseInputId");

                    b.ToTable("TestCaseInputVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseResultHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TestCaseId");

                    b.Property<int>("TestCaseResult");

                    b.HasKey("Id");

                    b.ToTable("TestCaseResultHistory");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualResult");

                    b.Property<DateTime?>("ActualResultDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ExpectedResult");

                    b.Property<DateTime>("ExpectedResultDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TestCaseId");

                    b.Property<string>("TestStep");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestCaseSteps");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseStepsVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualResult");

                    b.Property<DateTime?>("ActualResultDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ExpectedResult");

                    b.Property<DateTime>("ExpectedResultDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TestCaseStepsId");

                    b.Property<string>("TestStep");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseStepsId");

                    b.ToTable("TestCaseStepsVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DefectId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PostCondition");

                    b.Property<string>("PreCondition");

                    b.Property<int>("PreparedBy");

                    b.Property<bool>("Priority");

                    b.Property<int?>("ReviewedBy");

                    b.Property<int>("SerialNumber");

                    b.Property<int>("TCId");

                    b.Property<string>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("TCId");

                    b.ToTable("TestCaseVersion");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.User.ProjectUserMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("ProjectId");

                    b.Property<int>("Role");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUserMapping");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("RefreshToken")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Module.ModuleTestCaseMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Module.Module", "Module")
                        .WithMany("ModelTestCaseMapping")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", "TestCase")
                        .WithMany("ModuleTestCaseMapping")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.Scenario.ScenarioTestCaseMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Scenario.Scenario", "Scenario")
                        .WithMany("ScenarioTestCaseMapping")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", "TestCase")
                        .WithMany("ScenarioTestCaseMapping")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseResultHistory", "TestCaseResultHistory")
                        .WithOne("TestCase")
                        .HasForeignKey("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", "TestCaseResultHistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseInput", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseSteps", "TestCaseSteps")
                        .WithMany("TestCaseInputs")
                        .HasForeignKey("TestCaseStepsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseInputVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseInput", "TestCaseInput")
                        .WithMany()
                        .HasForeignKey("TestCaseInputId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseSteps", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", "TestCase")
                        .WithMany("TestCaseSteps")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseStepsVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseSteps", "TestCaseSteps")
                        .WithMany()
                        .HasForeignKey("TestCaseStepsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCaseVersion", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.TestCase.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TCId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Promact.TestCaseManagement.DomainModel.Models.User.ProjectUserMapping", b =>
                {
                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.Project.Project", "Project")
                        .WithMany("ProjectUserMapping")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promact.TestCaseManagement.DomainModel.Models.User.UserInfo", "User")
                        .WithMany("ProjectUserMapping")
                        .HasForeignKey("UserId");
                });
        }
    }
}