using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.Scenario;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.ScenarioRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Authorize]
    [Route(StringConstants.ProjectBaseUrl)]
    public class ScenarioController : Controller
    {
        #region "Private Member(s)"

        readonly IScenarioRepository _iScenarioRepository;
        readonly IProjectRepository _iProjectRepository;
        readonly IMapper _iMapper;

        #endregion

        #region "Constructor"

        public ScenarioController(IScenarioRepository iScenarioRepository, IProjectRepository iProjectRepository, IMapper iMapper)
        {
            _iScenarioRepository = iScenarioRepository;
            _iProjectRepository = iProjectRepository;
            _iMapper = iMapper;
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
            return Ok(await _iScenarioRepository.GetScenariosAsync(projectId));
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
            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, id);

            if (scenario != null)
            {
                return Ok(scenario);
            }

            return NotFound();
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

            var scenario = _iMapper.Map<Scenario>(scenarioAC);
            scenario.ProjectId = projectId;

            try
            {
                return Ok(await _iScenarioRepository.AddScenarioAsync(scenario));
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
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

            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, id);
            if (scenario == null)
            {
                return NotFound();
            }

            _iMapper.Map(scenarioAC, scenario);

            try
            {
                await _iScenarioRepository.UpdateScenarioAsync(scenario);
                return Ok(scenario);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method to delete scenario from the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="scenarioId">Id of the scenario</param>
        /// <returns></returns>
        [HttpDelete("{projectId}/scenario/{id}")]
        public async Task<IActionResult> DeleteScenarioAsync(int projectId, int scenarioId)
        {
            var isUserAuthorised = await _iProjectRepository.IsUserAssociatedWithProjectAsync(projectId, User.Claims.Single(x => x.Type.Equals(StringConstants.Sub)).Value);

            if (!isUserAuthorised)
            {
                return Unauthorized();
            }

            var scenario = await _iScenarioRepository.GetScenarioAsync(projectId, scenarioId);

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
