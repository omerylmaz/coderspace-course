using AutoMapper;
using Library.Application.Abstractions.Services;
using Library.Application.DTOs.User;
using Library.Domain.Entities;
using Library.Web.ViewModels.Book;
using Library.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace Library.Web.Controllers;

public class UserController(IUserService userService, IMapper mapper) : Controller
{
    public IActionResult SignIn()

    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInDto model, CancellationToken cancellationToken, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        returnUrl ??= Url.Action("Index", "Home");

        var result = await userService.SignInUserAsync(model, cancellationToken);

        if (result.IsSuccess)
        {
            return Redirect(returnUrl);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during sign-in.";
        return View(model);

    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await userService.GetAllUsersAsync(cancellationToken);

        //var usersVM = mapper.Map<List<GetBookListVM>>(result.Value);
        return result.IsSuccess ? View(result.Value) : NotFound();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignupUserRequestDto user, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var result = await userService.CreateUserAsync(user, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction("Index", "Books");
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during signup";
        return View(user);
    }

    public async Task<IActionResult> Details(string id, CancellationToken cancellationToken)
    {
        var result = await userService.GetUserByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            return View(result.Value);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during signup";
        return View();
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(string id, CancellationToken cancellationToken)
    {
        var result = await userService.GetUserByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            var userResponse = mapper.Map<EditUserVM>(result.Value);
            return View(userResponse);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during process";
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Edit(EditUserDto user, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var result = await userService.UpdateUserAsync(user, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during process";
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteUserAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred during process";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await userService.Logout();
        return RedirectToAction("Index", "Home");
    }
}