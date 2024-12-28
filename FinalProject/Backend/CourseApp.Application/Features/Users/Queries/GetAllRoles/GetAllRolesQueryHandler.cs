//using AutoMapper;
//using CourseApp.Application.ResultDto;
//using CourseApp.Domain.Entities;
//using MediatR;
//using Microsoft.AspNetCore.Identity;

//namespace CourseApp.Application.Features.Users.Queries.GetAllRoles;

//internal class GetAllRolesQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper) : IRequestHandler<GetAllRolesQuery, Result<GetAllRolesResponse>>
//{
//    public Task<Result<GetAllRolesResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
//    {
//        var roles = roleManager.get
//    }
//}
