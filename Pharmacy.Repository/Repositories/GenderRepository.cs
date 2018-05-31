using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Infrastructure;
using Pharmacy.Model;


namespace Pharmacy.Repository
{
    public interface IGenderRepository : IRepository<Gender>
    {
    }
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        
    }
}
