using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TipoActividadModel
    {
        private Conexion conn;
        private TipoActividad tipo_actividad;

        public TipoActividadModel(TipoActividad tipo_actividad)
        {
            this.Tipo_actividad = tipo_actividad;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public TipoActividad Tipo_actividad { get => tipo_actividad; set => tipo_actividad = value; }

        public List<TipoActividad> GetTipos()
        {
            this.Conn = new Conexion();

            List<TipoActividad> lista_tipo_actividad = new List<TipoActividad>();
            string sql = "SELECT * FROM TIPO_ACTIVIDAD WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                TipoActividad tipo_actividad = new TipoActividad(id, nombre);
                lista_tipo_actividad.Add(tipo_actividad);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_tipo_actividad;
        }

        public bool ReadById()
        {

            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TIPO_ACTIVIDAD WHERE id_tipo_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Tipo_actividad.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Tipo_actividad.Id = reader.GetInt32(0);
                    this.Tipo_actividad.Nombre = reader.GetString(1);
                    this.Tipo_actividad.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO TIPO_ACTIVIDAD (nombre_tipo_actividad) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_actividad.Nombre;

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

            string sql = "UPDATE TIPO_ACTIVIDAD SET nombre_tipo_actividad=:nombre WHERE id_tipo_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_actividad.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_actividad.Id;

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

            string sql = "UPDATE TIPO_ACTIVIDAD SET habilitado=:habilitado WHERE id_tipo_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_actividad.Id;

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
