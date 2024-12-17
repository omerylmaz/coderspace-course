using Library.Application.Abstractions.Services;
using Library.Application.DTOs.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers;

public class RoleController(IRoleService roleService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        Application.Result.Result<List<GetRoleListDto>> result = await roleService.GetAllRolesAsync(cancellationToken);

        if (result.IsSuccess)
        {
            return View(result.Value);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View("NotFound");
    }

    [Authorize(Roles = "admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create(CreateRoleDto roleDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(roleDto);
        }

        var result = await roleService.CreateRoleAsync(roleDto, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        var result = await roleService.GetRoleByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            return View(result.Value);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var result = await roleService.GetRoleByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            return View(result.Value);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateRoleDto roleDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(roleDto);
        }

        var result = await roleService.UpdateRoleAsync(roleDto, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var result = await roleService.DeleteRoleAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> AssignRoleToUser(Guid userId, List<AssignRoleToUserDto> assignRoleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.AssignRoleToUserAsync(userId, assignRoleDto, cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred";
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> RemoveRoleFromUser(AssignRoleDto assignRoleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.RemoveRoleFromUserAsync(assignRoleDto, cancellationToken);
        return result.IsSuccess ? RedirectToAction(nameof(Index)) : BadRequest(result.ProblemDetails?.Detail);
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AssignRoleToUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await roleService.GetUserRolesAsync(id, cancellationToken);
        if (result.IsSuccess)
        {
            ViewBag.UserId = id;
            return View(result.Value);
        }

        TempData["Error"] = result.ProblemDetails?.Detail ?? "An error occurred.";
        return View(result.Value);
    }

    public IActionResult AccessDenied(string ReturnUrl)
    {
        string message = "You have no permission for this page. Please contact with your admin";

        ViewBag.message = message;
        return View();
    }
}
