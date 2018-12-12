using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Questionnaire.BLL.Infrastructure;
using Questionnaire.BLL.MappingProfiles;
using Questionnaire.WEB.MappingProfiles;
using Questionnaire.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Questionnaire.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();

            NinjectModule webModule = new WebModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            NinjectModule accountModule = new AccountModule("AccountConnection");
            var kernel = new StandardKernel(webModule, serviceModule, accountModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(x =>
                {
                    x.AllowNullCollections = true;
                    x.AddProfile<BLLMappingProfile>();
                    x.AddProfile<WebMappingProfile>();
                });

                Mapper.Configuration.AssertConfigurationIsValid();
            }
        }
    }
}
