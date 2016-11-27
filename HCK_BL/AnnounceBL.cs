using HCK_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCK_TOOLS;

namespace HCK_BL
{
    public class AnnounceBL
    {
        private BaseDA context;
        public AnnounceBL()
        {
            context = new BaseDA();
        }
        public bool AddAnnounce(Annonce pAnnounce)
        {
            try
            {
                context.AddOrUpdate<Annonce>(pAnnounce);
                return true;
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
                return false;
            }
        }
        public bool EditAnnounce(Annonce pAnnounce)
        {
            try
            {
                context.AddOrUpdate<Annonce>(new Annonce
                {
                    description = pAnnounce.description,
                    estActive = pAnnounce.estActive,
                    idCategorie = pAnnounce.idCategorie,
                    idUtilisateur = pAnnounce.idUtilisateur,
                    nbSlot = pAnnounce.nbSlot,
                    nbSlotUtilise = pAnnounce.nbSlotUtilise,
                    titre = pAnnounce.titre,
                    idAnnonce = pAnnounce.idAnnonce
                }, a => a.idAnnonce);
                return true;
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
                return false;
            }
        }
        public bool DeleteAnnounce(int pIdAnnounce)
        {
            Annonce announceToDelete = null;
            try
            {
                announceToDelete = context.GetAll<Annonce>().Where(a => a.idAnnonce == pIdAnnounce).First();
                if (announceToDelete != null)
                {
                    context.Delete<Annonce>(announceToDelete);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
                return false;
            }
        }
        public List<Annonce> GetAllAnnounces(int pUserId)
        {
            List<Annonce> userAnnounces = new List<Annonce>();
            try
            {
                userAnnounces = context.GetAll<Annonce>().Where(a => a.idUtilisateur == pUserId).ToList();
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
            }
            return userAnnounces;
        }
        public Annonce GetAnnounce(int pAnnounceId)
        {
            Annonce userAnnounce = new Annonce();
            try
            {
                userAnnounce = context.GetAll<Annonce>().ToList().FirstOrDefault(a => a.idAnnonce == pAnnounceId);
            }
            catch (Exception ex)
            {
                HCK_TOOLS.Log.WriteLog(ex);
            }
            return userAnnounce;
        }

        public List<Annonce> GetTrainAnnounces(int pTrainId = 1002)
        {
            Voyage leVoyage = context.GetAll<Voyage>().FirstOrDefault(v => v.numeroTrain == pTrainId);
            List<Inscription> lesInscriptions = context.GetAll<Inscription>().Where(i => i.idVoyage == leVoyage.idVoyage).ToList();
            List<Utilisateur> lesUtilisateurs = context.GetAll<Utilisateur>().Where(u => lesInscriptions.Any(i => i.idUtilisateur == u.idUtilisateur)).ToList();
            return lesUtilisateurs.SelectMany(u => u.Annonces).ToList();
        }
    }
}
