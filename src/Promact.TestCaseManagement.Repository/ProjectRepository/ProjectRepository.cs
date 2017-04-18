using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        #region Private Members

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region Constructor

        public ProjectRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Method to add project
        /// </summary>
        /// <param name="project">Project object</param>
        /// <returns></returns>
        public async Task<Project> AddProjectAsync(Project project)
        {
            await _dbContext.Project.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        #endregion
    }
}
