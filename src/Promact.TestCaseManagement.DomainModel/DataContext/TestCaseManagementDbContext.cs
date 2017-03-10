using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.DomainModel.Models.Module;
using Promact.TestCaseManagement.DomainModel.Models.Project;
using Promact.TestCaseManagement.DomainModel.Models.Scenario;
using Promact.TestCaseManagement.DomainModel.Models.TestCase;
using Promact.TestCaseManagement.DomainModel.Models.User;
using System;
using System.Linq;

namespace Promact.TestCaseManagement.DomainModel.DataContext
{
    public class TestCaseManagementDbContext : DbContext
    {
        #region Constructors

        public TestCaseManagementDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        #endregion

        #region Public Properties

        public DbSet<Project> Project { get; set; }

        public DbSet<Module> Module { get; set; }

        public DbSet<Scenario> Scenario { get; set; }

        public DbSet<ModuleTestCaseMapping> ModuleTestCaseMapping { get; set; }

        public DbSet<ScenarioTestCaseMapping> ScenarioTestCaseMapping { get; set; }

        public DbSet<TestCase> TestCase { get; set; }

        public DbSet<TestCaseVersion> TestCaseVersion { get; set; }

        public DbSet<TestCaseStepsVersion> TestCaseStepsVersion { get; set; }

        public DbSet<TestCaseInputVersion> TestCaseInputVersion { get; set; }

        public DbSet<TestCaseResultHistory> TestCaseResultHistory { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<ProjectUserMapping> ProjectUserMapping { get; set; }

        #endregion

        #region Overridden Methods

        public override int SaveChanges()
        {
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Added).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).CreatedDate = DateTime.UtcNow;
            });
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Modified).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).ModifiedDate = DateTime.UtcNow;
            });

            return base.SaveChanges();
        }

        #endregion
    }
}