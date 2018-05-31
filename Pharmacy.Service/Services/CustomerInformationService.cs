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
    public class CustomerInformationService:ICustomerInformationService
    {
        private ICustomerInformationRepository repository;
        private ICustomerInformationViewRepository repositoryview;
        private IUnitOfWork unitOfWork;
        public CustomerInformationService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new CustomerInformationRepository(objDatabaseFactory);
            repositoryview = new CustomerInformationViewRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public CustomerInformationService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new CustomerInformationRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<CustomerInformationView> GetAll()
        {
           
            var S_CustomerInformation = repositoryview.GetAll().ToList();
           
            return S_CustomerInformation;
        }

        public CustomerInformation GetById(int id)
        {
            return repository.Get(x=>x.CustomerID==id);
        }

        public List<CustomerInformation> FindByName(string name)
        {
            return repository.GetMany(e => e.CustomerName.Equals(name)).ToList();
        }
        public bool Add(CustomerInformation aS_CustomerInformation)
        {
            try
            {
                aS_CustomerInformation.Status =1;
                aS_CustomerInformation.CreatedBy = 1;
                aS_CustomerInformation.CreatedOn = DateTime.Now;
                repository.Add(aS_CustomerInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(CustomerInformation aS_CustomerInformation)
        {
            try
            {
                aS_CustomerInformation.ModifiedBy = 1;
                aS_CustomerInformation.ModifiedOn = DateTime.Now;
                repository.Update(aS_CustomerInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(CustomerInformation aS_CustomerInformation)
        {
            try
            {

                repository.Update(aS_CustomerInformation);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
