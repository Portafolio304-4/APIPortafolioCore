using Oracle.ManagedDataAccess.Client;
using System;

namespace Model
{
    public class Conexion
    {
        string connectionString = "DATA SOURCE=Bena:1521/XE;USER ID=PORTAFOLIO;PASSWORD=12345";
        OracleConnection _connection;

        public Conexion()
        {
            this.Connection = new OracleConnection();
            Connection.ConnectionString = this.connectionString;
            Connection.Open();
        }

        public OracleConnection Connection { get => _connection; set => _connection = value; }
    }
}
