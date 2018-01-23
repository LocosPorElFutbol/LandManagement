using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Interface;

namespace LandManagement.Repository
{
    public class CartaRepository : IBaseRepository<tbcarta>
    {
        private static CartaRepository instancia = null;
        private landmanagementbdEntities Contexto = null;

        public static CartaRepository GetInstancia()
        {
            if (instancia == null)
                return new CartaRepository();
            return instancia;
        }

        public CartaRepository()
        {
            this.Contexto = new landmanagementbdEntities();
        }

        public void Create(tbcarta entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbcarta entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbcarta>().EntitySet.Name, entity);
                tbcarta entityAux = null;
                entityAux = (tbcarta)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbcarta>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbcarta entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbcarta entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbcarta>().EntitySet.Name, entity);
            try
            {
                tbcarta salida = (tbcarta)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public object GetList(Func<tbcarta, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
