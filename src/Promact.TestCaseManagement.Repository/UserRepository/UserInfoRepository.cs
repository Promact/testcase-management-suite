using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models.User;
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

        /// <summary>
        /// Method used to save user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        public async Task<UserInfo> AddUserInfoAsync(UserInfo userInfo)
        {
            userInfo.CreatedDate = DateTime.UtcNow;
            _dbContext.UserInfo.Add(userInfo);
            await _dbContext.SaveChangesAsync();
            return userInfo;
        }

        /// <summary>
        /// Method used to update user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        public async Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo)
        {
            _dbContext.UserInfo.Update(userInfo);
            await _dbContext.SaveChangesAsync();
            return userInfo;
        }

        /// <summary>
        /// Method used to get user info by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserByUserIdAsync(string userId)
        {
            return await _dbContext.UserInfo.FindAsync(userId);
        }

        #endregion
    }
}