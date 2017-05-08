using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using Promact.TestCaseManagement.Repository.TestCaseRepository;
using Promact.TestCaseManagement.Repository.UserRepository;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route("api/testcase")]
    public class TestCaseController : Controller
    {
        #region Private Members

        readonly ITestCaseRepository _iTestCaseRepository;
        readonly IMapper _iMapper;
        readonly IUserInfoRepository _iUserInfoRepository;

        #endregion

        #region Constructor

        public TestCaseController(ITestCaseRepository iTestCaseRepository, IMapper iMapper, IUserInfoRepository iUserInfoRepository)
        {
            _iTestCaseRepository = iTestCaseRepository;
            _iMapper = iMapper;
            _iUserInfoRepository = iUserInfoRepository;
        }

        #endregion

        #region API

        /// <summary>
        /// Get API to fetch all test case list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTestCases()
        {
            return Ok(await _iTestCaseRepository.GetTestCasesAsync());
        }

        /// <summary>
        /// Get API to get single test case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestCaseById(int id)
        {
            var testCase = await _iTestCaseRepository.GetTestCaseByIdAsync(id);
            if (testCase == null) return NotFound();
            return Ok(testCase);
        }

        /// <summary>
        /// Post API to create test case
        /// </summary>
        /// <param name="testCaseAC">test case object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTestCase([FromBody]TestCaseAC testCaseAC)
        {
            if (!ModelState.IsValid || testCaseAC == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _iTestCaseRepository.AddTestCaseAsync(testCaseAC, User.Identity.Name));
        }

        ///// <summary>
        ///// Put API to update test case
        ///// </summary>
        ///// <param name="id">id of test case</param>
        ///// <param name="testCaseAC">test case object</param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTestCase(int id, [FromBody] TestCaseAC testCaseAC)
        //{
        //    if (!ModelState.IsValid || testCaseAC == null)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var testCase = await _iTestCaseRepository.GetTestCaseByIdAsync(id);
        //    if (testCase == null)
        //    {
        //        return NotFound();
        //    }

        //    _iMapper.Map(testCaseAC, testCase);
        //    await _iTestCaseRepository.UpdateTestCaseAsync(testCase);

        //    return Ok();
        //}

        /// <summary>
        /// Delete API to delete test case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCase(int id)
        {
            if (!await _iTestCaseRepository.IsTestCaseExist(id))
            {
                return NotFound();
            }
            await _iTestCaseRepository.DeleteTestCaseAsync(id);
            return NoContent();
        }

        #endregion
    }
}