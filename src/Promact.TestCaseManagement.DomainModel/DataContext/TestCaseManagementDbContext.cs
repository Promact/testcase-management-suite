using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public DbSet<TestCaseSteps> TestCaseSteps { get; set; }

        public DbSet<TestCaseStepsVersion> TestCaseStepsVersion { get; set; }

        public DbSet<TestCaseInput> TestCaseInput { get; set; }

        public DbSet<TestCaseInputVersion> TestCaseInputVersion { get; set; }

        public DbSet<TestCaseResultHistory> TestCaseResultHistory { get; set; }

        public DbSet<TestCaseConditions> TestCaseConditions { get; set; }

        public DbSet<TestCaseConditionsVersion> TestCaseConditionsVersion { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<ProjectUserMapping> ProjectUserMapping { get; set; }

        #endregion

        #region Overridden Methods

        /// <summary>
        /// override save changes method
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Added).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).CreatedDateTime = DateTime.UtcNow;
            });
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Modified).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).ModifiedDateTime = DateTime.UtcNow;
            });

            return base.SaveChanges();
        }

        /// <summary>
        /// override savechangesasync method
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Added).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).CreatedDateTime = DateTime.UtcNow;
            });
            ChangeTracker.Entries().Where(x => x.Entity is TestCaseManagementBase && x.State == EntityState.Modified).ToList().ForEach(x =>
            {
                ((TestCaseManagementBase)x.Entity).ModifiedDateTime = DateTime.UtcNow;
            });
            return await base.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}