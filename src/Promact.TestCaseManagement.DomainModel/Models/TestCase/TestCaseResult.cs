using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseResult : TestCaseResultBase
    {
        #region Constructors

        public TestCaseResult()
        {
            TestCaseSteps = new List<TestCaseSteps>();
        }

        #endregion

        #region Public Properties
                
        public virtual ICollection<TestCaseSteps> TestCaseSteps { get; set; }

        #endregion
    }
}