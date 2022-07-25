using System;
using System.Collections.Generic;

using Rusada.Core.Data;

namespace Rusada.DataAccess.Dapper
{
	public abstract class UnitOfWork : IUnitOfWork
	{
		private IConnectionFactory connectionFactory;

		protected Dictionary<string, dynamic> Repositories;

		public UnitOfWork(IConnectionFactory connectionFactory)
		{
			this.connectionFactory = connectionFactory;
			Repositories = new Dictionary<string, dynamic>();
		}

		public IRepository<TEntity> Repository<TEntity>() where TEntity : class
		{
			if (Repositories == null)
			{
				Repositories = new Dictionary<string, dynamic>();
			}

			var type = typeof(TEntity).Name;

			if (Repositories.ContainsKey(type))
			{
				return (IRepository<TEntity>)Repositories[type];
			}

			// TODO: Please check this. This might be implemented via DI.
			var repositoryType = typeof(Repository<>);
			Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this.connectionFactory));
			return Repositories[type];
		}

		
	}
}
