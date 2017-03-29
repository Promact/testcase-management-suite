using System;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models
{
    public abstract class TestCaseManagementBase
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}