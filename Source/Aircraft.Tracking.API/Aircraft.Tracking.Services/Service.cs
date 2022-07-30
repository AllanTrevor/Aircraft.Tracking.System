using System;
using System.Collections.Generic;
using System.Data;

using Rusada.Core.Data;
using Aircraft.Tracking.Core;
using System.Threading.Tasks;

namespace Aircraft.Tracking.Services
{
	public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
	{
		private readonly IUnitOfWork unitOfWork;

		public Service(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public TEntity Get(string id)
		{
			return unitOfWork.Repository<TEntity>().Get(id);
		}

		public async Task<TEntity> GetAsync(string id)
		{
			return await unitOfWork.Repository<TEntity>().GetAsync(id);
		}

		public TEntity Get(int id)
		{
			return unitOfWork.Repository<TEntity>().Get(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return unitOfWork.Repository<TEntity>().GetAll();
		}

		public long Insert(TEntity entity)
		{
			return unitOfWork.Repository<TEntity>().Insert(entity);
		}

		public bool Update(TEntity entity)
		{
			return unitOfWork.Repository<TEntity>().Update(entity);
		}

		public bool Delete(TEntity entity)
		{
			return unitOfWork.Repository<TEntity>().Delete(entity);
		}

	}
}
