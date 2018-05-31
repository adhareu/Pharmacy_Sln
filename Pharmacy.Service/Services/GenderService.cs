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
    public class GenderService:IGenderService
    {
        private IGenderRepository repository;
        private IUnitOfWork unitOfWork;
        public GenderService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new GenderRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public GenderService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new GenderRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<Gender> GetAll()
        {
           
            var S_Gender = repository.GetAll().ToList();
           
            return S_Gender;
        }

        public Gender GetById(int id)
        {
            return repository.Get(x=>x.GenderID==id);
        }

        public List<Gender> FindByName(string name)
        {
            return repository.GetMany(e => e.GenderName.Equals(name)).ToList();
        }
        public bool Add(Gender aS_Gender)
        {
            try
            {
                aS_Gender.Status =1;
                aS_Gender.CreatedBy = 1;
                aS_Gender.CreatedOn = DateTime.Now;
                repository.Add(aS_Gender);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Gender aS_Gender)
        {
            try
            {
                aS_Gender.ModifiedBy = 1;
                aS_Gender.ModifiedOn = DateTime.Now;
                repository.Update(aS_Gender);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Gender aS_Gender)
        {
            try
            {

                repository.Update(aS_Gender);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
