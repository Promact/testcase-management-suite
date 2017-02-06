using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.Utility.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Controllers
{
    public class HomeController : Controller
    {

        #region Private Members




        #endregion

        #region Constructor

        public HomeController()
        {

        }

        #endregion

        #region Public Actions

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Claims.ToList().Single(x => x.Type.Equals("email"));
                var userId = User.Claims.ToList().Single(x => x.Type.Equals("sub"));
                var refreshToken = HttpContext.Authentication.GetTokenAsync("refresh_token");
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

        #endregion
    }
}