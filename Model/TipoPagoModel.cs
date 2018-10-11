using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TipoPagoModel
    {
        private Conexion conn;
        private TipoPago tipo_pago;

        public TipoPagoModel(TipoPago tipo_pago)
        {
            this.Tipo_pago = tipo_pago;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public TipoPago Tipo_pago { get => tipo_pago; set => tipo_pago = value; }

        public List<TipoPago> GetTipos()
        {
            this.Conn = new Conexion();

            List<TipoPago> lista_tipo_pago = new List<TipoPago>();
            string sql = "SELECT * FROM TIPO_PAGO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                TipoPago tipo_pago = new TipoPago(id, nombre);
                lista_tipo_pago.Add(tipo_pago);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_tipo_pago;
        }

        public bool ReadById()
        {

            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TIPO_PAGO WHERE id_tipo_pago=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Tipo_pago.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Tipo_pago.Id = reader.GetInt32(0);
                    this.Tipo_pago.Nombre = reader.GetString(1);
                    this.Tipo_pago.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO TIPO_PAGO (nombre_tipo_pago) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_pago.Nombre;

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

            string sql = "UPDATE TIPO_PAGO SET nombre_tipo_pago=:nombre WHERE id_tipo_pago=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_pago.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_pago.Id;

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

            string sql = "UPDATE TIPO_PAGO SET habilitado=:habilitado WHERE id_tipo_pago=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_pago.Id;

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
