using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ScenarioRepository
{
    public interface IScenarioRepository
    {
        /// <summary>
        /// Method to get all scenario
        /// </summary>
        /// <returns></returns>
        Task<List<Scenario>> GetScenariosAsync(int projectId);

        /// <summary>
        /// Method to add scenario to the database
        /// </summary>
        /// <param name="scenario">Scenario object</param>
        /// <returns></returns>
        Task<Scenario> AddScenarioAsync(Scenario scenario);

        /// <summary>
        /// Method to update scenario to the database
        /// </summary>
        /// <param name="scenario">Scenario object</param>
        /// <returns></returns>
        Task<Scenario> UpdateScenarioAsync(Scenario scenario);

        /// <summary>
        /// Method to delete scenario from the database
        /// </summary>
        /// <param name="scenario">Scenario object</param>
        Task DeleteScenarioAsync(Scenario scenario);

        /// <summary>
        /// Method to retrieve single scenario from database
        /// </summary>
        /// <param name="scenarioId">Id of the scenario</param>
        /// <returns></returns>
        Task<Scenario> GetScenarioAsync(int projectId,int scenarioId);

        /// <summary>
        /// Method to check scenario is exist or not
        /// </summary>
        /// <param name="scenarioId"></param>
        /// <returns></returns>
        Task<bool> IsScenarioExistAsync(int scenarioId);
    }
}
