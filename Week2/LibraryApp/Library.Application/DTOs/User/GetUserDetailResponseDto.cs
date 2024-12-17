namespace Library.Application.DTOs.User;

public record GetUserDetailResponseDto
(
    Guid Id,
    string UserName,
    string Email,
    string PhoneNumber
);
