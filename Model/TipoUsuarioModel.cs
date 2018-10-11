using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TipoUsuarioModel
    {
        private Conexion conn;
        private TipoUsuario tipo_usuario;

        public TipoUsuarioModel(TipoUsuario tipo_usuario)
        {
            this.Tipo_usuario = tipo_usuario;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public TipoUsuario Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }

        public List<TipoUsuario> GetTipos()
        {
            this.Conn = new Conexion();

            List<TipoUsuario> lista_tipos_usuario = new List<TipoUsuario>();
            string sql = "SELECT * FROM TIPO_USUARIO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                TipoUsuario tipo_usuario = new TipoUsuario(id, nombre);
                lista_tipos_usuario.Add(tipo_usuario);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_tipos_usuario;
        }

        public bool ReadById() {

            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TIPO_USUARIO WHERE id_tipo_usuario=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Tipo_usuario.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Tipo_usuario.Id = reader.GetInt32(0);
                    this.Tipo_usuario.Nombre = reader.GetString(1);
                    this.Tipo_usuario.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO TIPO_USUARIO (nombre_tipo_usuario) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Tipo_usuario.Nombre;

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

            string sql = "UPDATE TIPO_USUARIO SET nombre_tipo_usuario=:nombre WHERE id_tipo_usuario=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Tipo_usuario.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_usuario.Id;

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

            string sql = "UPDATE TIPO_USUARIO SET habilitado=:habilitado WHERE id_tipo_usuario=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Tipo_usuario.Id;

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
