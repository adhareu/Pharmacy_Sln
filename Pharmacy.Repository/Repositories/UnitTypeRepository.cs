using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;


namespace Pharmacy.Repository
{
    public interface IUnitTypeRepository : IRepository<UnitType>
    {
    }
    public class UnitTypeRepository : RepositoryBase<UnitType>, IUnitTypeRepository
    {
        public UnitTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        
    }
}
