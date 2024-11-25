using System.ComponentModel.DataAnnotations;

namespace Sigma.Task.Application.DTOs
{
    public class CandidateDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please provide first name")]
        [MaxLength(50, ErrorMessage = "First name can be of maximum 50 characters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please provide last name")]
        [MaxLength(50, ErrorMessage = "Last name can be of maximum 50 characters")]
        public string LastName { get; set; } = null!;

        [RegularExpression(@"^\+?[1-9][0-9]{7,15}$", ErrorMessage = "Please provide valid phone number (Ex: +9779878675667)")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please provide valid email")]
        [MaxLength(50, ErrorMessage = "Email can be of maximum 50 characters")]
        public string Email { get; set; } = null!;

        public DateTime? CallSchedule { get; set; }

        [RegularExpression(@"^(https?|ftps?):\/\/(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}(?::(?:0|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5]))?(?:\/(?:[-a-zA-Z0-9@%_\+.~#?&=]+\/?)*)?$", ErrorMessage = "Please provide valid linkedin url")]
        public string? LinkedInProfile { get; set; }

        [RegularExpression(@"^(https?|ftps?):\/\/(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}(?::(?:0|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5]))?(?:\/(?:[-a-zA-Z0-9@%_\+.~#?&=]+\/?)*)?$", ErrorMessage = "Please provide valid github url")]
        public string? GitHubProfile { get; set; }

        [Required(ErrorMessage = "Please add comment")]
        [MaxLength(500, ErrorMessage = "Comment can be of maximum 500 characters")]
        public string Comment { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
