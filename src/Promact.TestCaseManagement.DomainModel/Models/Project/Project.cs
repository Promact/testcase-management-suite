using Promact.TestCaseManagement.DomainModel.Models.Global;

namespace Promact.TestCaseManagement.DomainModel.Models.Project
{
    public class Project : TestCaseManagementBase
    {
        public string Name { get; set; }

        public string Prerequisite { get; set; }

        public string TestEnvironment { get; set; }

        public string HardWare { get; set; }
    }
}