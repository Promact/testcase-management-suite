using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Repository.ScenarioRepository;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route("api/project")]
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

        #region "Public Member(s)"

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

        [HttpPost("{projectId}/scenario")]
        public async Task<IActionResult> CreateScenarioAsync(int projectId, [FromBody]Scenario scenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            await _iScenarioRepository.AddScenarioAsync(scenario);

            return Ok(scenario);
        }

        [HttpPut("{projectId}/scenario/{id}")]
        public async Task<IActionResult> UpdateScenarioAsync(int projectId, int id, [FromBody] Scenario scenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId) && !await _iScenarioRepository.IsScenarioExistAsync(id))
            {
                return NotFound();
            }

            await _iScenarioRepository.UpdateScenarioAsync(scenario);

            return NoContent();
        }

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
