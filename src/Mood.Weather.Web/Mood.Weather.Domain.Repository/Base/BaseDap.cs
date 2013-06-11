using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

using Mood.Weather.Domain.Factories;

namespace Mood.Weather.Domain.Repository.Base
{
    public partial class BaseDap : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public BaseDap(IDbConnectionFactory aConnectionFactory)
        {
            aConnectionFactory.ThrowIfArgumentIsNull("IDbConnectionFactory");
            _connection = aConnectionFactory.Create();
            
        }

        public IDbConnection Connection
        {
            get { return _connection; }
            protected set { _connection = value; }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
            set
            {
                _transaction = value;
                if (_transaction != null)
                    _connection = _transaction.Connection;
            }
        }

        public bool HasActiveTransaction
        {
            get
            {
                return _transaction != null;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _connection.BeginTransaction(isolationLevel);
            return _transaction;
        }
 
        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        protected void OpenConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();
        }

        protected void CloseConnection()
        {
            if (_connection != null)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
                _connection.Close();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            if (_connection != null)
                _connection.Dispose();
                
            _transaction = null;
            _connection = null;
        }

        public void RunInTransaction(Action action)
        {
            BeginTransaction();
            try
            {
                action();
                Commit();
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }
                throw ex;
            }
        }

        public T RunInTransaction<T>(Func<T> func)
        {
            BeginTransaction();
            try
            {
                T result = func();
                Commit();
                return result;
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }
                throw ex;
            }
        }

        /// <summary>
        /// Execute parameterized SQL  
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Return a list of dynamic objects, reader is closed after the call
        /// </summary>
        public IEnumerable<dynamic> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Executes a query, returning the data typed as per T
        /// </summary>
        /// <remarks>the dynamic param may seem a bit odd, but this works around a major usability issue in vs, if it is Object vs completion gets annoying. Eg type new [space] get new object</remarks>
        /// <returns>A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        public IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 5 input parameters
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 4 input parameters
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn
        /// </summary>
        public SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();

            return SqlMapper.QueryMultiple(_connection, sql, param, transaction, commandTimeout, commandType);
        }


    }
}