using Promact.TestCaseManagement.DomainModel.Models.Project;
using Promact.TestCaseManagement.Repository.DataRepository;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        #region Private Members

        readonly IDataRepository<Project> _projectRepository;

        #endregion

        #region Constructor

        public ProjectRepository(IDataRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
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
            _projectRepository.Add(project);
            await _projectRepository.SaveChangesAsync();
            return project;
        }

        #endregion
    }
}
