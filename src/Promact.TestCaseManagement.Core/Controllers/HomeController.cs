using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models.Global;
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

        #endregion

        #region Constructor

        public HomeController(IUserInfoRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Public Actions

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userInfo = new UserInfo();
                userInfo.Email = User.Claims.ToList().Single(x => x.Type.Equals(StringConstants.Email)).Value;
                userInfo.UserId = User.Claims.ToList().Single(x => x.Type.Equals(StringConstants.Sub)).Value;
                userInfo.RefreshToken = await HttpContext.Authentication.GetTokenAsync(StringConstants.RefreshToken);
                var userDetails = await _userRepository.GetUserByUserIdAsync(userInfo.UserId);
                if (userDetails != null)
                {
                    userDetails.RefreshToken = userInfo.RefreshToken;
                    await _userRepository.UpdateUserInfoAsync(userDetails);
                }
                else
                {
                    await _userRepository.AddUserInfoAsync(userInfo);
                }
                return View(nameof(Dashboard));
            }
            return View();
        }

        [Authorize()]
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