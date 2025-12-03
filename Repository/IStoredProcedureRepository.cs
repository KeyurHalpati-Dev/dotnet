using System.Data;

namespace PMS.Repository
{
    public interface IStoredProcedureRepository
    {
        Task<DataTable> GetDataTableAsync<T>(string strProcedure, T objPrams);
        Task<DataTable> GetDataTableAsync(string strProcedure);

        Task<DataSet> GetDataSetAsync(string strProcedure);
        Task<DataSet> GetDataSetAsync<T>(string strProcedure, T objPrams);

        Task<Boolean> ExecuteNonQueryAsync<T>(string strProcedure, T objPrams);
        Task<Boolean> ExecuteNonQueryAsync(string strProcedure, int id);
        Task<Boolean> ExecuteNonQueryAsync(string strProcedure);

        Task<Object> ExecuteScalar(string strProcedure);
        Task<Object> ExecuteScalar<T>(string strProcedure, T objPrams);
        Task<Object> ExecuteScalar(string strProcedure,int id);
    }
}