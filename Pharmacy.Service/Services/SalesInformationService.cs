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
    public class SalesInformationService:ISalesInformationService
    {
        private ISalesInformationRepository repository;
        private ISalesInformationViewRepository repositoryview;
        private IUnitOfWork unitOfWork;
        public SalesInformationService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new SalesInformationRepository(objDatabaseFactory);
            repositoryview = new SalesInformationViewRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public SalesInformationService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new SalesInformationRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<SalesInformationView> GetAll()
        {
           
            var S_SalesInformation = repositoryview.GetAll().ToList();
           
            return S_SalesInformation;
        }
        public SalesInformation GetLastData()
        {

            var S_SalesInformation = repository.GetAll().LastOrDefault();

            return S_SalesInformation;
        }
        public SalesInformation GetById(int id)
        {
            return repository.Get(x=>x.SalesID==id);
        }

        public List<SalesInformation> FindByName(string name)
        {
            return repository.GetMany(e => e.SalesName.Equals(name)).ToList();
        }
        public bool Add(SalesInformation aS_SalesInformation)
        {
            try
            {
                aS_SalesInformation.Status =1;
                repository.Add(aS_SalesInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(SalesInformation aS_SalesInformation)
        {
            try
            {
                aS_SalesInformation.ModifiedBy = 1;
                aS_SalesInformation.ModifiedOn = DateTime.Now;
                repository.Update(aS_SalesInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(SalesInformation aS_SalesInformation)
        {
            try
            {

                repository.Update(aS_SalesInformation);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
