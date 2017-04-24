using System.Collections.Generic;

namespace Promact.TestCaseManagement.Repository.ApplicationClass
{
    public class UserAC
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ProjectAC> Projects { get; set; }
    }
}
