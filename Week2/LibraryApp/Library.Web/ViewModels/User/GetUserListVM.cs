namespace Library.Web.ViewModels.User;

public record GetUserListVM
(
    Guid Id,
    string UserName, 
    string Email,
    string Phone
);
