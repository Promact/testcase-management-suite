using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.Module;
using Promact.TestCaseManagement.Repository.ModuleRepository;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route("api/project")]
    public class ModuleController : Controller
    {
        #region "Private Member(s)"
        readonly IModuleRepository _iModuleRepository;
        readonly IProjectRepository _iProjectRepository;
        #endregion

        #region "Constructor"
        public ModuleController(IModuleRepository iModuleRepository, IProjectRepository iProjectRepository)
        {
            _iModuleRepository = iModuleRepository;
            _iProjectRepository = iProjectRepository;
        }
        #endregion

        #region "Public Member(s)"

        [HttpGet("{projectId}/module")]
        public async Task<IActionResult> GetModulesAsync(int projectId)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var listOfModules = await _iModuleRepository.GetModulesAsync(projectId);

            return Ok(listOfModules);

        }

        [HttpGet("{projectId}/module/{id}")]
        public async Task<IActionResult> GetModuleAsync(int projectId, int id)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var module = await _iModuleRepository.GetModuleAsync(projectId, id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        [HttpPost("{projectId}/module")]
        public async Task<IActionResult> CreateModuleAsync(int projectId, [FromBody]ModuleAC moduleAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }
            var module = Mapper.Map<Module>(moduleAC);
            module.ProjectId = projectId;
            await _iModuleRepository.AddModuleAsync(module);

            return Ok(module);
        }

        [HttpPut("{projectId}/module/{id}")]
        public async Task<IActionResult> UpdateModuleAsync(int projectId, int id, [FromBody] ModuleAC moduleAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }
            var module = await _iModuleRepository.GetModuleAsync(projectId, id);
            if (module == null)
            {
                return NotFound();
            }

            Mapper.Map(moduleAC, module);
            await _iModuleRepository.UpdateModuleAsync(module);

            return NoContent();
        }

        [HttpDelete("{projectId}/module/{id}")]
        public async Task<IActionResult> DeleteModule(int projectId, int id)
        {
            if (!await _iProjectRepository.IsProjectExistAsync(projectId))
            {
                return NotFound();
            }

            var module = await _iModuleRepository.GetModuleAsync(projectId, id);

            if (module == null)
            {
                return NotFound();
            }

            await _iModuleRepository.DeleteModuleAsync(module);

            return NoContent();
        }

        #endregion
    }
}
