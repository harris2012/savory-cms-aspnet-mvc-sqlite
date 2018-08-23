using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using SavoryCms.Controllers;
using SavoryCms.Convertor;
using SavoryCms.Repository;
using SavoryCms.Repository.Sqlite;
using SavoryCms.Meta;

namespace SavoryCms
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //asp.net mvc
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
            }

            //asp.net webapi
            {
                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
                builder.RegisterType<SqliteConnectionProvider>();

                builder.RegisterType<SqliteAppRepository>().As<IAppRepository>().SingleInstance();
                builder.RegisterType<SqliteRepositoryRepository>().As<IRepositoryRepository>().SingleInstance();
                builder.RegisterType<SqliteMetaAppTypeRepository>().As<IMetaAppTypeRepository>().SingleInstance();
                builder.RegisterType<SqliteMetaRepositoryTypeRepository>().As<IMetaRepositoryTypeRepository>().SingleInstance();

                builder.RegisterType<AppConvertor>().As<IAppConvertor>().SingleInstance();
                builder.RegisterType<RepositoryConvertor>().As<IRepositoryConvertor>().SingleInstance();
                builder.RegisterType<MetaAppTypeConvertor>().As<IMetaAppTypeConvertor>().SingleInstance();
                builder.RegisterType<MetaRepositoryTypeConvertor>().As<IMetaRepositoryTypeConvertor>().SingleInstance();

                builder.RegisterType<MetaAppTypeMeta>().As<IMetaAppTypeMeta>().SingleInstance();
                builder.RegisterType<MetaRepositoryTypeMeta>().As<IMetaRepositoryTypeMeta>().SingleInstance();

                config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
            }
        }
    }
}