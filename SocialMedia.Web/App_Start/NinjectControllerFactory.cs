using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrderFood.Web.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel(new NinjectBindingModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
    public class NinjectBindingModule : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind<IAdRepository>().To<AdRepository>();
            //Kernel.Bind<IAdService>().To<AdService>();
            
        }
    }
}