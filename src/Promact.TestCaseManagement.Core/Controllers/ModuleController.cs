using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.Module;
using Promact.TestCaseManagement.Repository.ModuleRepository;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Authorize]
    [Route(BaseUrl)]
    public class ModuleController : Controller
    {
        #region "Private Member(s)"

        readonly IModuleRepository _iModuleRepository;
        readonly IProjectRepository _iProjectRepository;
        readonly IMapper _iMapper;
        readonly IStringConstant _iStringConstant;
        internal const string BaseUrl = "api/project";

        #endregion

        #region "Constructor"

        public ModuleController(IModuleRepository iModuleRepository, IProjectRepository iProjectRepository, IMapper iMapper, IStringConstant iStringConstant)
        {
            _iModuleRepository = iModuleRepository;
            _iProjectRepository = iProjectRepository;
            _iMapper = iMapper;
            _iStringConstant = iStringConstant;
        }

        #endregion

        #region "Public API(s)"

        /// <summary>
        /// API to get all modules
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns></returns>
        [HttpGet("{projectId}/module")]
        public async Task<IActionResult> GetModulesAsync(int projectId)
        {
            return Ok(await _iModuleRepository.GetModulesAsync(projectId));
        }

        /// <summary>
        /// API to retrieve single module from database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="id">Id of the module</param>
        /// <returns></returns>
        [HttpGet("{projectId}/module/{id}")]
        public async Task<IActionResult> GetModuleAsync(int projectId, int id)
        {
            var module = await _iModuleRepository.GetModuleAsync(projectId, id);

            if (module != null)
            {
                return Ok(module);
            }

            return NotFound();
        }

        /// <summary>
        /// API to add module to the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="moduleAC">Module object</param>
        /// <returns></returns>
        [HttpPost("{projectId}/module")]
        public async Task<IActionResult> CreateModuleAsync(int projectId, [FromBody]ModuleAC moduleAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = _iMapper.Map<Module>(moduleAC);
            module.ProjectId = projectId;

            try
            {
                return Ok(await _iModuleRepository.AddModuleAsync(module));
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API to update module to the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="id">Id of the module</param>
        /// <param name="moduleAC">Module object</param>
        /// <returns></returns>
        [HttpPut("{projectId}/module/{id}")]
        public async Task<IActionResult> UpdateModuleAsync(int projectId, int id, [FromBody] ModuleAC moduleAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = await _iModuleRepository.GetModuleAsync(projectId, id);
            if (module == null)
            {
                return NotFound();
            }

            _iMapper.Map(moduleAC, module);
            try
            {
                await _iModuleRepository.UpdateModuleAsync(module);
                return Ok(module);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API to delete module from the database
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <param name="moduleId">Id of the module</param>
        /// <returns></returns>
        [HttpDelete("{projectId}/module/{id}")]
        public async Task<IActionResult> DeleteModule(int projectId, int moduleId)
        {
            var isUserAuthorised = await _iProjectRepository.IsUserAssociatedWithProjectAsync(projectId, User.Claims.Single(x => x.Type.Equals(_iStringConstant.Sub)).Value);

            if (!isUserAuthorised)
            {
                return Unauthorized();
            }

            var module = await _iModuleRepository.GetModuleAsync(projectId, moduleId);

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
