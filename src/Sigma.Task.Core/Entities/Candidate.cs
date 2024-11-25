using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sigma.Task.Core.Entities
{
    public class Candidate : BaseEntity
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "nvarchar(15)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? CallSchedule { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? LinkedInProfile { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? GitHubProfile { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Comment { get; set; } = null!;
    }
}
