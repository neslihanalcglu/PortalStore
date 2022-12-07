﻿using Autofac;
using PortalStore.Core.Repositories;
using PortalStore.Core.Services;
using PortalStore.Core.UnitOfWorks;
using PortalStore.Repository;
using PortalStore.Repository.Repositories;
using PortalStore.Repository.UnitOfWorks;
using PortalStore.Service.Mapping;
using PortalStore.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace PortalStore.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();  
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly(); 
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext)); 
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile)); 

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces() 
                .InstancePerLifetimeScope(); 


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<MovieServiceWithCaching>();
        }
    }
}
