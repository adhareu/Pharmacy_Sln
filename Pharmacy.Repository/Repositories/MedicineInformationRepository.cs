using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;


namespace Pharmacy.Repository
{
    public interface IMedicineInformationRepository : IRepository<MedicineInformation>
    {
    }
    public class MedicineInformationRepository : RepositoryBase<MedicineInformation>, IMedicineInformationRepository
    {
        public MedicineInformationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        
    }

    public interface IMedicineInformationViewRepository : IRepository<MedicineInformationView>
    {
    }
    public class MedicineInformationViewRepository : RepositoryBase<MedicineInformationView>, IMedicineInformationViewRepository
    {
        public MedicineInformationViewRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

    }
}
