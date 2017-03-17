using System.Collections.Generic;
using System.Threading.Tasks;
using Promact.TestCaseManagement.DomainModel.Models.TestCase;
using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;

namespace Promact.TestCaseManagement.Repository.TestCaseRepository
{
    public class TestCaseRepository : ITestCaseRepository
    {
        #region Private Member(s)
        
        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region Constructor

        public TestCaseRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Method(s)

        /// <summary>
        /// Method to get all test cases
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestCase>> GetTestCasesAsync()
        {
            return await _dbContext.TestCase.Include(x => x.TestCaseSteps).ToListAsync();
        }

        /// <summary>
        /// Method to add test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <returns></returns>
        public async Task<TestCase> AddTestCaseAsync(TestCase testCase)
        {
            await _dbContext.TestCase.AddAsync(testCase);
            await _dbContext.SaveChangesAsync();
            return testCase;
        }

        /// <summary>
        /// Method to update test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <returns></returns>
        public async Task<TestCase> UpdateTestCaseAsync(TestCase testCase)
        {
            _dbContext.TestCase.Update(testCase);
            await _dbContext.SaveChangesAsync();
            return testCase;
        }

        /// <summary>
        /// Method to delete test case from the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        public async void DeleteTestCaseAsync(TestCase testCase)
        {
            _dbContext.TestCase.Remove(testCase);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to retrieve single test case from database
        /// </summary>
        /// <param name="testCaseId">Id of the test case </param>
        /// <returns></returns>
        public async Task<TestCase> GetTestCase(int testCaseId)
        {
            return await _dbContext.TestCase.FindAsync(testCaseId);
        }

        #endregion
    }
}
