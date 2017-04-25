using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Authorize]
    [Route(BaseUrl)]
    public class ProjectController : Controller
    {
        #region "Private Member(s)"

        readonly IProjectRepository _iProjectRepository;
        internal const string BaseUrl = "api/project";
        IStringConstant _iStringConstant;

        #endregion

        #region "Constructor"

        public ProjectController(IProjectRepository iProjectRepository, IStringConstant iStringConstant)
        {
            _iProjectRepository = iProjectRepository;
            _iStringConstant = iStringConstant;
        }

        #endregion

        #region "Public API(s)"

        /// <summary>
        /// API to get all projects of user
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetProjectsAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(await _iProjectRepository.GetProjectsAsync(User.Claims.Single(x => x.Type.Equals(_iStringConstant.Sub)).Value));
            }
            return Unauthorized();
        }

        #endregion
    }
}
