using Promact.TestCaseManagement.DomainModel.Models.User;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.UserRepository
{
    public interface IUserInfoRepository
    {
        /// <summary>
        /// Method used to save user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        Task<UserInfo> AddUserInfoAsync(UserInfo userInfo);

        /// <summary>
        /// Method used to update user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        Task<UserInfo> UpdateUserInfoAsync(UserInfo userInfo);

        /// <summary>
        /// Method used to get user info by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserInfo> GetUserByUserIdAsync(string userId);
    }
}