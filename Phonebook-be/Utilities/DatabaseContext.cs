using NPoco;
using NPoco.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook_be.Utilities
{
    public class LocalDatabase : DatabaseContext
    {
        readonly string _connectionString;
        public LocalDatabase(IAppSettings settings)
        {
            _connectionString = settings.DevConnection;
        }

        public override IDatabase MainContext()
        {
            return new Database(_connectionString, DatabaseType.SqlServer2012,
                 System.Data.SqlClient.SqlClientFactory.Instance);
        }
    }
    public interface IDatabaseContext
    {
        int Delete(object Record);
        int Execute(string sql, params object[] args);
        T ExecuteScalar<T>(string sql, params object[] args);
        T FirstOrDefault<T>(string sql, params object[] args);
        object Insert(object NewRecord);
        IDatabase MainContext();
        IQueryProviderWithIncludes<T> Query<T>();
        IEnumerable<T> Query<T>(string sql, params object[] args);
        int Update(object Record);
    }

    public abstract class DatabaseContext : IDatabaseContext
    {
        public abstract IDatabase MainContext();

        public object Insert(object NewRecord)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Insert(NewRecord);
            }
        }

        public int Update(object Record)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Update(Record);
            }
        }

        public int Delete(object Record)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Delete(Record);
            }
        }

        public IEnumerable<T> Query<T>(string sql, params object[] args)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Query<T>(sql, args);
            }
        }

        public IQueryProviderWithIncludes<T> Query<T>()
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Query<T>();
            }
        }


        public T FirstOrDefault<T>(string sql, params object[] args)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.FirstOrDefault<T>(sql, args);
            }
        }

        public T ExecuteScalar<T>(string sql, params object[] args)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.ExecuteScalar<T>(sql, args);
            }
        }

        public int Execute(string sql, params object[] args)
        {
            using (var _dbContext = MainContext())
            {
                return _dbContext.Execute(sql, args);
            }
        }
    }
}
