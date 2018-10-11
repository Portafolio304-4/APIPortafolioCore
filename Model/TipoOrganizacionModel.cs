using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TipoOrganizacionModel
    {
        private Conexion conn;
        private TipoOrganizacion tipo_organizacion;

        public TipoOrganizacionModel(TipoOrganizacion tipo_organizacion)
        {
            this.Tipo_organizacion = tipo_organizacion;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public TipoOrganizacion Tipo_organizacion { get => tipo_organizacion; set => tipo_organizacion = value; }

        public List<TipoOrganizacion> GetTipos()
        {
            this.Conn = new Conexion();

            List<TipoOrganizacion> lista_tipo_organizacion = new List<TipoOrganizacion>();
            string sql = "SELECT * FROM TIPO_ORGANIZACION WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                TipoOrganizacion tipo_organizacion = new TipoOrganizacion(id, nombre);
                lista_tipo_organizacion.Add(tipo_organizacion);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_tipo_organizacion;
        }

        public bool ReadById()
        {

            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TIPO_ORGANIZACION WHERE id_tipo_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Tipo_organizacion.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Tipo_organizacion.Id = reader.GetInt32(0);
                    this.Tipo_organizacion.Nombre = reader.GetString(1);
                    this.Tipo_organizacion.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO TIPO_ORGANIZACION (nombre_tipo_organizacion) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_organizacion.Nombre;

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

            string sql = "UPDATE TIPO_ORGANIZACION SET nombre_tipo_organizacion=:nombre WHERE id_tipo_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_organizacion.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_organizacion.Id;

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

            string sql = "UPDATE TIPO_ORGANIZACION SET habilitado=:habilitado WHERE id_tipo_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_organizacion.Id;

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
