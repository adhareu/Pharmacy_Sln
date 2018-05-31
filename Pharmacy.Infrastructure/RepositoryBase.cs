using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;

namespace Pharmacy.Infrastructure
{
    /// <summary>
    /// base repository
    /// Abstraction of query construction
    /// Author: Asif Iqbal
    /// </summary>
    public  class RepositoryBase<T> where T : class
    {
        private DbContext dataContext;
        private readonly IDbSet<T> dbset;


        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();

        }
       
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        /// <summary>
        /// Add Data in Database
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dataContext.Configuration.AutoDetectChangesEnabled = false;
            dataContext.Configuration.ValidateOnSaveEnabled = false;

            dbset.Add(entity);
        }

        /// <summary>
        /// Update Data in Database
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            dataContext.Configuration.AutoDetectChangesEnabled = false;
            dataContext.Configuration.ValidateOnSaveEnabled = false;
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete Data from Database
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dataContext.Configuration.AutoDetectChangesEnabled = false;
            dataContext.Configuration.ValidateOnSaveEnabled = false;
            dbset.Remove(entity);
        }
        /// <summary>
        /// Delete data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            dataContext.Configuration.AutoDetectChangesEnabled = false;
            dataContext.Configuration.ValidateOnSaveEnabled = false;
            IEnumerable<T> objects = dbset.Where(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual IEnumerable<T> CompiledQuery(Expression<Func<T, bool>> where)
        {
            return CompiledQuery(where).ToList();
        }
        public virtual void Query(string query)
        {

            dataContext.Database.ExecuteSqlCommand(query);
        }
        /// <summary>
        /// Get Data using int id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetDataById(int id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// Get Data using long id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetDataById(long id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// Get Data using string Id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetDataById(string id)
        {
            return dbset.Find(id);
        }

        /// <summary>
        /// Get All Data from Database
        /// Author: Asif Iqbal
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {

            //return null;
            return dbset.ToList();
        }

        /// <summary>
        /// Get Multiple Data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {

            return dbset.Where(where).ToList();
        }

        /// <summary>
        /// Get Single data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }



        /// <summary>
        /// Get All Data from Database
        /// Author: Asif Iqbal
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> ReadAll()
        {

            //return null;
            return dbset.AsNoTracking().ToList();
        }

        /// <summary>
        /// Get Multiple Data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> ReadMany(Expression<Func<T, bool>> where)
        {

            return dbset.AsNoTracking().Where(where).ToList();
        }

        /// <summary>
        /// Get Single data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Read(Expression<Func<T, bool>> where)
        {
            return dbset.AsNoTracking().Where(where).FirstOrDefault();
        }
        public IQueryable<T> GetQuery()
        {
            return dbset.AsQueryable();
        }


    }
}

