using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Model;

namespace Pharmacy.Service
{
   public interface IMedicineInformationService
    {
        List<MedicineInformationView> GetAll();
        MedicineInformation GetById(int id);
        List<MedicineInformation> FindByName(string name);
       
        bool Add(MedicineInformation aS_MedicineInformation);
        bool Update(MedicineInformation aS_MedicineInformation);
        bool Delete(MedicineInformation aS_MedicineInformation);
    }
}
