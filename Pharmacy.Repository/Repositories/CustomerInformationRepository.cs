using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;


namespace Pharmacy.Repository
{
    public interface ICustomerInformationRepository : IRepository<CustomerInformation>
    {
    }
    public class CustomerInformationRepository : RepositoryBase<CustomerInformation>, ICustomerInformationRepository
    {
        public CustomerInformationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        
    }

    public interface ICustomerInformationViewRepository : IRepository<CustomerInformationView>
    {
    }
    public class CustomerInformationViewRepository : RepositoryBase<CustomerInformationView>, ICustomerInformationViewRepository
    {
        public CustomerInformationViewRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

    }
}
