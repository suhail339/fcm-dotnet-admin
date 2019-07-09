using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace notificationtest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string configFilePath = System.Configuration.ConfigurationManager.AppSettings["ConfigFilePath"].ToString();
        string env_variable = System.Configuration.ConfigurationManager.AppSettings["GoogleEnvVariable"].ToString();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Environment.SetEnvironmentVariable(env_variable, configFilePath);
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(configFilePath),
            });
        }
    }
}
