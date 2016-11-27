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
    public class VoyageController : Controller
    {
        private InscriptionBL context;

        public VoyageController()
        {
            context = new InscriptionBL();
        }

        public ActionResult AddVoyage()
        {
            var model = new AddVoyageVM();

            model.TravelDate = DateTime.Now.Date;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVoyage(AddVoyageVM model)
        {
            List<Voyage> voyageList = new List<Voyage>();

            try
            {
                if (model.TrainNumber == 0)
                {
                    voyageList = context.FindTravelsByTrainStations(model.StartTrainStation, model.EndTrainStation, model.TravelDate);
                }
                else
                {
                    voyageList = context.FindTravelsByNumTrain(model.TravelDate, model.TrainNumber);
                }

                TempData["voyageList"] = voyageList;

                return RedirectToAction("GetTrainList", new
                {
                    pDate = model.TravelDate,
                    //pDepart = model.StartTrainStation,
                    //pArrivee = model.EndTrainStation
                    pDepart = "Dijon",
                    pArrivee = "Lille"
                });
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public ActionResult GetTrainList(DateTime pDate, string pDepart, string pArrivee, List<Voyage> pTrainList)
        {
            var model = new GetTrainListVM();

            model.VoyageFoundList = TempData["voyageList"] as List<Voyage>;
            model.StartTrainStation = pDepart;
            model.EndTrainStation = pArrivee;
            model.TravelDate = pDate;

            TempData["voyageList2"] = model.VoyageFoundList;

            return View(model);
        }

        public ActionResult Inscription(int id)
        {
            List<Voyage> listV = TempData["voyageList2"] as List<Voyage>;

            Voyage v = listV.FirstOrDefault(qsd => qsd.numeroTrain == id);

            context.InscriptionToTrain(
                Convert.ToInt32(Request.Cookies["Hackathon"]["IdUser"]), v.idVoyage, false, false, 0);

            //TODO Change
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(int id)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
