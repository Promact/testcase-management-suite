using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.Repository.DataRepository;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.UserRepository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        #region Private Member(s)

        readonly IDataRepository<UserInfo> _userInfoRepository;

        #endregion

        #region Constructors

        public UserInfoRepository(IDataRepository<UserInfo> userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
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
            _userInfoRepository.Add(userInfo);
            await _userInfoRepository.SaveChangesAsync();
            return userInfo;
        }

        /// <summary>
        /// Method used to update user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        public async Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo)
        {
            _userInfoRepository.Update(userInfo);
            await _userInfoRepository.SaveChangesAsync();
            return userInfo;
        }

        /// <summary>
        /// Method used to get user info by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserByUserIdAsync(string userId)
        {
            return await _userInfoRepository.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        #endregion
    }
}