using System.ComponentModel.DataAnnotations;

namespace sahadLearn.API.models.DTO.auth
{
    public class registerRequstDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public String UserRole { get; set; }
    }
}