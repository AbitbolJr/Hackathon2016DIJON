using HCK_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCK_BL
{
    public class CategorieBL
    {
        private BaseDA baseDA;
        public CategorieBL()
        {
            baseDA = new BaseDA();
        }

        public List<Categorie> GetAllCategories()
        {
            List<Categorie> allCategories = new List<Categorie>();
            try
            {
                allCategories = baseDA.GetAll<Categorie>().ToList();
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
            }
            return allCategories;
        }
    }
}
