using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllUser()
        {
            ViewBag.AktifKullanici = HttpContext.Application["AktifKullanici"];
            ViewBag.ToplamZiyaretci = HttpContext.Application["ToplamZiyaretci"];
            return View();
        }
        [Authorize(Roles = "Admin,Helper,Asistant")]
        public ActionResult AdminList()
        {
            return View(/*_userService.GetAll().Where(i => i.IsConfirmed == true && i.RespondTitle == "Admin" || i.RespondTitle == "Yardımcı Admin" || i.RespondTitle == "Asistan Admin").OrderByDescending(i => i.CreatedDate).ToList()*/);
        }

        public ActionResult AllAdminList()
        {
            return View(/*_userService.GetAll().Where(i => i.RespondTitle == "Admin" || i.RespondTitle == "Yardımcı Admin" || i.RespondTitle == "Asistan Admin").OrderByDescending(i => i.CreatedDate).ToList()*/);
        }

        public ActionResult AdminDetail(string id)
        {
            return View(/*_userService.GetById(id)*/);
        }

        public ActionResult UserList(int page = 1)
        {
            return View(/*_userService.GetAll().Where(i => i.IsConfirmed == true && i.RespondTitle == null).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 30)*/);
        }

        public ActionResult AllUserList(int page = 1)
        {
            return View(/*_userService.GetAll().Where(i => i.RespondTitle == null).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 30)*/);
        }

        public ActionResult UserDetail(string id)
        {
            return View(/*_userService.GetById(id)*/);
        }
        public ActionResult _Navbar()
        {
            return PartialView();
        }

        public ActionResult _Header()
        {
            return PartialView();
        }

        public ActionResult _Footer()
        {
            return PartialView();
        }

        public ActionResult SetCookie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetCookie(string CookieName, string CookieValue)
        {
            HttpCookie ck = new HttpCookie(CookieName);
            ck.Value = CookieValue;
            ck.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(ck);
            return View();
        }

        public ActionResult ReadCookie()
        {
            string deger = Request.Cookies["ocL"].Value;
            ViewBag.Cerez = deger;
            return View();
        }
        public ActionResult DeleteCookie(string name)
        {
            Response.Cookies.Remove(name);
            Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction(nameof(ReadCookie));
        }
    }
}