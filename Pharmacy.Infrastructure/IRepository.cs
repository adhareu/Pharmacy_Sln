using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pharmacy.Infrastructure
{
    /// <summary>
    /// Interface of base repository
    /// Abstraction of query construction
    /// Author: Asif Iqbal
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add Object in Entity
        /// Author:Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update Object in Entity
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete Object from Entity
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// Delete using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Delete using Sql Query
        /// </summary>
        /// <param name="query"></param>
        void Query(string query);

        IEnumerable<T> CompiledQuery(Expression<Func<T, bool>> where);
        /// <summary>
        /// Get Object by int Id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetDataById(int id);

        /// <summary>
        /// Get Objet by Long Id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetDataById(long id);

        /// <summary>
        /// Get Object byt string id
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetDataById(string id);

        /// <summary>
        /// Get object using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> where);
        /// <summary>
        /// Get All Data
        /// Author: Asif Iqbal
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get Multiple data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);




        /// <summary>
        /// Get object using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Read(Expression<Func<T, bool>> where);
        /// <summary>
        /// Get All Data
        /// Author: Asif Iqbal
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Get Multiple data using Expression
        /// Author: Asif Iqbal
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> ReadMany(Expression<Func<T, bool>> where);

        IQueryable<T> GetQuery();

    }   
}
