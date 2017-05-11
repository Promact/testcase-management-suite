using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass
{
    public class UserDetailWithProject
    {
        public UserAC UserAc { get; set; }

        public IEnumerable<ProjectAC> ListOfProject { get; set; }
    }
}