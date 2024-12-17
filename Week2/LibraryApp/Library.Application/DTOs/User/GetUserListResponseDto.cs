using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.User;

public record GetUserListResponseDto
(
    Guid Id,
    string UserName,
    string Email,
    string PhoneNumber
);
