namespace CaseManagerLibrary.Data.DataAccess
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStringName);
        Task SaveData<T>(string sql, T parameters, string connectionStringName);
    }
}