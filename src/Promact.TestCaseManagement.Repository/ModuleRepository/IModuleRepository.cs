using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ModuleRepository
{
    public interface IModuleRepository
    {
        /// <summary>
        /// Method to get all modules
        /// </summary>
        /// <returns></returns>
        Task<List<Module>> GetModulesAsync(int projectId);

        /// <summary>
        /// Method to add module to the database
        /// </summary>
        /// <param name="module">Module object</param>
        /// <returns></returns>
        Task<Module> AddModuleAsync(Module module);

        /// <summary>
        /// Method to update module to the database
        /// </summary>
        /// <param name="module">Module object</param>
        /// <returns></returns>
        Task<Module> UpdateModuleAsync(Module module);

        /// <summary>
        /// Method to delete module from the database
        /// </summary>
        /// <param name="module">Module object</param>
        Task DeleteModuleAsync(Module module);

        /// <summary>
        /// Method to retrieve single module from database
        /// </summary>
        /// <param name="moduleId">Id of the module</param>
        /// <returns></returns>
        Task<Module> GetModuleAsync(int projectId, int moduleId);

    }
}
