﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.Repository.ProjectRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Authorize]
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
                return Ok(await _iProjectRepository.GetProjectsAsync(User.Claims.Single(x => x.Type.Equals(StringConstants.Sub)).Value));
            }
            return Unauthorized();
        }

        #endregion
    }
}
