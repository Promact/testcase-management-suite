using Promact.TestCaseManagement.DomainModel.Enums;
using System;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseResultHistory
    {
        public int Id { get; set; }

        public int TestCaseId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public TestCaseResultStatus TestCaseResult { get; set; }

        public virtual TestCase TestCase { get; set; }
    }
}