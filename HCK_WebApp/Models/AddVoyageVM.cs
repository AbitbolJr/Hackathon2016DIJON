using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class AddVoyageVM
    {
        public DateTime TravelDate { get; set; }
        public int TrainNumber { get; set; }
        public string StartTrainStation { get; set; }
        public string EndTrainStation { get; set; }
    }
}