using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.User
{
    public class UserInfo
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public virtual ICollection<ProjectUserMapping> ProjectUserMapping { get; set; }
    }
}
