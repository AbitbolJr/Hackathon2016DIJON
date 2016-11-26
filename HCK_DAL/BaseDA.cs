using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HCK_DAL
{
    public class BaseDA
    {
        private readonly Hackathon16DijonEntities context;
        string errorMessage = string.Empty;

        public BaseDA()
        {
            this.context = new Hackathon16DijonEntities();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return context.Set<T>().AsEnumerable();
        }

        public void AddOrUpdate<T>(T entity, Expression<Func<T, object>> predicat = null) where T : class
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Impossible d'insérer un objet null");
                }

                if (predicat != null) 
                {
                    context.Set<T>().AddOrUpdate(predicat, entity);
                }
                else
                {
                    context.Set<T>().Add(entity);
                }

                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Impossible d'insérer un objet null");
                }

                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }
    }
}