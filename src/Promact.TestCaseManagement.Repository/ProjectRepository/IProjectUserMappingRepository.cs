using Promact.TestCaseManagement.DomainModel.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public interface IProjectUserMappingRepository
    {
        /// <summary>
        /// Method to add project user mapping
        /// </summary>
        /// <param name="projectUserMapping">Project user mapping object</param>
        /// <returns></returns>
        Task<ProjectUserMapping> AddProjectUserMapping(ProjectUserMapping projectUserMapping);

        /// <summary>
        /// Method to add project user mapping list
        /// </summary>
        /// <param name="projectUserMappingList">Project user mapping list object</param>
        /// <returns></returns>
        void AddProjectUserMappingList(List<ProjectUserMapping> projectUserMappingList);
    }
}