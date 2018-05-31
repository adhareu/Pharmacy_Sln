using System.Data.Entity;
using Pharmacy.Infrastructure;

namespace Pharmacy.Model
{
    /// <summary>
    /// Database Factory
    /// Manage Db Context
    /// Author: Asif Iqbal
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContext dataContext;
        public DbContext Get()
        {
            return dataContext ?? (dataContext = new Pharmacy_DBEntities());
        }
       
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
