using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
