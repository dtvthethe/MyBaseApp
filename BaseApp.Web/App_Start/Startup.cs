using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using System.Reflection;
using BaseApp.Data.Infrastructure;
using BaseApp.Data.Repositories;
using BaseApp.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BaseApp.Data;
using Microsoft.AspNet.Identity;
using BaseApp.Model.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System.Web;

[assembly: OwinStartup(typeof(BaseApp.Web.App_Start.Startup))]

namespace BaseApp.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<BaseAppDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();


            // Repositories
            //builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();

            // Services
            //builder.RegisterAssemblyTypes(typeof(ProductCategoryService).Assembly)
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}
