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
        private UserBL context;

        public AuthentificationController()
        {
            context = new UserBL();
        }

        public ActionResult LogIn()
        {
            var model = new UserLogInVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(UserLogInVM model)
        {
            Utilisateur user = context.LogIn(model.Login, model.Password);

            if (user != null)
            {
                Response.Cookies["Hackathon"]["IdUser"] = user.idUtilisateur.ToString();
                Response.Cookies["Hackathon"]["Name"] = user.Profil.prenom;
                Response.Cookies["Hackathon"].Expires = DateTime.UtcNow.AddDays(14);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            Response.Cookies["Hackathon"].Expires = DateTime.UtcNow.AddDays(-1);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            var model = new UserRegisterVM();
            model.dateDeNaissance = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterVM model)
        {
            var result = this.context.Register(model.adresseMail, model.motDePasse, model.prenom, model.nom, model.dateDeNaissance); 

            if (result)
            {
                return RedirectToAction("LogIn", "Authentification");
            }

            return View(model);
        }

        public ActionResult EditProfil()
        {
            var model = new UserEditProfilVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfil(UserEditProfilVM model)
        {
            var result = context.EditProfil(model.adresseMail, model.motDePasse, model.prenom, model.nom, model.dateDeNaissance, model.fonction,
                                            model.entreprise, model.descriptionPro, model.descriptionLoisir, model.actifLoisir, model.actifPro);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}