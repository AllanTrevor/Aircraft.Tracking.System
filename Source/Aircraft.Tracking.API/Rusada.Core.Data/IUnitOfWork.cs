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

		/// <summary>
		/// Gets the data by SQL.
		/// </summary>
		/// <param name="sql">The SQL.</param>
		/// <returns></returns>
		object GetDataBySql(string sql);

		object GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		int GetStatusByExecuteSP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);
	}
}
