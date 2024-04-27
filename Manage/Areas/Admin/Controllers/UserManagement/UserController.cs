using Core;
using Core.Models;
using Manage.Areas.Admin.Models.UserManagement.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Areas.Admin.Controllers.UserManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitofWork;

        public UserController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        #region List

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var model = new UserListViewModel
            {
                Users = await _unitofWork.Users.GetAll().Select(u => new UserViewModel
                {
                    ID = u.Id,
                    UserName = u.UserName,
                    EmailConfirmed = u.EmailConfirmed,
                    User = u,
                    JoinedAt = u.CreatedAt
                }).ToListAsync()
            };

            return View("List", model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            UserCreateViewModel model = new UserCreateViewModel
            {
                ApplicationRoles = await _unitofWork.Roles.GetAll().ToListAsync(),
            };

            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    EmailConfirmed = model.EmailConfirmed,
                    UserName = model.UserName
                };

                var result = await _unitofWork.Users.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //Add user to selected roles
                    foreach (string roleID in model.ApplicationRolesIDs)
                    {
                        var role = await _unitofWork.Roles.FindByIdAsync(roleID);

                        if (role != null)
                            await _unitofWork.Users.AddToRoleAsync(user, role.Name);
                    }

                    TempData["message"] = $"User <{user.UserName}> successfully created.";
                    TempData["message_type"] = "success";

                    return RedirectToAction("list", "user");
                }

                TempData["message"] = $"User <{user.UserName}> unsuccessfully created.";
                TempData["message_type"] = "danger";
            }

            model.ApplicationRoles = await _unitofWork.Roles.GetAll().ToListAsync();


            return View("Create", model);
        }

        #endregion

        //[HttpGet("isemailunique", Name = ROUTE_NAME)]
        //[HttpPost("isemailunique", Name = ROUTE_NAME)]
        //public async Task<IActionResult> IsEmailUnique(string email)
        //{
        //    var user = _userService.FindByEmailAsync(email);

        //    if (user == null)
        //        return Json(true);
        //    else
        //        return Json(false);

        //}

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _unitofWork.Users.FindByIdAsync(id);
            if (user == null) return NotFound();

            var model = new UserEditViewModel()
            {
                ID = user.Id,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                ApplicationRolesIDs = await _unitofWork.Users.GetUserRolesId(user),
                ApplicationRoles = await _unitofWork.Roles.GetAll().ToListAsync()
            };

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _unitofWork.Users.FindByIdAsync(model.ID);
            if (user == null) return NotFound();

            if (ModelState.IsValid)
            {
                user.UserName = model.UserName;
                user.EmailConfirmed = model.EmailConfirmed;

                //Update user
                var result = await _unitofWork.Users.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Cannot update user");
                    return View(model);
                }

                //Remove all roles
                var user_roles = await _unitofWork.Users.GetRolesAsync(user);
                result = await _unitofWork.Users.RemoveFromRolesAsync(user, user_roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing roles");
                    return View(model);
                }

                //Add new roles
                if (model.ApplicationRolesIDs != null)
                {
                    List<string> new_roleNames = await _unitofWork.Roles.GetAll()
                        .Where(r => model.ApplicationRolesIDs.Contains(r.Id))
                        .Select(r => r.Name).ToListAsync();

                    result = await _unitofWork.Users.AddToRolesAsync(user, new_roleNames);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add roles");
                        return View(model);
                    }
                }

                TempData["message"] = $"User <{user.UserName}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list", "user");
            }


            model.ApplicationRoles = await _unitofWork.Roles.GetAll().ToListAsync();

            return View("Edit", model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _unitofWork.Users.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _unitofWork.Users.DeleteAsync(user);

            if (!result.Succeeded)
            {
                TempData["message"] = $"User <{user.UserName}> deleted unsuccessfully";
                TempData["message_type"] = "danger";
            }

            TempData["message"] = $"User <{user.UserName}> deleted successfully";
            TempData["message_type"] = "success";

            return RedirectToAction("list", "user");
        }

        #endregion

    }
}
