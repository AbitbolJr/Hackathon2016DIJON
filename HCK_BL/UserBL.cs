using HCK_BL;
using HCK_DAL;
using HCK_TOOLS;
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

        public Utilisateur LogIn(string pLogin, string pPassword)
        {
            Utilisateur user = new Utilisateur();

            try
            {
                user = context.GetAll<Utilisateur>()
                    .Where(u => u.adresseMail == pLogin && u.motDePasse == pPassword)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }

            return user;
        }

        public bool Register(string pLogin, string pPassword, string pPrenom, string pNom, string pDateNaissance)
        {
            try
            {
                if (String.IsNullOrEmpty(pPrenom))
                {
                    throw new Exception("Veuillez renseigner un prénom");
                }

                if (String.IsNullOrEmpty(pDateNaissance))
                {
                    throw new Exception("Veuillez renseigner une date de naissance");
                }

                context.AddOrUpdate(new Profil()
                {
                    prenom = pPrenom,
                    nom = pNom,
                    dateDeNaissance = pDateNaissance
                }, p => p.idProfil);

                context.AddOrUpdate(new Utilisateur()
                {
                    motDePasse = pPassword,
                    adresseMail = pLogin,
                    idProfil = context.GetAll<Profil>().Max(p => p.idProfil)
                });
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return false;
            }

            return true;
        }

        public bool EditProfil(string pLogin, string pPassword, string pPrenom, string pNom, string pDateNaissance, string pFonction, string pEntreprise,
            string pDescriptionPro, string pDescriptionLoisir, bool pActifLoisir, bool pActifPro)
        {
            try
            {
                if (String.IsNullOrEmpty(pPrenom))
                {
                    throw new Exception("Veuillez renseigner un prénom");
                }

                if (String.IsNullOrEmpty(pDateNaissance))
                {
                    throw new Exception("Veuillez renseigner une date de naissance");
                }

                if (pActifPro)
                {
                    if (String.IsNullOrEmpty(pFonction))
                    {
                        throw new Exception("Veuillez renseigner une fonction");
                    }

                    if (String.IsNullOrEmpty(pEntreprise))
                    {
                        throw new Exception("Veuillez renseigner une entreprise");
                    }
                }

                context.AddOrUpdate(new Profil()
                {
                    prenom = pPrenom,
                    nom = pNom,
                    dateDeNaissance = pDateNaissance,
                    actifLoisir = pActifLoisir,
                    actifPro = pActifPro,
                    descriptionLoisir = pDescriptionLoisir,
                    descriptionPro = pDescriptionPro,
                    entreprise = pEntreprise,
                    fonction = pFonction,
                }, p => p.idProfil);

                context.AddOrUpdate(new Utilisateur()
                {
                    motDePasse = pPassword,
                    adresseMail = pLogin,
                    idProfil = context.GetAll<Profil>().Max(p => p.idProfil)
                });
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return false;
            }

            return true;
        }
    }
}