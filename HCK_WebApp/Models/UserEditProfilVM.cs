using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class UserEditProfilVM
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        public DateTime dateDeNaissance { get; set; }
        public string fonction { get; set; }
        public string entreprise { get; set; }
        [DataType(DataType.MultilineText)]
        public string descriptionPro { get; set; }
        [DataType(DataType.MultilineText)]
        public string descriptionLoisir { get; set; }
        public bool actifLoisir { get; set; }
        public bool actifPro { get; set; }
        public string motDePasse { get; set; }
        public string adresseMail { get; set; }
    }
}