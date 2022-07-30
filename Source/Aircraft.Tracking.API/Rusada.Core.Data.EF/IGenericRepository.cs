using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Core.Data.EF
{
	/// <summary>
	/// Generic repository interface.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		TEntity Get(int id);


		Task<TEntity> GetAsync(int id);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll();

		IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

		/// <summary>
		/// Inserts the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		TEntity Insert(TEntity entity);

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		TEntity Update(TEntity entity);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Delete(TEntity entity);
	}
}
