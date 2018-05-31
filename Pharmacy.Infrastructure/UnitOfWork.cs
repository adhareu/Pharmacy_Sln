using System.Data.Entity;

namespace Pharmacy.Infrastructure
{
    /// <summary>
    /// Implementation of Unit of work
    /// Like save changes to db etc.
    /// Author: Asif Iqbal
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private DbContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected DbContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public int Commit()
        {
           return DataContext.SaveChanges();
        }
    }
}
