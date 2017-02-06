using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promact.TestCaseManagement.DomainModel.Models.Global;
using Promact.TestCaseManagement.Repository.DataRepository;

namespace Promact.TestCaseManagement.Repository.UserRepository
{
    public class UserInfoRepository : IUserRepository
    {
        #region Private Member(s)

        readonly IDataRepository<UserInfo> _userInfoRepository;

        #endregion

        #region Constructors

        public UserInfoRepository()
        {

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Method used to save user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        public Task<UserInfo> AddUserInfo(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method used to update user info
        /// </summary>
        /// <param name="userInfo">UserInfo details</param>
        /// <returns></returns>
        public Task<UserInfo> UpdateUserInfo(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}