using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.GlobalRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Controllers
{
    public class HomeController : Controller
    {

        #region Private Members

        readonly IUserInfoRepository _userRepository;
        readonly IGlobalRepository _iGlobalRepository;

        #endregion

        #region Constructor

        public HomeController(IUserInfoRepository userRepository, IGlobalRepository iGlobalRepository)
        {
            _userRepository = userRepository;
            _iGlobalRepository = iGlobalRepository;
        }

        #endregion

        #region Public Actions

        /// <summary>
        /// Index action
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userInfo = new UserInfo();
                userInfo.Email = User.Claims.Single(x => x.Type.Equals(StringConstants.Email)).Value;
                userInfo.Id = User.Claims.Single(x => x.Type.Equals(StringConstants.Sub)).Value;
                userInfo.RefreshToken = await HttpContext.Authentication.GetTokenAsync(StringConstants.RefreshToken);
                var userDetails = await _userRepository.GetUserByUserIdAsync(userInfo.Id);
                if (userDetails != null)
                {
                    userDetails.RefreshToken = userInfo.RefreshToken;
                    await _userRepository.UpdateUserInfoAsync(userDetails);
                }
                else
                {
                    await _iGlobalRepository.SyncProjectAndUserDetails(userInfo);
                }
                return View(nameof(Dashboard));
            }
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync(StringConstants.Cookies);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View();
        }

        #endregion
    }
}