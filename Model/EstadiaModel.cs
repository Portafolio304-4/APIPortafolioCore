using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class EstadiaModel
    {
        private Conexion conn;
        private Estadia estadia;

        public EstadiaModel(Estadia estadia)
        {
            this.Estadia = estadia;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Estadia Estadia { get => estadia; set => estadia = value; }

        public List<Estadia> GetEstadias()
        {
            this.Conn = new Conexion();

            List<Estadia> lista_estadia = new List<Estadia>();
            string sql = "SELECT * FROM ESTADIA WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                string pais_estadia = reader.GetString(2);
                string ciudad_estadia = reader.GetString(3);
                int id_tipo_estadia = reader.GetInt32(4);
                int precio_por_persona = reader.GetInt32(5);
                int habilitado = reader.GetInt32(6);
                

                Estadia estadia = new Estadia(id, nombre, pais_estadia, ciudad_estadia, precio_por_persona, habilitado, id_tipo_estadia);
                lista_estadia.Add(estadia);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_estadia;
        }


        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM ESTADIA WHERE id_estadia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Estadia.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Estadia.Id = reader.GetInt32(0);
                    this.Estadia.Nombre = reader.GetString(1);
                    this.Estadia.Pais_estadia = reader.GetString(2);
                    this.Estadia.Ciudad_estadia = reader.GetString(3);
                    this.Estadia.Id_tipo_estadia = reader.GetInt32(4);
                    this.Estadia.Precio_por_persona = reader.GetInt32(5);
                    this.Estadia.Habilitado = reader.GetInt32(6);
                    
                    

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

            string sql = "INSERT INTO ESTADIA " +
                "(nombre_estadia,pais_estadia,ciudad_estadia,id_tipo_estadia,precio_por_persona)" +
                " VALUES" +
                "(:nombre,:pais,:ciudad,:id_tipo,:precio)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Estadia.Nombre;
            command.Parameters.Add(new OracleParameter("pais", OracleDbType.Varchar2)).Value = this.Estadia.Pais_estadia;
            command.Parameters.Add(new OracleParameter("ciudad", OracleDbType.Varchar2)).Value = this.Estadia.Ciudad_estadia;
            command.Parameters.Add(new OracleParameter("id_tipo", OracleDbType.Int32)).Value = this.Estadia.Id_tipo_estadia;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Estadia.Precio_por_persona;

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

            string sql = "UPDATE ESTADIA SET " +
                "nombre_estadia=:nombre " +
                "pais_estadia=:pais " +
                "ciudad_estadia=:ciudad " +
                "id_tipo_estadia=:id_tipo " +
                "precio_por_persona=:precio " +
                " WHERE id_estadia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Estadia.Nombre;
            command.Parameters.Add(new OracleParameter("pais", OracleDbType.Varchar2)).Value = this.Estadia.Pais_estadia;
            command.Parameters.Add(new OracleParameter("ciudad", OracleDbType.Varchar2)).Value = this.Estadia.Ciudad_estadia;
            command.Parameters.Add(new OracleParameter("id_tipo", OracleDbType.Int32)).Value = this.Estadia.Id_tipo_estadia;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Estadia.Precio_por_persona;

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

            string sql = "UPDATE ESTADIA SET habilitado=:habilitado WHERE id_estadia=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Estadia.Id_tipo_estadia;

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
