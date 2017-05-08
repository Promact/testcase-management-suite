using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.TestCaseRepository
{
    public interface ITestCaseRepository
    {
        /// <summary>
        /// Method to get all test cases
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TestCaseAC>> GetTestCasesAsync();

        /// <summary>
        /// Method to add test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <param name="email">Email of logged in user</param>
        /// <returns></returns>
        Task<TestCaseAC> AddTestCaseAsync(TestCaseAC testCaseAC, string email);

        /// <summary>
        /// Method to update test case to the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        /// <returns></returns>
        Task<TestCase> UpdateTestCaseAsync(TestCase testCase);

        /// <summary>
        /// Method to delete test case from the database
        /// </summary>
        /// <param name="testCase">Test case object</param>
        void DeleteTestCaseAsync(TestCase testCase);

        /// <summary>
        /// Method to retrieve single test case from database
        /// </summary>
        /// <param name="testCaseId">Id of the test case </param>
        /// <returns></returns>
        Task<TestCase> GetTestCase(int testCaseId);
    }
}
