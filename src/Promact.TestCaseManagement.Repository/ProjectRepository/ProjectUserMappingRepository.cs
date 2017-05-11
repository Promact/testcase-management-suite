using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public class ProjectUserMappingRepository : IProjectUserMappingRepository
    {
        #region Private Members

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region Constructor

        public ProjectUserMappingRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Members

        public async Task<ProjectUserMapping> AddProjectUserMapping(ProjectUserMapping projectUserMapping)
        {
            await _dbContext.ProjectUserMapping.AddAsync(projectUserMapping);
            await _dbContext.SaveChangesAsync();
            return projectUserMapping;
        }

        public async Task AddProjectUserMappingList(List<ProjectUserMapping> projectUserMappingList)
        {
            await _dbContext.ProjectUserMapping.AddRangeAsync(projectUserMappingList);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
