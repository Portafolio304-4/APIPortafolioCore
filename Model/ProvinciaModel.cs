using System;
using System.Collections.Generic;
using System.Text;
using DTOs;
using Oracle.ManagedDataAccess.Client;

namespace Model
{
    public class ProvinciaModel
    {
        private Conexion conn;
        private Provincia provincia;

        public ProvinciaModel(Provincia provincia)
        {
            this.Provincia = provincia;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }

        public List<Provincia> GetProvincias()
        {
            this.Conn = new Conexion();

            List<Provincia> lista_provincias = new List<Provincia>();
            string sql = "SELECT * FROM PROVINCIA WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                Provincia provincia = new Provincia(id, nombre);
                lista_provincias.Add(provincia);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_provincias;
        }

        public List<Provincia> GetProvinciasByRegion()
        {
            this.Conn = new Conexion();

            List<Provincia> lista_provincias = new List<Provincia>();
            string sql = "SELECT * FROM PROVINCIA WHERE habilitado=1 AND id_region=:id_region";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            command.Parameters.Add(new OracleParameter("id_region", OracleDbType.Int32)).Value = this.Provincia.Id_region;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                Provincia provincia = new Provincia(id, nombre);
                lista_provincias.Add(provincia);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_provincias;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM PROVINCIA WHERE id_provincia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Provincia.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Provincia.Id = reader.GetInt32(0);
                    this.Provincia.Nombre = reader.GetString(1);
                    this.Provincia.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO PROVINCIA (nombre_provincia,id_region) VALUES (:nombre,:id_region)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Provincia.Nombre;
            command.Parameters.Add(new OracleParameter("id_region", OracleDbType.Int32)).Value = this.Provincia.Id_region;

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

            string sql = "UPDATE PROVINCIA SET nombre_provincia=:nombre WHERE id_provincia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Provincia.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Provincia.Id;

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

            string sql = "UPDATE PROVINCIA SET habilitado=:habilitado WHERE id_provincia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Provincia.Id;

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
