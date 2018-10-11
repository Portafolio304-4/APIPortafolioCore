using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TipoTransporteModel
    {
        private Conexion conn;
        private TipoTransporte tipo_transporte;

        public TipoTransporteModel(TipoTransporte tipo_transporte)
        {
            this.Tipo_transporte = tipo_transporte;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public TipoTransporte Tipo_transporte { get => tipo_transporte; set => tipo_transporte = value; }

        public List<TipoTransporte> GetTipos()
        {
            this.Conn = new Conexion();

            List<TipoTransporte> lista_tipos_transporte = new List<TipoTransporte>();
            string sql = "SELECT * FROM TIPO_TRANSPORTE WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                TipoTransporte tipo_transporte = new TipoTransporte(id, nombre);
                lista_tipos_transporte.Add(tipo_transporte);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_tipos_transporte;
        }

        public bool ReadById()
        {

            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TIPO_TRANSPORTE WHERE id_tipo_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Tipo_transporte.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Tipo_transporte.Id = reader.GetInt32(0);
                    this.Tipo_transporte.Nombre = reader.GetString(1);
                    this.Tipo_transporte.Habilitado = reader.GetInt32(2);
                }
                if (reader.HasRows)
                    found = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return found;

        }

        public bool Create()
        {
            bool created = false;
            this.Conn = new Conexion();

            string sql = "INSERT INTO TIPO_TRANSPORTE (nombre_tipo_transporte) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_transporte.Nombre;

            try
            {
                int rowsUpdated = command.ExecuteNonQuery();
                if (rowsUpdated > 0)
                {
                    created = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return created;
        }

        public bool Update()
        {
            bool updated = false;
            this.Conn = new Conexion();

            string sql = "UPDATE TIPO_TRANSPORTE SET nombre_tipo_transporte=:nombre WHERE id_tipo_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_transporte.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_transporte.Id;

            try
            {
                int rowsUpdated = command.ExecuteNonQuery();
                if (rowsUpdated > 0)
                    updated = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return updated;
        }

        public bool Delete()
        {
            bool deleted = false;
            this.Conn = new Conexion();

            string sql = "UPDATE TIPO_TRANSPORTE SET habilitado=:habilitado WHERE id_tipo_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_transporte.Id;

            try
            {
                int rowsUpdated = command.ExecuteNonQuery();
                if (rowsUpdated > 0)
                    deleted = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return deleted;
        }
    }
}
