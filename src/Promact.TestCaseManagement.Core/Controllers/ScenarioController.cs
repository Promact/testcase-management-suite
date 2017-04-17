using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.Scenario;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.ScenarioRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route(StringConstants.ProjectBaseUrl)]
    public class ScenarioController : Controller
    {
        #region "Private Member(s)"
        readonly IScenarioRepository _iScenarioRepository;
        readonly IProjectRepository _iProjectRepository;
        #endregion

        #region "Constructor"
        public ScenarioController(IScenarioRepository iScenarioRepository, IProjectRepository iProjectRepository)
        {
            _iScenarioRepository = iScenarioRepository;
            _iProjectRepository = iProjectRepository;
        }
        #endregion

        #region "Public API(s)"

        /// <summary>
        /// Method to get all scenario
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns></returns>
        [HttpGet("{projectId}/scenario")]
        public async Task<IActionResult> GetScenariosAsync(int projectId)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var listOfScenarios = await _iScenarioRepository.GetScenariosAsync(projectId);

            return Ok(listOfScenarios);
        }

        /// <summary>
        ///  Method to retrieve single module from database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="id">Id of the scenario</param>
        /// <returns></returns>
        [HttpGet("{projectId}/scenario/{id}")]
        public async Task<IActionResult> GetScenarioAsync(int projectId, int id)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, id);

            if (scenario == null)
            {
                return NotFound();
            }

            return Ok(scenario);
        }

        /// <summary>
        /// Method to add scenario to the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="scenarioAC">Id of the scenario</param>
        /// <returns></returns>
        [HttpPost("{projectId}/scenario")]
        public async Task<IActionResult> CreateScenarioAsync(int projectId, [FromBody]ScenarioAC scenarioAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var scenario = Mapper.Map<Scenario>(scenarioAC);
            scenario.ProjectId = projectId;
            await _iScenarioRepository.AddScenarioAsync(scenario);

            return Ok(scenario);
        }

        /// <summary>
        /// Method to update scenario to the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="id">Id of the scenario</param>
        /// <param name="scenarioAC">Scenario object</param>
        /// <returns></returns>
        [HttpPut("{projectId}/scenario/{id}")]
        public async Task<IActionResult> UpdateScenarioAsync(int projectId, int id, [FromBody] ScenarioAC scenarioAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }
            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, id);
            if (scenario == null)
            {
                return NotFound();
            }

            Mapper.Map(scenarioAC, scenario);

            await _iScenarioRepository.UpdateScenarioAsync(scenario);

            return NoContent();
        }

        /// <summary>
        /// Method to delete scenario from the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="id">Id of the scenario</param>
        /// <returns></returns>
        [HttpDelete("{projectId}/scenario/{id}")]
        public async Task<IActionResult> DeleteScenarioAsync(int projectId, int id)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, id);

            if (scenario == null)
            {
                return NotFound();
            }

            await _iScenarioRepository.DeleteScenarioAsync(scenario);

            return NoContent();
        }

        #endregion
    }
}
