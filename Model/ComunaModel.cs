using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ComunaModel
    {
        private Conexion conn;
        private Comuna comuna;

        public ComunaModel(Comuna comuna)
        {
            this.Comuna = comuna;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Comuna Comuna { get => comuna; set => comuna = value; }

        public List<Comuna> GetComunas()
        {
            this.Conn = new Conexion();

            List<Comuna> lista_comunas = new List<Comuna>();
            string sql = "SELECT * FROM COMUNA WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                Comuna comuna = new Comuna(id, nombre);
                lista_comunas.Add(comuna);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_comunas;
        }

        public List<Comuna> GetComunasByProvincia()
        {
            this.Conn = new Conexion();

            List<Comuna> lista_comunas = new List<Comuna>();
            string sql = "SELECT * FROM COMUNA WHERE habilitado=1 AND id_provincia=:id";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Comuna.Id_provincia;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                Comuna comuna = new Comuna(id, nombre);
                lista_comunas.Add(comuna);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_comunas;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM COMUNA WHERE id_comuna=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Comuna.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Comuna.Id = reader.GetInt32(0);
                    this.Comuna.Nombre = reader.GetString(1);
                    this.Comuna.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO COMUNA (nombre_comuna,id_provincia) VALUES (:nombre,:id)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Comuna.Nombre;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Comuna.Id_provincia;

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

            string sql = "UPDATE COMUNA SET nombre_comuna=:nombre WHERE id_comuna=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Comuna.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Comuna.Id;

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

            string sql = "UPDATE COMUNA SET habilitado=:habilitado WHERE id_comuna=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Comuna.Id;

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
