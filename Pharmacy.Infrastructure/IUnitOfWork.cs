namespace Pharmacy.Infrastructure
{
    /// <summary>
    /// Interface of Unit of work
    /// Like save changes to db etc.
    /// Author: Asif Iqbal
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Interface of Unit of work
        /// Like save changes to db etc.
        /// Author: Asif Iqbal
        /// </summary>
        int Commit();
    }
}
