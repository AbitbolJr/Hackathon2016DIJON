using HCK_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class GetTrainListVM
    {
        public DateTime TravelDate { get; set; }
        public string StartTrainStation { get; set; }
        public string EndTrainStation { get; set; }
        public List<Voyage> VoyageFoundList { get; set; }

        public GetTrainListVM()
        {
            VoyageFoundList = new List<Voyage>();
        }
    }
}