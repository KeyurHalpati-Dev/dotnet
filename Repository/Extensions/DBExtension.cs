#pragma warning disable
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PMS.Repository.Extensions
{
    public static class DBExtension
    {
        public static async Task<DataTable> DataTable(this DbContext context, string sqlQuery)
        {
            DataTable dt = await DataTable<object>(context, sqlQuery, null);
            return dt;
        }

        public static async Task<DataTable> DataTable<T>(this DbContext context, string sqlQuery, T? objParams)
        {
            DataTable? dataTable = new DataTable();
            DbConnection? connection = context.Database.GetDbConnection();

            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();

                    DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);

                    if (dbFactory != null)
                    {
                        using (DbCommand? cmd = dbFactory.CreateCommand())
                        {
                            if (cmd != null)
                            {
                                cmd.Connection = connection;
                                cmd.CommandTimeout = 0;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = sqlQuery;
                                cmd.SetParams(objParams);

                                var result = await cmd.ExecuteReaderAsync();
                                dataTable.Load(result);
                            }
                        }
                    }
                }
                return dataTable;
            }
            finally
            {
                await connection.CloseAsync();
                dataTable = null;
            }
        }

        public static async Task<DataSet> DataSet(this DbContext context, string sqlQuery)
        {
            DataSet ds = await DataSet<object>(context, sqlQuery, null);
            return ds;
        }

        public static async Task<DataSet> DataSet<T>(this DbContext context, string sqlQuery, T? objParams)
        {
            //Result data = new Result();
            DataSet DS = new DataSet();
            DbConnection connection = context.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
                if (dbFactory != null)
                {
                    using (DbCommand? cmd = dbFactory.CreateCommand())
                    {
                        if (cmd != null)
                        {
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = sqlQuery;
                            cmd.SetParams(objParams);

                            DbDataAdapter? adapter = dbFactory.CreateDataAdapter();
                            if (adapter != null)
                            {
                                adapter.SelectCommand = cmd;
                                adapter.Fill(DS);
                                DS.SetTableName();
                            }
                        }
                    }
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
            return DS;
        }

        public static async Task<Boolean> ExecuteNonQueryAsync<T>(this DbContext context, string sqlQuery, T objParams)
        {
            DbConnection connection = context.Database.GetDbConnection();
            Boolean Issucess = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
                if (dbFactory != null)
                {
                    using (DbCommand? cmd = dbFactory.CreateCommand())
                    {
                        if (cmd != null)
                        {
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = sqlQuery;
                            cmd.SetParams(objParams);

                            var response = await cmd.ExecuteNonQueryAsync();
                            if (response != -1)
                            {
                                Issucess = true;
                            }
                            else
                            {
                                Issucess = false;
                            }
                        }
                    }
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
            return Issucess;
        }

        public static async Task<Boolean> ExecuteNonQueryAsync(this DbContext context, string sqlQuery)
        {
            DbConnection connection = context.Database.GetDbConnection();
            Boolean Issucess = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
                if (dbFactory != null)
                {
                    using (DbCommand? cmd = dbFactory.CreateCommand())
                    {
                        if (cmd != null)
                        {
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = sqlQuery;

                            var response = await cmd.ExecuteNonQueryAsync();
                            if (response != -1)
                            {
                                Issucess = true;
                            }
                            else
                            {
                                Issucess = false;
                            }
                        }
                    }
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
            return Issucess;
        }

        public static async Task<Boolean> ExecuteNonQueryAsync(this DbContext context, string sqlQuery, int objParams)
        {
            DbConnection connection = context.Database.GetDbConnection();
            Boolean Issucess = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
                if (dbFactory != null)
                {
                    using (DbCommand? cmd = dbFactory.CreateCommand())
                    {
                        if (cmd != null)
                        {
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = sqlQuery;
                            cmd.SetParams(objParams);

                            var response = await cmd.ExecuteNonQueryAsync();
                            if (response == 1)
                            {
                                Issucess = true;
                            }
                            else
                            {
                                Issucess = false;
                            }
                        }
                    }
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
            return Issucess;
            //return data;
        }

        public static async Task<Object> ExecuteScalarAsync(this DbContext context, string sqlQuery)
        {
            DbConnection connection = context.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
                using (DbCommand? cmd = dbFactory?.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlQuery;

                    var result = await cmd.ExecuteScalarAsync();
                    return result;
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public static async Task<Object> ExecuteScalarAsync<T>(this DbContext context, string sqlQuery, T objParams)
        {
            DbConnection connection = context.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
                using (DbCommand cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlQuery;
                    cmd.SetParams(objParams);

                    return await cmd.ExecuteScalarAsync();
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public static async Task<Object> ExecuteScalarAsync(this DbContext context, string sqlQuery, object objParams)
        {
            DbConnection connection = context.Database.GetDbConnection();

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
                using (DbCommand cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlQuery;
                    cmd.SetParams(objParams);

                    return await cmd.ExecuteScalarAsync();
                }
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Execute Scalar for Transaction Method
        /// Only User When All Form Data Store in Multiple Tables (Transaction use)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="connection"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="objParams"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static async Task<Object> ExecuteScalarAsync<T>(this DbContext context, DbConnection connection, string sqlQuery, T objParams, DbTransaction transaction)
        {
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
            using (DbCommand? cmd = dbFactory?.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlQuery;
                cmd.Transaction = transaction;
                cmd.SetParams(objParams);

                return await cmd.ExecuteScalarAsync();
            }
        }

        /// <summary>
        /// Execute Non Query for Transaction Method
        /// Only User When All Form Data Store in Multiple Tables (Transaction use)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="connection"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="objParams"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static async Task<Boolean> ExecuteNonQueryAsync<T>(this DbContext context, DbConnection connection, string sqlQuery, T objParams, DbTransaction transaction)
        {
            Boolean Issucess = false;

            DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
            if (dbFactory != null)
            {
                using (DbCommand? cmd = dbFactory.CreateCommand())
                {
                    if (cmd != null)
                    {
                        cmd.Connection = connection;
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlQuery;
                        cmd.Transaction = transaction;
                        cmd.SetParams(objParams);

                        var response = await cmd.ExecuteNonQueryAsync();
                        if (response != -1)
                        {
                            Issucess = true;
                        }
                        else
                        {
                            Issucess = false;
                        }
                    }
                }
            }
            return Issucess;
        }

        /// <summary>
        /// Datatable For Transaction Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public static async Task<DataTable> DataTableAsync<T>(this DbContext context, DbConnection connection, DbTransaction transaction, string sqlQuery, T? objParams)
        {
            DataTable dataTable = new();

            DbProviderFactory? dbFactory = DbProviderFactories.GetFactory(connection);
            if (dbFactory != null)
            {
                using (DbCommand? cmd = dbFactory.CreateCommand())
                {
                    if (cmd != null)
                    {
                        cmd.Connection = connection;
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlQuery;
                        cmd.Transaction = transaction;
                        cmd.SetParams(objParams);

                        var result = await cmd.ExecuteReaderAsync();
                        dataTable.Load(result);
                    }
                }
            }
            return dataTable;
        }
    }
}
    #pragma warning restore