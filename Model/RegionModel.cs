using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RegionModel
    {
        private Conexion conn;
        private Region region;

        

        public RegionModel(Region region)
        {
            this.Region = region;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Region Region { get => region; set => region = value; }

        public List<Region> GetRegions()
        {
            this.Conn = new Conexion();

            List<Region> lista_regiones = new List<Region>();
            string sql = "SELECT * FROM REGION WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);

                Region region = new Region(id, nombre);
                lista_regiones.Add(region);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_regiones;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM REGION WHERE id_region=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Region.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Region.Id = reader.GetInt32(0);
                    this.Region.Nombre = reader.GetString(1);
                    this.Region.Habilitado = reader.GetInt32(2);
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

            string sql = "INSERT INTO REGION (nombre_region) VALUES (:nombre)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Region.Nombre;

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

            string sql = "UPDATE REGION SET nombre_region=:nombre WHERE id_region=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = this.Region.Nombre;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Region.Id;

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

            string sql = "UPDATE REGION SET habilitado=:habilitado WHERE id_region=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Region.Id;

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
