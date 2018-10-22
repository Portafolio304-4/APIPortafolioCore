using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ServicioTuristicoModel
    {
        private Conexion conn;
        private ServicioTuristico servicio_turistico;

        public ServicioTuristicoModel(ServicioTuristico servicio_turistico)
        {
            this.Servicio_turistico = servicio_turistico;

        }

        public Conexion Conn { get => Conn; set => Conn = value; }
        public ServicioTuristico Servicio_turistico { get => Servicio_turistico; set => Servicio_turistico = value; }

        public List<ServicioTuristico> GetServicioTuristicos()
        {
            this.Conn = new Conexion();

            List<ServicioTuristico> lista_servicio_turisticos = new List<ServicioTuristico>();
            string sql = "SELECT * FROM SERVICIO_TURISTICO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int precio = reader.GetInt32(1);
                int habilitado = reader.GetInt32(2);
                string nombre = reader.GetString(3);
                string descripcion = reader.GetString(4);

                ServicioTuristico servicio_turistico = new ServicioTuristico(id, nombre, descripcion);
                servicio_turistico.Precio = precio;
                lista_servicio_turisticos.Add(servicio_turistico);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_servicio_turisticos;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM SERVICIO_TURISTICO WHERE id_servicio_turistico=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Servicio_turistico.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Servicio_turistico.Id = reader.GetInt32(0);
                    this.Servicio_turistico.Precio = reader.GetInt32(1);
                    this.Servicio_turistico.Nombre = reader.GetString(2);
                    this.Servicio_turistico.Descripcion = reader.GetString(3);
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

            string sql = "INSERT INTO SERVICIO_TURISTICO (precio_por_persona,nombre_destino,descripcion) " +
                "VALUES (:precio,:nombre,:descripcion)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Servicio_turistico.Precio;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Servicio_turistico.Nombre;
            command.Parameters.Add(new OracleParameter("descripcion", OracleDbType.Varchar2)).Value = this.Servicio_turistico.Descripcion;

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

            string sql = "UPDATE SERVICIO_TURISTICO " +
                "SET precio_por_persona=:precio " +
                "nombre_destino=:nombre " +
                "descripcion=:descripcion" +
                " WHERE id_servicio_turistico=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Servicio_turistico.Precio;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Servicio_turistico.Nombre;
            command.Parameters.Add(new OracleParameter("descripcion", OracleDbType.Varchar2)).Value = this.Servicio_turistico.Descripcion;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Servicio_turistico.Id;

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

            string sql = "UPDATE SERVICIO_TURISTICO SET habilitado=:habilitado WHERE id_servicio_turistico=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Servicio_turistico.Id;

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
