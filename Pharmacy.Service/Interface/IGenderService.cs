using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Model;

namespace Pharmacy.Service
{
   public interface IGenderService
    {
        List<Gender> GetAll();
        Gender GetById(int id);
        List<Gender> FindByName(string name);
        bool Add(Gender aS_Gender);
        bool Update(Gender aS_Gender);
        bool Delete(Gender aS_Gender);
    }
}
