using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        #region "Private Members"

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region "Constructor"

        public ProjectRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region "Public Method(s)"

        public async Task<Project> AddProjectAsync(Project project)
        {
            await _dbContext.Project.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(string userId)
        {
            return (await _dbContext.ProjectUserMapping.Where(x => x.UserId == userId).Include(x => x.Project).Select(x => x.Project).ToListAsync());
        }

        #endregion
    }
}
