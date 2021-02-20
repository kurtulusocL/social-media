﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SocialMedia.Data.Data;
using SocialMedia.Data.Identity;
using SocialMedia.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            ApplicationUser user = userManager.Find(model.Username, model.Password);
            if (user != null)
            {
                if (user.IsConfirmed == true)
                {
                    var username = user.UserName;
                    Session["KullanıcıAdıSoyadı"] = user.NameLastname;
                    Session["Kullanıcı"] = username;
                    Session["adminId"] = user.Id;

                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps, identity);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["confirm"] = "Hesabınız geçici olarak askıya alınmıştır. Bunun bir yanlışlıktan kaynaklandığını düşünüyorsanız lütfen bize bildirmekten çekinmeyin.";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["msg"] = "Kullanıcı adı ve şifreniz yanlış. Lütfen tekrar deneyiniz.";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = model.Username;
                user.NameLastname = model.NameSurname;
                user.Email = model.Email;
                user.Birthdate = Convert.ToDateTime(model.Birthdate);
                user.City = model.City;
                user.Country = model.Country;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;
                user.CreatedDate = model.CreatedDate.ToLocalTime();
                user.Province = model.Province;
                user.RespondTitle = model.RespondTitle;

                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Admin ekleme işleminiz başarısız oldu. Lütfen tekrar deneyiniz";
                    return RedirectToAction("Register");
                }
            }
            return View(model);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult RegisterHelper()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterHelper(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = model.Username;
                user.NameLastname = model.NameSurname;
                user.Email = model.Email;
                user.Birthdate = Convert.ToDateTime(model.Birthdate);
                user.City = model.City;
                user.Country = model.Country;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;
                user.Province = model.Province;
                user.RespondTitle = model.RespondTitle;
                user.CreatedDate = model.CreatedDate.ToLocalTime();

                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Helper");
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Admin ekleme işleminiz başarısız oldu. Lütfen tekrar deneyiniz";
                    return RedirectToAction("RegisterHelper");
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RegisterAsistant()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAsistant(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = model.Username;
                user.NameLastname = model.NameSurname;
                user.Email = model.Email;
                user.Birthdate = model.Birthdate;
                user.City = model.City;
                user.Country = model.Country;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;
                user.Province = model.Province;
                user.RespondTitle = model.RespondTitle;

                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Asistant");
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Admin ekleme işleminiz başarısız oldu. Lütfen tekrar deneyiniz";
                    return RedirectToAction("RegisterAsistant");
                }
            }
            return View(model);
        }

        //[Authorize(Roles = "Admin,Helper,Asistant")]
        public ActionResult ChangeProfile()
        {
            ApplicationUser user = userManager.FindByName(HttpContext.User.Identity.Name);
            ChangeProfile model = new ChangeProfile();
            model.NameSurname = user.NameLastname;
            model.Birthdate = Convert.ToDateTime(user.Birthdate);
            model.RespondTitle = user.RespondTitle;
            model.Country = user.Country;
            model.Province = user.Province;
            model.City = user.City;
            model.PhoneNumber = user.PhoneNumber;
            model.Email = user.Email;
            model.UpdatedDate = user.UpdatedDate;
            model.IsConfirm = user.IsConfirmed;

            return View(model);
        }

        //[Authorize(Roles = "Admin,Helper,Asistant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(ChangeProfile model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.FindByName(HttpContext.User.Identity.Name);
                user.NameLastname = model.NameSurname;
                user.Birthdate = model.Birthdate;
                user.RespondTitle = model.RespondTitle;
                user.Country = model.Country;
                user.Province = model.Province;
                user.City = model.City;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UpdatedDate = model.UpdatedDate;
                user.IsConfirmed = model.IsConfirm;

                IdentityResult result = userManager.Update(user);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Profil bilgileri değiştirildi.";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["msg"] = "Profil bilgileri güncellenirken hata meydana geldi.";
                }
            }
            return View(model);
        }

        //[Authorize(Roles = "Admin,Helper,Asistant")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //[Authorize(Roles = "Admin,Helper,Asistant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userManager.FindByName(HttpContext.User.Identity.Name);
                IdentityResult result = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Şifre değiştirilirken hata meydana geldi. Lütfen işleminizi kontrol edip yeniden deneyiniz.";
                }
            }
            return View(model);
        }
    }
}