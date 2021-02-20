using OrderFood.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SocialMedia.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalFilters.Filters.Add(new HandleErrorAttribute());
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
        protected void Session_Start()
        {
            Session.Timeout = 365;
            if (Application["AktifKullanici"] == null)
            {
                int sayac = 1;
                Application["AktifKullanici"] = sayac;
            }
            else
            {
                int sayac = (int)Application["AktifKullanici"];
                sayac++;
                Application["AktifKullanici"] = sayac;
            }

            if (Application["ToplamZiyaretci"] == null)
            {
                int sayac = 1;
                Application["ToplamZiyaretci"] = sayac;
            }
            else
            {
                int sayac = (int)Application["ToplamZiyaretci"];
                sayac++;
                Application["ToplamZiyaretci"] = sayac;
            }

            if (Application["AktifSepet"] == null)
            {
                int sayac = 1;
                Application["AktifSepet"] = sayac;
            }
            else
            {
                int sayac = (int)Application["AktifSepet"];
                sayac++;
                Application["AktifSepet"] = sayac;
            }
        }
        protected void Session_End()
        {
            int sayac = (int)Application["AktifKullanici"];
            sayac--;
            Application["AktifKullanici"] = sayac;
        }
    }
}
