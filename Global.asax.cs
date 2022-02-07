using MvcModels.Infrastructure;
using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcModels
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Registering a Value Provider Factory
            // ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());

            // Registering a Custom Model Binder
            ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());
        }
    }
}
