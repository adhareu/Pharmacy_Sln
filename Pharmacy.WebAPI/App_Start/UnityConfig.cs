using Pharmacy.Service;
using Pharmacy.WebAPI.DI;
using Microsoft.Practices.Unity;
using System.Web.Http;



namespace Pharmacy.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IUnitTypeService, UnitTypeService>();
            container.RegisterType<IMedicineInformationService, MedicineInformationService>();
            container.RegisterType<ICustomerInformationService, CustomerInformationService>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterType<ISalesInformationService, SalesInformationService>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}