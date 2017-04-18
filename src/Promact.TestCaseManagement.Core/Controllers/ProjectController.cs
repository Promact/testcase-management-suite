using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route(StringConstants.ProjectBaseUrl)]
    public class ProjectController : Controller
    {
        #region "Private Member(s)"

        readonly IProjectRepository _iProjectRepository;

        #endregion

        #region "Constructor"

        public ProjectController(IProjectRepository iProjectRepository)
        {
            _iProjectRepository = iProjectRepository;
        }

        #endregion

        #region "Public API(s)"

        /// <summary>
        /// Method to get all projects of user
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetProjectsAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userInfo = new UserInfo();
                userInfo.Id = User.Claims.ToList().Single(x => x.Type.Equals(StringConstants.Sub)).Value;

                return Ok(await _iProjectRepository.GetProjectsAsync(userInfo.Id));
            }
            return Unauthorized();
        }

        #endregion
    }
}
