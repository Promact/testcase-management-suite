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

        /// <summary>
        /// Method to add project user mapping
        /// </summary>
        /// <param name="projectUserMapping">Project user mapping object</param>
        /// <returns></returns>
        public async Task<ProjectUserMapping> AddProjectUserMapping(ProjectUserMapping projectUserMapping)
        {
            await _dbContext.ProjectUserMapping.AddAsync(projectUserMapping);
            await _dbContext.SaveChangesAsync();
            return projectUserMapping;
        }

        /// <summary>
        /// Method to add project user mapping list
        /// </summary>
        /// <param name="projectUserMappingList">Project user mapping list object</param>
        /// <returns></returns>
        public async Task AddProjectUserMappingList(List<ProjectUserMapping> projectUserMappingList)
        {
            await _dbContext.ProjectUserMapping.AddRangeAsync(projectUserMappingList);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
