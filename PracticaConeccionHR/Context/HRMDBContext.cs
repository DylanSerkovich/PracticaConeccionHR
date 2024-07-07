using Oracle.ManagedDataAccess.Client;

namespace PracticaConeccionHR.Context
{
    public class HRMDBContext : IHRMDBContext
    {
        private IConfiguration _config;
        private OracleConnection _connection;
        private OracleCommand _cmd;
        private string _connectionString;

        public HRMDBContext(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public OracleCommand GetCommand()
        {
            _cmd = _connection.CreateCommand();
            return _cmd;
        }

        public OracleConnection GetConn()
        {
            _connection = new OracleConnection(_connectionString);
            return _connection;
        }
    }
}
