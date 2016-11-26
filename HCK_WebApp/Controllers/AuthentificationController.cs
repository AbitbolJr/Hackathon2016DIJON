using HCK_BL;
using HCK_DAL;
using HCK_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCK_WebApp.Controllers
{
    public class AuthentificationController : Controller
    {
        private BaseDA context;

        public AuthentificationController()
        {
            context = new BaseDA();
        }

        public ActionResult LogIn()
        {
            var model = new UserLogInVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(UserLogInVM model)
        {
            //var user = context.LogIn(model.Login, model.Password, context);

            //if (user != null)
            //{
            //    Response.Cookies["Miniblog2"]["IdUser"] = user.IdUser.ToString();
            //    Response.Cookies["Miniblog2"]["Token"] = user.Token;
            //    Response.Cookies["Miniblog2"]["Name"] = user.DisplayName;
            //    Response.Cookies["Miniblog2"].Expires = DateTime.UtcNow.AddDays(14);

            //    return RedirectToAction("Index", "Post");
            //}
            //model.Errors = context.Errors;

            return View(model);
        }

        public ActionResult LogOut()
        {

            Response.Cookies["Miniblog2"].Expires = DateTime.UtcNow.AddDays(-1);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterVM model)
        {
            //var result = this.context.Register(model.User, context);

            //if (result)
            //{
            //    return RedirectToAction("Login", "Account");
            //}

            //model.Errors = context.Errors;

            return View(model);
        }
    }
}