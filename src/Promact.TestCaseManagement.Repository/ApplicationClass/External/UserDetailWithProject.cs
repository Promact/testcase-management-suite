using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.External
{
    public class UserDetailWithProject
    {
        public UserAC UserAc { get; set; }

        public List<ProjectAC> ListOfProject { get; set; }
    }
}