using HCK_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class AnnounceVM
    {
        public AnnounceVM()
        {
            lesCategories = new List<Categorie>();
        }
        public int? idAnnonce { get; set; }
        public int? idCategorie { get; set; }
        public string titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public int? nbSlot { get; set; }
        public int? nbSlotUtilise { get; set; }
        public bool? estActive { get; set; }
        public int? idUtilisateur { get; set; }
        public IEnumerable<Categorie>  lesCategories{ get; set; }
    }

}