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
    public class AnnounceController : Controller
    {
        private AnnounceBL announceBL;
        private CategorieBL categoryBL;
        public AnnounceController()
        {
            announceBL = new AnnounceBL();
            categoryBL = new CategorieBL();
        }

        // GET: Announce
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAnnounce()
        {
            AnnounceVM announceVM = new AnnounceVM();
            announceVM.lesCategories = categoryBL.GetAllCategories();
            return View(announceVM);
        }

        public ActionResult GetAllAnnounces(int id = 1)
        {
            return View(announceBL.GetAllAnnounces(id));
        }

        [HttpPost]
        public ActionResult AddAnnounce(AnnounceVM pAnnounce)
        {
            try
            {
                if (Request.Cookies["Hackathon"] != null)
                {
                    pAnnounce.idUtilisateur =  Convert.ToInt32(Request.Cookies["Hackathon"]["IdUser"]);
                    Annonce newAnnounce = new Annonce()
                    {
                        description = pAnnounce.description,
                        estActive = true,
                        idAnnonce = Convert.ToInt16(pAnnounce.idAnnonce),
                        idCategorie = pAnnounce.idCategorie,
                        idUtilisateur = pAnnounce.idUtilisateur,
                        nbSlot = pAnnounce.nbSlot,
                        nbSlotUtilise = 1,
                        titre = pAnnounce.titre
                    };


                    if (announceBL.AddAnnounce(newAnnounce))
                    {
                        return RedirectToAction("GetAllAnnounces", "Announce");
                    }
                    else
                    {
                        return View(pAnnounce);
                    }
                }
                else
                {
                    return View(pAnnounce);
                }
            }
            catch (Exception)
            {
                return View(pAnnounce);
            }
        }

        [HttpPost]
        public ActionResult DeleteAnnounce(int id)
        {
            try
            {
                if (announceBL.DeleteAnnounce(id))
                {
                    return RedirectToAction("GetAllAnnounces", "Announce");
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditAnnounce(int id)
        {
            Annonce announceToUpdate = announceBL.GetAnnounce(id);
            if (announceToUpdate != null)
            {
                AnnounceVM annonceVM = new AnnounceVM()
                {
                    description = announceToUpdate.description,
                    estActive = announceToUpdate.estActive,
                    idAnnonce = announceToUpdate.idAnnonce,
                    idCategorie = announceToUpdate.idCategorie,
                    idUtilisateur = announceToUpdate.idUtilisateur,
                    nbSlot = announceToUpdate.nbSlot,
                    nbSlotUtilise = announceToUpdate.nbSlotUtilise,
                    titre = announceToUpdate.titre
                };

                annonceVM.lesCategories = categoryBL.GetAllCategories();
                return View(annonceVM);
            }
            else
            {
                return RedirectToAction("GetAllAnnounces", "Announce");
            }


        }

        [HttpPost]
        public ActionResult EditAnnounce(AnnounceVM pAnnounce)
        {
            try
            {
                Annonce newAnnounce = new Annonce()
                {
                    description = pAnnounce.description,
                    estActive = pAnnounce.estActive,
                    idAnnonce = Convert.ToInt16(pAnnounce.idAnnonce),
                    idCategorie = pAnnounce.idCategorie,
                    idUtilisateur = pAnnounce.idUtilisateur,
                    nbSlot = pAnnounce.nbSlot,
                    nbSlotUtilise = pAnnounce.nbSlotUtilise,
                    titre = pAnnounce.titre
                };
                if (announceBL.EditAnnounce(newAnnounce))
                {
                    return RedirectToAction("GetAllAnnounces", "Announce");
                }
                else
                {
                    return View(pAnnounce);
                }
            }
            catch (Exception)
            {
                return View(pAnnounce);
            }
        }

        public ActionResult GetAnnouncesTrain()
        {
            return View(announceBL.GetTrainAnnounces(1002).ToList());
        }
    }
}