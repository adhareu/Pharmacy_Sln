using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;


namespace Pharmacy.Repository
{
    public interface ISalesInformationRepository : IRepository<SalesInformation>
    {
    }
    public class SalesInformationRepository : RepositoryBase<SalesInformation>, ISalesInformationRepository
    {
        public SalesInformationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        
    }
    public interface ISalesInformationViewRepository : IRepository<SalesInformationView>
    {
    }
    public class SalesInformationViewRepository : RepositoryBase<SalesInformationView>, ISalesInformationViewRepository
    {
        public SalesInformationViewRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

    }
}
