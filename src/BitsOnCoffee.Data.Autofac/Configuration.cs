using Autofac;
using BitsOnCoffee.Data.Context;
using BitsOnCoffee.Data.Queries;
using BitsOnCoffee.Data.Repositories;
using BitsOnCoffee.Data.UoW;
using System.Linq;

namespace BitsOnCoffee.Data.Autofac
{
	public class Configuration<TContext, TRepository, TAnyQuery> where TContext : IDbContext where TRepository : RepositoryBase, IRepository
	{
		public void Initialize(ContainerBuilder builder)
		{
			builder.RegisterType<Scope>().As<IScope>();
			builder.RegisterType<UnitOfWorkProvider>().As<IUnitOfWorkProvider>().InstancePerRequest();
			builder.RegisterType<TContext>().As<IDbContext>().InstancePerLifetimeScope();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
			builder.RegisterType<TRepository>().As<IRepository>().InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(typeof(TAnyQuery).Assembly).Where(t => t.IsSubclassOf(typeof(QueryBase))).InstancePerLifetimeScope();
		}
	}
}