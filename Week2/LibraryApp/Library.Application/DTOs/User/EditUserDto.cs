using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.User;

public record EditUserDto
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    public string PhoneNumber { get; init; }

    //public string OldPassword { get; init; } = "";

    //[MinLength(6)]
    //public string NewPassword { get; init; } = "";

    //[Compare(nameof(NewPassword))]
    //public string ConfirmNewPassword { get; init; } = "";
}
