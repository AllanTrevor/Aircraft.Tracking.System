using System;
using System.Collections.Generic;
using System.Data;

namespace Rusada.Core.Data
{
	/// <summary>
	/// Generic repository interface.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		TEntity Get(string id);

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		TEntity Get(int id);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// Inserts the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		long Insert(TEntity entity);

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		bool Update(TEntity entity);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		bool Delete(TEntity entity);

		/// <summary>
		/// Gets the entities by sp.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		IEnumerable<TEntity> GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		TEntity GetEntityBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		IEnumerable<TEntity> GetEntitiesBySql(string sql);

		int ExecuteSPWithOutPut(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		int ExecuteSPWithInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		bool ExecuteSPWithBooleanInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);

		void ExecuteSP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters);
		IConnectionFactory GetConnectionFactory();

	}
}
