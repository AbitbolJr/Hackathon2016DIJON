using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class UserRegisterVM
    {
        public string prenom { get; set; }
        public string nom { get; set; }

        [DisplayName("Date de naissance")]
        public DateTime dateDeNaissance { get; set; }
        public string motDePasse { get; set; }
        public string adresseMail { get; set; }
    }
}