using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs.User;

public record SignupUserRequestDto
{
    [Required]
    public string UserName { get; init; }
    [Required]
    public string Email { get; init; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 character")]
    public string Password { get; init; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Password do not match")]
    public string ConfirmPassword { get; init; }

    public string PhoneNumber { get; init; }
}
