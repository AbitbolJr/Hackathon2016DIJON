using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class UserRegisterVM
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        public DateTime dateDeNaissance { get; set; }
        public string motDePasse { get; set; }
        public string adresseMail { get; set; }
    }
}