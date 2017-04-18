using Promact.TestCaseManagement.DomainModel.Models;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Method to add project
        /// </summary>
        /// <param name="project">Project object</param>
        /// <returns></returns>
        Task<Project> AddProjectAsync(Project project);
    }
}
