using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class TrainAnnounceVM
    {
        public TrainAnnounceVM()
        {

        }

        public string Theme { get; set; }
        public string Activite { get; set; }
        public string Descriptif { get; set; }
        public string Prenom { get; set; }
        public int NumeroVoiture { get; set; }
        public int NbJoueursManquant { get; set; }
        public int Age { get; set; }
        public int IdVoyage { get; set; }
    }
}