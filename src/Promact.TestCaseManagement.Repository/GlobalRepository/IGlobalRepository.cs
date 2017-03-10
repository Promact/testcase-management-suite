using Promact.TestCaseManagement.DomainModel.Models.User;

namespace Promact.TestCaseManagement.Repository.GlobalRepository
{
    public interface IGlobalRepository
    {
        /// <summary>
        /// Method to sync project and user details
        /// </summary>
        /// <param name="userInfo">User info object</param>
        void SyncProjectAndUserDetails(UserInfo userInfo);
    }
}
