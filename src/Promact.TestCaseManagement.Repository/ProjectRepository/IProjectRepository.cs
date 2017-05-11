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
        /// </summary>
        /// <param name="projectId">project id</param>
        /// <param name="userId">logged in user id</param>
        /// <returns></returns>
        Task<bool> IsUserAssociatedWithProjectAsync(int projectId, string userId);

        /// <summary>
        /// Method to get all projects of user
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsAsync(string userId);
    }
}
