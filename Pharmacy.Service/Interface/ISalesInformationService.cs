using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Model;

namespace Pharmacy.Service
{
   public interface ISalesInformationService
    {
        List<SalesInformationView> GetAll();
       SalesInformation GetLastData();
        SalesInformation GetById(int id);
        List<SalesInformation> FindByName(string name);
        bool Add(SalesInformation aS_SalesInformation);
        bool Update(SalesInformation aS_SalesInformation);
        bool Delete(SalesInformation aS_SalesInformation);
    }
}
