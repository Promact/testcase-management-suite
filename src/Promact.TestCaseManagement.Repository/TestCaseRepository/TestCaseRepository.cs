using System.Collections.Generic;
using System.Threading.Tasks;
using Promact.TestCaseManagement.Repository.DataRepository;
using Promact.TestCaseManagement.DomainModel.Models.TestCase;
using Microsoft.EntityFrameworkCore;

namespace Promact.TestCaseManagement.Repository.TestCaseRepository
{
    public class TestCaseRepository : ITestCaseRepository
    {
        #region Private Member(s)

        readonly IDataRepository<TestCase> _iTestCaseRepository;

        #endregion

        #region Constructor

        public TestCaseRepository(IDataRepository<TestCase> iTestCaseRepository)
        {
            _iTestCaseRepository = iTestCaseRepository;
        }

        #endregion

        #region Public Method(s)

        /// <summary>
        /// Method to get all test cases
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestCase>> GetTestCasesAsync()
        {
            return await _iTestCaseRepository.GetAll().Include(x => x.TestCaseSteps).ToListAsync();
        }

        /// <summary>
        /// Method to add test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <returns></returns>
        public async Task<TestCase> AddTestCaseAsync(TestCase testCase)
        {
            _iTestCaseRepository.Add(testCase);
            await _iTestCaseRepository.SaveChangesAsync();
            return testCase;
        }

        /// <summary>
        /// Method to update test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <returns></returns>
        public async Task<TestCase> UpdateTestCaseAsync(TestCase testCase)
        {
            _iTestCaseRepository.Update(testCase);
            await _iTestCaseRepository.SaveChangesAsync();
            return testCase;
        }

        /// <summary>
        /// Method to delete test case from the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        public async void DeleteTestCaseAsync(TestCase testCase)
        {
            _iTestCaseRepository.Delete(testCase);
            await _iTestCaseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Method to retrieve single test case from database
        /// </summary>
        /// <param name="testCaseId">Id of the test case </param>
        /// <returns></returns>
        public async Task<TestCase> GetTestCase(int testCaseId)
        {
            return await _iTestCaseRepository.FindAsync(testCaseId);
        }

        #endregion
    }
}
