using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
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

        /// <summary>
        /// Method to check that project is associated with user or not
        /// Method to get all projects of user
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <param name="userId">id of the user</param>
        /// <returns></returns>
        Task<bool> IsUserAssociatedWithProjectAsync(int projectId, string userId);
        Task<IEnumerable<Project>> GetProjectsAsync(string userId);
    }
}
