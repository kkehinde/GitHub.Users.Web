using Autofac;
using Autofac.Integration.Mvc;
using GitHub.Users.HttpClient;
using GitHub.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GitHub.Users.Web
{
    public class DependencyConfig
    {

        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            builder.RegisterType<UserServices>()
                   .As<IUserServices>()
                   .InstancePerRequest();

            builder.RegisterType<UserGitRepos>()
                   .As<IUserGitRepos>()
                   .InstancePerRequest();

            builder.RegisterType<HttpServiceClient>()
                .As<IHttpServiceClient>()
                   .InstancePerRequest();


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}