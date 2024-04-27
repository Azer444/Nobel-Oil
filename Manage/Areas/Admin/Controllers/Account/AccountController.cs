using Core;
using Core.Models;
using Manage.Areas.Admin.Models.AccountManagement;
using Manage.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.Account
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(
            SignInManager<User> signInManager,
            IUnitOfWork unitOfWork)
        {
            this._signInManager = signInManager;
            this._unitOfWork = unitOfWork;
        }

        #region Login

        [HttpGet]
        [AnonymousOnly]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousOnly]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var user = await _unitOfWork.Users.FindByUserNameAsync(model.UserName);

            if (ModelState.IsValid && user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("index", "home");

                    else if (Url.IsLocalUrl(returnUrl))
                        return LocalRedirect(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Username or password is incorrect.");

            return View(model);
        }

        #endregion


        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
