﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Rusada.Core.Data
{
	public interface IService<TEntity> where TEntity : class
	{
		TEntity Get(string id);

		TEntity Get(int id);

		IEnumerable<TEntity> GetAll();

		long Insert(TEntity entity);

		bool Update(TEntity entity);

		bool Delete(TEntity entity);

	}
}
