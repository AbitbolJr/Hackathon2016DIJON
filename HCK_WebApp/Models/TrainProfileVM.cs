using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class TrainProfileVM
    {
        public TrainProfileVM()
        {

        }

        public string Name { get; set; }
        public string Enterprise { get; set; }
        public string Fonction { get; set; }
        public int Wagon { get; set; }
        public int IdUtilisateur { get; set; }
    }
}