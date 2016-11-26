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

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVoyage(AddVoyageVM model)
        {
            List<Voyage> voyageList = new List<Voyage>();

            try
            {
                if (model.TravelDate == null)
                {
                    var result = context.FindTravelsByNumTrain(model.TravelDate, model.TrainNumber);
                }
                else
                {
                    var result = context.FindTravelsByNumTrain(model.TravelDate, model.TrainNumber);
                }

                return RedirectToAction("GetTrainList", "Voyage");
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public ActionResult GetTrainList()
        {
            var model = new GetTrainListVM();

            return View(model);
        }

        //[HttpPost]
        //public ActionResult GetTrainList(GetTrainListVM model)
        //{

        //}
    }
}