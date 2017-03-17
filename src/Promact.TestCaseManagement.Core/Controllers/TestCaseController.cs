using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promact.TestCaseManagement.DomainModel.Models.TestCase;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using Promact.TestCaseManagement.Repository.TestCaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Core.Controllers
{
    [Route("api/TestCase")]
    public class TestCaseController : Controller
    {
        readonly ITestCaseRepository _iTestCaseRepository;

        public TestCaseController(ITestCaseRepository iTestCaseRepository)
        {
            _iTestCaseRepository = iTestCaseRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTestCases()
        {
            var listOfTestCases = await _iTestCaseRepository.GetTestCasesAsync();
            var finalListOfTestCases = Mapper.Map<List<TestCaseAC>>(listOfTestCases);
            return Ok(finalListOfTestCases);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTestCase([FromBody]TestCaseAC testCaseAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var testCase = Mapper.Map<TestCase>(testCaseAC);
            await _iTestCaseRepository.AddTestCaseAsync(testCase);
            return Ok(testCase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestCase(int id, [FromBody] TestCaseAC testCaseAC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var testCase = await _iTestCaseRepository.GetTestCase(id);
            if (testCase == null)
            {
                return NotFound();
            }

            Mapper.Map(testCaseAC, testCase);

            await _iTestCaseRepository.UpdateTestCaseAsync(testCase);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCase(int id)
        {
            var testCase = await _iTestCaseRepository.GetTestCase(id);
            if (testCase == null)
            {
                return NotFound();
            }
            _iTestCaseRepository.DeleteTestCaseAsync(testCase);
            return NoContent();
        }
    }
}