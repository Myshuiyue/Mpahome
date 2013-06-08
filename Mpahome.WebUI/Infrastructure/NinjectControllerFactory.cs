using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using Mpahome.Domain.Abstract;
using Mpahome.Domain.Entities;
using Mpahome.Domain.Concrete;
using System.Web.Routing;

namespace Mpahome.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Mock<IBlogsRepository> mock = new Mock<IBlogsRepository>();
            ninjectKernel.Bind<IBlogsRepository>().To<EFBlogRepository>();
            //put bindings here
        }
    }
}