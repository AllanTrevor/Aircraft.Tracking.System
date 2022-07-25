using System;
using System.Collections.Generic;
using System.Data;

namespace Rusada.Core.Data
{
	/// <summary>
	/// Unit of work interface.
	/// </summary>
	public interface IUnitOfWork
	{
		/// <summary>
		/// Repositories this instance.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns></returns>
		IRepository<TEntity> Repository<TEntity>() where TEntity : class;

	}
}
