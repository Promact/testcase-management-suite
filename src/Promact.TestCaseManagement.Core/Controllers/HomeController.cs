using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.Utility.Constants;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(nameof(Dashboard));
            }
            return View();
        }

        [Authorize()]
        public IActionResult Dashboard()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LogOff()
        {
            return new SignOutResult(new[] { "Cookies", "oidc" });
        }
    }
}