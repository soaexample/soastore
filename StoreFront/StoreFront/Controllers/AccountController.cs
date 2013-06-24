﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using StoreFront.Models;

namespace StoreFront.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            var users = MembershipService.GetAllUsers();
            return View(users);
        }

        public ActionResult ManageRoles()
        {
            var roles = MembershipService.GetAllRoles();
            return View(roles);
        }

        [HttpPost]
        public ActionResult ManageRoles(string roleName)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("roleName", "Name is required");
            }
            else
            {
                MembershipService.AddRole(roleName);
            }
            return RedirectToAction("ManageRoles");
        }

        public ActionResult EditUser(string username)
        {
            var user = MembershipService.GetUser(username);
            var roles = MembershipService.GetAllRoles();
            var userRoles = MembershipService.GetRolesForUser(user.UserName);

            return View(new EditUserModel(user.UserName, user.Email, roles, userRoles));
        }

        [HttpPost]
        public ActionResult EditUser(EditUserModel model)
        {
            var user = MembershipService.GetUser(model.Username);
            MembershipService.UpdateUser(user, model.UserRoles);
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public ActionResult DeleteRole(string roleName)
        {
            MembershipService.DeleteRole(roleName);
            return RedirectToAction("ManageRoles");
        }
    }
}
