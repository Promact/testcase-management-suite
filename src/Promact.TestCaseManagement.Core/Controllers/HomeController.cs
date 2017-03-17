using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models.User;
using Promact.TestCaseManagement.Repository.ApplicationClass.External;
using Promact.TestCaseManagement.Repository.GlobalRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using Promact.TestCaseManagement.Utility.Constants;
using Promact.TestCaseManagement.Utility.Services.AccessToken;
using Promact.TestCaseManagement.Utility.Services.HttpClient;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Controllers
{
    public class HomeController : Controller
    {

        #region Private Members

        readonly IUserInfoRepository _userRepository;
        readonly IAccessTokenService _iAccessTokenService;
        readonly IHttpClientService _iHttpClientService;
        readonly IGlobalRepository _iGlobalRepository;

        #endregion

        #region Constructor

        public HomeController(IUserInfoRepository userRepository, IAccessTokenService iAccessTokenService, IHttpClientService iHttpClientService, IGlobalRepository iGlobalRepository)
        {
            _userRepository = userRepository;
            _iAccessTokenService = iAccessTokenService;
            _iHttpClientService = iHttpClientService;
            _iGlobalRepository = iGlobalRepository;
        }

        #endregion

        #region Public Actions

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userInfo = new UserInfo();
                userInfo.Email = User.Claims.ToList().Single(x => x.Type.Equals(StringConstants.Email)).Value;
                userInfo.Id = User.Claims.ToList().Single(x => x.Type.Equals(StringConstants.Sub)).Value;
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