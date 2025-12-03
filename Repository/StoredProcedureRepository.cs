using System.Data;
using PMS.Business.Interface;
using PMS.Repository.DBContext;
using PMS.Repository.Extensions;

namespace PMS.Repository
{
    public class StoredProcedureRepository(API_DbContext context) : IStoredProcedureRepository,IDisposable
    {
        private readonly API_DbContext _context = context;

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<bool> ExecuteNonQueryAsync<T>(string strProcedure, T objPrams)
        {
            return await _context.ExecuteNonQueryAsync(strProcedure,objPrams);
        }

        public async Task<bool> ExecuteNonQueryAsync(string strProcedure)
        {
            return await _context.ExecuteNonQueryAsync(strProcedure);
        }

        public async Task<bool> ExecuteNonQueryAsync(string strProcedure, int id)
        {
            return await _context.ExecuteNonQueryAsync(strProcedure,id);
        }

        public async Task<object> ExecuteScalar(string strProcedure)
        {
           return await _context.ExecuteScalarAsync(strProcedure);
        }

        public async Task<object> ExecuteScalar<T>(string strProcedure, T objPrams)
        {
            return await _context.ExecuteScalarAsync(strProcedure,objPrams);
        }

        public async Task<object> ExecuteScalar(string strProcedure, int id)
        {
            return await _context.ExecuteScalarAsync(strProcedure,id);
        }

        public async Task<DataSet> GetDataSetAsync(string strProcedure)
        {
           return await _context.DataSet(strProcedure);
        }

        public async Task<DataSet> GetDataSetAsync<T>(string strProcedure, T objPrams)
        {
           return await _context.DataSet(strProcedure,objPrams);
        }

        public async Task<DataTable> GetDataTableAsync<T>(string strProcedure, T objPrams)
        {
           return await _context.DataTable(strProcedure,objPrams);
        }

        public async Task<DataTable> GetDataTableAsync(string strProcedure)
        {
            return await _context.DataTable(strProcedure);
        }
    }
}