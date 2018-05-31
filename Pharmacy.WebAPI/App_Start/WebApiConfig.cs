using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Pharmacy.Service;
using Microsoft.Practices.Unity;
using Pharmacy.WebAPI.DI;
using System.Web.Http.Cors;

namespace Pharmacy.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            UnityContainer container = new UnityContainer();
            container.RegisterType<IUnitTypeService, UnitTypeService>();
            container.RegisterType<IMedicineInformationService, MedicineInformationService>();
            container.RegisterType<ICustomerInformationService, CustomerInformationService>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterType<ISalesInformationService, SalesInformationService>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
