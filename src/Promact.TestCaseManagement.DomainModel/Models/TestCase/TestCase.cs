using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCase : TestCaseBase
    {
        #region Constructor

        public TestCase()
        {
            TestCaseSteps = new List<TestCaseSteps>();
        }

        #endregion

        #region Public Properties        

        public ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        #endregion
    }
}