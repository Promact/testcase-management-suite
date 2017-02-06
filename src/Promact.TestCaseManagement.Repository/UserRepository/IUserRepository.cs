using Promact.TestCaseManagement.DomainModel.Models.Global;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.UserRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Method used to save user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        Task<UserInfo> AddUserInfo(UserInfo userInfo);

        /// <summary>
        /// Method used to update user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        Task<UserInfo> UpdateUserInfo(UserInfo userInfo);
    }
}