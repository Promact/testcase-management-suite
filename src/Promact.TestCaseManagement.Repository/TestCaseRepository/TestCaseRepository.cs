using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using Promact.TestCaseManagement.Repository.ApplicationClass.TestCase;
using AutoMapper;
using Promact.TestCaseManagement.Repository.UserRepository;
using System.Linq;
using Promact.TestCaseManagement.DomainModel.Enums;

namespace Promact.TestCaseManagement.Repository.TestCaseRepository
{
    public class TestCaseRepository : ITestCaseRepository
    {
        #region Private Member(s)

        readonly TestCaseManagementDbContext _dbContext;
        readonly IUserInfoRepository _iUserInfoRepository;
        readonly IMapper _iMapper;

        #endregion

        #region Constructor

        public TestCaseRepository(TestCaseManagementDbContext dbContext, IMapper iMapper, IUserInfoRepository iUserInfoRepository)
        {
            _dbContext = dbContext;
            _iMapper = iMapper;
            _iUserInfoRepository = iUserInfoRepository;
        }

        #endregion

        #region Public Method(s)

        public async Task<IEnumerable<TestCaseAC>> GetTestCasesAsync()
        {
            return _iMapper.Map<IEnumerable<TestCaseAC>>(await _dbContext.TestCase.Include(x => x.TestCaseConditions).Include(x => x.TestCaseSteps).ThenInclude(x => x.TestCaseInputs).ToListAsync());
        }

        public async Task<TestCaseAC> AddTestCaseAsync(TestCaseAC testCaseAC, string email)
        {
            string userId = (await _iUserInfoRepository.GetUserByEmailAsync(email))?.Id;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var testCase = _iMapper.Map<TestCase>(testCaseAC);
                testCase.CreatedUserId = userId;
                await _dbContext.TestCase.AddAsync(testCase);
                await _dbContext.SaveChangesAsync();

                var preConditions = _iMapper.Map<IEnumerable<TestCaseConditions>>(testCaseAC.PreConditions);
                preConditions.ToList().ForEach(x => x.TestCaseId = testCase.Id);
                await _dbContext.TestCaseConditions.AddRangeAsync(preConditions);

                var postConditions = _iMapper.Map<IEnumerable<TestCaseConditions>>(testCaseAC.PostConditions);
                postConditions.ToList().ForEach(x => x.TestCaseId = testCase.Id);
                await _dbContext.TestCaseConditions.AddRangeAsync(postConditions);

                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            return testCaseAC;
        }

        public async Task<TestCase> UpdateTestCaseAsync(TestCase testCase)
        {
            _dbContext.TestCase.Update(testCase);
            await _dbContext.SaveChangesAsync();
            return testCase;
        }

        public async Task DeleteTestCaseAsync(int id)
        {
            var testCase = await _dbContext.TestCase.FindAsync(id);
            await _dbContext.Entry(testCase).Collection(x => x.TestCaseSteps).LoadAsync();
            await _dbContext.Entry(testCase).Collection(x => x.TestCaseConditions).LoadAsync();

            foreach (var testCaseStep in testCase.TestCaseSteps.ToList())
            {
                await _dbContext.Entry(testCaseStep).Collection(y => y.TestCaseInputs).LoadAsync();
            }

            testCase.IsDeleted = true;
            testCase.TestCaseSteps.ToList().ForEach(x =>
            {
                x.TestCaseInputs.ToList().ForEach(z =>
                {
                    z.IsDeleted = true;
                });
                x.IsDeleted = true;
            });
            testCase.TestCaseConditions.ToList().ForEach(x =>
            {
                x.IsDeleted = true;
            });
        }

        public async Task<TestCaseAC> GetTestCaseByIdAsync(int testCaseId)
        {
            var testCase = await _dbContext.TestCase.FindAsync(testCaseId);
            if (testCase == null) return null;
            await _dbContext.Entry(testCase).Collection(x => x.TestCaseSteps).LoadAsync();
            await _dbContext.Entry(testCase).Collection(x => x.TestCaseConditions).LoadAsync();

            foreach (var testCaseStep in testCase.TestCaseSteps.ToList())
            {
                await _dbContext.Entry(testCaseStep).Collection(y => y.TestCaseInputs).LoadAsync();
            }

            var testCaseAC = _iMapper.Map<TestCaseAC>(testCase);
            testCaseAC.PreConditions = _iMapper.Map<IEnumerable<TestCaseConditionsAC>>(testCase.TestCaseConditions.Where(x => x.Condition == Condition.PreCondition));
            testCaseAC.PostConditions = _iMapper.Map<IEnumerable<TestCaseConditionsAC>>(testCase.TestCaseConditions.Where(x => x.Condition == Condition.PostCondition));
            return testCaseAC;
        }

        public async Task<bool> IsTestCaseExist(int id)
        {
            return await _dbContext.TestCase.AnyAsync(x => x.Id == id);
        }

        #endregion
    }
}