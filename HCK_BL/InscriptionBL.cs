using HCK_BL;
using HCK_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCK_BL
{
    public class InscriptionBL
    {
        private BaseDA context;

        public InscriptionBL()
        {
            context = new BaseDA();
        }

        public List<Voyage> FindTravelsByNumTrain(DateTime pDatetravel, int pNumTrain)
        {
            List<Voyage> result = new List<Voyage>();

            try
            {
                result = context.GetAll<Voyage>()
                    .Where(v => v.numeroTrain == pNumTrain && v.date == pDatetravel.Date).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

    }
}
