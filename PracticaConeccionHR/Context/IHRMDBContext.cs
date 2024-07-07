using Oracle.ManagedDataAccess.Client;

namespace PracticaConeccionHR.Context
{
    public interface IHRMDBContext
    {
        OracleCommand GetCommand();
        OracleConnection GetConn();
    }
}
