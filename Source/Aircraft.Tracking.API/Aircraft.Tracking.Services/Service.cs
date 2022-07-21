using System;
using System.Collections.Generic;
using System.Data;

using Rusada.Core.Data;
using Aircraft.Tracking.Core;

namespace Aircraft.Tracking.Services
{
	public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
	{
		private readonly IAircraftTrackingUnitOfWork unitOfWork;

		public Service(IAircraftTrackingUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public TEntity Get(string id)
		{
			return unitOfWork.Repository<TEntity>().Get(id);
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

		public IEnumerable<TEntity> GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> GetEntitiesBySql(string sql)
		{
			throw new NotImplementedException();
		}

		public TEntity GetEntityBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
		{
			throw new NotImplementedException();
		}
	}
}
