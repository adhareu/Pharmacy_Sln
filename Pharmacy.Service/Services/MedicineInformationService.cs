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
    public class MedicineInformationService:IMedicineInformationService
    {
        private IMedicineInformationRepository repository;
        private IMedicineInformationViewRepository repositoryview;
        private IUnitOfWork unitOfWork;
        public MedicineInformationService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new MedicineInformationRepository(objDatabaseFactory);
            repositoryview = new MedicineInformationViewRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public MedicineInformationService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new MedicineInformationRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<MedicineInformationView> GetAll()
        {
           
            var S_MedicineInformation = repositoryview.GetAll().ToList();
           
            return S_MedicineInformation;
        }

        public MedicineInformation GetById(int id)
        {
            return repository.Get(x=>x.MedicineID==id);
        }

        public List<MedicineInformation> FindByName(string name)
        {
            return repository.GetMany(e => e.MedicineName.Equals(name)).ToList();
        }
        public bool Add(MedicineInformation aS_MedicineInformation)
        {
            try
            {
                aS_MedicineInformation.Status =1;
                aS_MedicineInformation.CreatedBy = 1;
                aS_MedicineInformation.CreatedOn = DateTime.Now;
                repository.Add(aS_MedicineInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(MedicineInformation aS_MedicineInformation)
        {
            try
            {
                aS_MedicineInformation.ModifiedBy = 1;
                aS_MedicineInformation.ModifiedOn = DateTime.Now;
                repository.Update(aS_MedicineInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(MedicineInformation aS_MedicineInformation)
        {
            try
            {

                repository.Update(aS_MedicineInformation);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
