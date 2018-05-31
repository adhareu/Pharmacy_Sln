using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Model;

namespace Pharmacy.Service
{
   public interface IUnitTypeService
    {
        List<UnitType> GetAll();
        UnitType GetById(int id);
        List<UnitType> FindByName(string name);
        bool Add(UnitType aS_UnitType);
        bool Update(UnitType aS_UnitType);
        bool Delete(UnitType aS_UnitType);
    }
}
