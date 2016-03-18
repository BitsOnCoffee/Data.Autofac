using BitsOnCoffee.Data.Context;
using Autofac;

namespace BitsOnCoffee.Data.Autofac
{
	public class Scope : IScope
	{
		private ILifetimeScope _scope;

		public Scope(ILifetimeScope scope)
		{
			_scope = scope;
		}

		public IScope BeginChildScope()
		{
			Scope scope = new Scope(_scope.BeginLifetimeScope());
			return scope;
		}

		public void Dispose()
		{
			_scope.Dispose();
		}

		public T Resolve<T>()
		{
			return _scope.Resolve<T>();
		}
	}
}
