using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class LicenciaRepository : BaseRepository<tbsyslicencia>
    {
        //public static LicenciaRepository instancia = null;
        //private landmanagementbdEntities Contexto = null;

        //public static LicenciaRepository GetInstancia()
        //{
        //    if (instancia == null)
        //        return new LicenciaRepository();
        //    return instancia;
        //}

        //public LicenciaRepository()
        //{
        //    Contexto = new landmanagementbdEntities();
        //}

        //public void Create(tbsyslicencia entity)
        //{
        //    try
        //    {
        //        Contexto.CreateObjectSet<tbsyslicencia>().AddObject(entity);
        //        Contexto.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Update(tbsyslicencia entity)
        //{
        //    try
        //    {
        //        EntityKey key = Contexto.CreateEntityKey(
        //            Contexto.CreateObjectSet<tbsyslicencia>().EntitySet.Name, entity);
        //        tbsyslicencia entityAux = null;
        //        entityAux = (tbsyslicencia)Contexto.GetObjectByKey(key);

        //        Contexto.CreateObjectSet<tbsyslicencia>().ApplyCurrentValues(entity);
        //        Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        Contexto.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override void Delete(tbsyslicencia entity)
        {
            throw new NotImplementedException();
        }

        public override object GetElement(tbsyslicencia entity)
        {
            throw new NotImplementedException();
        }

        public override object GetList()
        {
            throw new NotImplementedException();
        }

        //public object GetList(Func<tbsyslicencia, bool> funcion)
        //{
        //    return Contexto.tbsyslicencia.Where(funcion).ToList<tbsyslicencia>();
        //}
    }
}
