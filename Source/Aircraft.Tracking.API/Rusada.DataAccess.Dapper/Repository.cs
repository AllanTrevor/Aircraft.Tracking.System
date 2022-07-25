using System.Collections.Generic;
using System.Transactions;
using Dapper.Contrib.Extensions;

using Rusada.Core.Data;

namespace Rusada.DataAccess.Dapper
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IConnectionFactory connectionFactory;

        public Repository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public TEntity Get(string id)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.Get<TEntity>(id);
            }
        }

        public TEntity Get(int id)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                return connection.GetAll<TEntity>();
            }
        }

        public long Insert(TEntity entity)
        {
            long identity;


            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                identity = connection.Insert(entity);
            }

            return identity;
        }

        public bool Update(TEntity entity)
        {
            bool isSuccess;

            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                isSuccess = connection.Update(entity);
            }

            return isSuccess;

        }

        public bool Delete(TEntity entity)
        {
            bool isSuccess;

            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    isSuccess = connection.Delete(entity);
                }

                transaction.Complete();
                return isSuccess;
            }
        }

        public IConnectionFactory GetConnectionFactory()
        {
            return connectionFactory;
        }
      
    }
}
