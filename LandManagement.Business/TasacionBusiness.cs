using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class TasacionBusiness
    {
        private TasacionRepository tasacionRepository;

        public TasacionBusiness()
        {
            tasacionRepository = new TasacionRepository();
        }

        public void Create(tbtasacion tasacion)
        {
            tasacionRepository.Create(tasacion);
        }

        public void Update(tbtasacion tasacion)
        {
            tasacionRepository.Update(tasacion);
        }

        public void Delete(tbtasacion tasacion)
        {
            tasacionRepository.Delete(tasacion);
        }

        public object GetElement(tbtasacion tasacion)
        {
            return tasacionRepository.GetElement(tasacion);
        }

        public object GetElementByKey(tbtasacion tasacion)
        {
            return tasacionRepository.GetElementByKey(tasacion);
        }

        public object GetList()
        {
            return tasacionRepository.GetList();
        }
    }
}
