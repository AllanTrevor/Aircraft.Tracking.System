using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

using Dapper;
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

            //using (var transaction = new TransactionScope())
            //{
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                identity = connection.Insert(entity);
            }

            //transaction.Complete();
            return identity;
            //}
        }

        public bool Update(TEntity entity)
        {
            bool isSuccess;

            //using (var transaction = new TransactionScope())
            //{
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                isSuccess = connection.Update(entity);
            }

            //transaction.Complete();
            return isSuccess;
            //}
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

        public int ExecuteSP(string storedProcedureName, DynamicParameters parameters)
        {
            int affectedRows;
            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    affectedRows = connection.Execute(
                            storedProcedureName,
                            param: parameters,
                            commandType: CommandType.StoredProcedure);
                }

                transaction.Complete();
                return affectedRows;
            }
        }

        public int ExecuteSql(string sql, DynamicParameters parameters)
        {
            int affectedRows;
            using (var transaction = new TransactionScope())
            {
                using (var connection = connectionFactory.GetConnection())
                {
                    connection.Open();
                    affectedRows = connection.Execute(
                            sql,
                            param: parameters,
                            commandType: CommandType.Text);
                }

                transaction.Complete();
                return affectedRows;
            }
        }

        public IEnumerable<dynamic> QueryBySP(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<dynamic> result = connection.Query(
                        storedProcedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<dynamic> QueryBySql(string sql, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<dynamic> result = connection.Query(
                        sql,
                        param: parameters,
                        commandType: CommandType.Text);

                return result;
            }
        }


        public IEnumerable<TEntity> GetEntitiesBySql(string sql, DynamicParameters parameters)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<TEntity> result = connection.Query<TEntity>(
                        sql,
                        param: parameters,
                        commandType: CommandType.Text);

                return result;
            }
        }

        public IEnumerable<TEntity> GetEntitiesBySql(string sql)
        {
            using (var connection = connectionFactory.GetConnection())
            {
                connection.Open();
                IEnumerable<TEntity> result = connection.Query<TEntity>(
                    sql,
                    commandType: CommandType.Text);

                return result;
            }
        }



        public IConnectionFactory GetConnectionFactory()
        {
            return connectionFactory;
        }

        public IEnumerable<TEntity> GetEntitiesBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityBySP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSPWithOutPut(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSPWithInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteSPWithBooleanInputOutput(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }

        public void ExecuteSP(string storedProcedureName, Dictionary<string, Tuple<string, DbType, ParameterDirection>> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
