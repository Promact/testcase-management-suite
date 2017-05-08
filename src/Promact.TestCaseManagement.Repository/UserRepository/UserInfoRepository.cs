using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.UserRepository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        #region Private Member(s)

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region Constructors

        public UserInfoRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Members

        public async Task<UserInfo> AddUserInfoAsync(UserInfo userInfo)
        {
            userInfo.CreatedDateTime = DateTime.UtcNow;
            _dbContext.UserInfo.Add(userInfo);
            await _dbContext.SaveChangesAsync();
            return userInfo;
        }

        public async Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo)
        {
            _dbContext.UserInfo.Update(userInfo);
            await _dbContext.SaveChangesAsync();
            return userInfo;
        }

        public async Task<UserInfo> GetUserByUserIdAsync(string userId)
        {
            return await _dbContext.UserInfo.FindAsync(userId);
        }

        public async Task<UserInfo> GetUserByEmailAsync(string email)
        {
            return await _dbContext.UserInfo.SingleAsync(x => x.Email.Equals(email));
        }

        #endregion
    }
}