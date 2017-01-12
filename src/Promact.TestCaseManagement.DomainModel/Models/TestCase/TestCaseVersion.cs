using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseVersion : TestCaseBase
    {
        #region Public Properties

        public int TCId { get; set; }
        
        [ForeignKey("TCId")]
        public virtual TestCase TestCase { get; set; }

        #endregion
    }
}