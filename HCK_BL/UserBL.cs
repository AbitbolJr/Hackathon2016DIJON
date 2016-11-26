using HCK_BL;
using HCK_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCK_BL
{
    public class UserBL
    {
        private BaseDA context;

        public UserBL()
        {
            context = new BaseDA();
        }

        public bool LogIn(string pLogin, string pPassword)
        {
            bool result = false;

            try
            {
                Utilisateur user = context.GetAll<Utilisateur>()
                    .Where(u => u.MAIL == pLogin && u.PASSWORD == pPassword)
                    .FirstOrDefault();

                if (user != null)
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool Register(string pMail, string pPassword)
        {
            if (true)
            {

            }

            return false;
        }
    }
}
