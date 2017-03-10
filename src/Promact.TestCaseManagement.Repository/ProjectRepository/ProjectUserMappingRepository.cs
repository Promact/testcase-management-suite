using Promact.TestCaseManagement.DomainModel.Models.User;
using Promact.TestCaseManagement.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ProjectRepository
{
    public class ProjectUserMappingRepository : IProjectUserMappingRepository
    {
        #region Private Members

        readonly IDataRepository<ProjectUserMapping> _iProjectUserMappingRepository;

        #endregion

        #region Constructor

        public ProjectUserMappingRepository(IDataRepository<ProjectUserMapping> iProjectUserMappingRepository)
        {
            _iProjectUserMappingRepository = iProjectUserMappingRepository;
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
            _iProjectUserMappingRepository.Add(projectUserMapping);
            await _iProjectUserMappingRepository.SaveChangesAsync();
            return projectUserMapping;
        }

        /// <summary>
        /// Method to add project user mapping list
        /// </summary>
        /// <param name="projectUserMappingList">Project user mapping list object</param>
        /// <returns></returns>
        public async void AddProjectUserMappingList(List<ProjectUserMapping> projectUserMappingList)
        {
            _iProjectUserMappingRepository.AddRangeAsync(projectUserMappingList);
            await _iProjectUserMappingRepository.SaveChangesAsync();
        }

        #endregion
    }
}
