using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Model;

namespace Pharmacy.Service
{
   public interface ICustomerInformationService
    {
        List<CustomerInformationView> GetAll();
        CustomerInformation GetById(int id);
        List<CustomerInformation> FindByName(string name);
       
        bool Add(CustomerInformation aS_CustomerInformation);
        bool Update(CustomerInformation aS_CustomerInformation);
        bool Delete(CustomerInformation aS_CustomerInformation);
    }
}
