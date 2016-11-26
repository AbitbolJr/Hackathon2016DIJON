using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCK_WebApp.Models
{
    public class UserLogInVM
    {
        public UserLogInVM()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}