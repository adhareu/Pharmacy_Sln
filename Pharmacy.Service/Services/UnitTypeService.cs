using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;

using Pharmacy.Repository;


namespace Pharmacy.Service
{
    public class UnitTypeService:IUnitTypeService
    {
        private IUnitTypeRepository repository;
        private IUnitOfWork unitOfWork;
        public UnitTypeService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new UnitTypeRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public UnitTypeService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new UnitTypeRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<UnitType> GetAll()
        {
           
            var S_UnitType = repository.GetAll().ToList();
           
            return S_UnitType;
        }

        public UnitType GetById(int id)
        {
            return repository.Get(x=>x.UnitTypeID==id);
        }

        public List<UnitType> FindByName(string name)
        {
            return repository.GetMany(e => e.UnitTypeName.Equals(name)).ToList();
        }
        public bool Add(UnitType aS_UnitType)
        {
            try
            {
                aS_UnitType.Status =1;
                aS_UnitType.CreatedBy = 1;
                aS_UnitType.CreatedOn = DateTime.Now;
                repository.Add(aS_UnitType);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(UnitType aS_UnitType)
        {
            try
            {
                aS_UnitType.ModifiedBy = 1;
                aS_UnitType.ModifiedOn = DateTime.Now;
                repository.Update(aS_UnitType);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(UnitType aS_UnitType)
        {
            try
            {

                repository.Update(aS_UnitType);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
