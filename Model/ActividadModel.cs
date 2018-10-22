using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ActividadModel
    {
        private Conexion conn;
        private Actividad actividad;

        public ActividadModel(Actividad actividad)
        {
            this.Actividad = actividad;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Actividad Actividad { get => actividad; set => actividad = value; }

        public List<Actividad> GetActividads()
        {
            this.Conn = new Conexion();

            List<Actividad> lista_actividad = new List<Actividad>();
            string sql = "SELECT * FROM ACTIVIDAD WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                int id_tipo_actividad = reader.GetInt32(2);
                int precio_por_persona = reader.GetInt32(3);
                int habilitado = reader.GetInt32(4);

                Actividad actividad = new Actividad(id, nombre, precio_por_persona, habilitado, id_tipo_actividad);
                lista_actividad.Add(actividad);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_actividad;
        }


        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM ACTIVIDAD WHERE id_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Actividad.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Actividad.Id = reader.GetInt32(0);
                    this.Actividad.Nombre = reader.GetString(1);
                    this.Actividad.Id_tipo_actividad = reader.GetInt32(2);
                    this.Actividad.Precio = reader.GetInt32(3);
                    this.Actividad.Habilitado = reader.GetInt32(4);

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

            string sql = "INSERT INTO ACTIVIDAD " +
                "(nombre_actividad,id_tipo_actividad,precio_por_persona)" +
                " VALUES" +
                "(:nombre,:id_tipo_actividad,:precio)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Varchar2)).Value = this.Actividad.Nombre;
            command.Parameters.Add(new OracleParameter("id_tipo_actividad", OracleDbType.Int32)).Value = this.Actividad.Id_tipo_actividad;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Actividad.Precio;

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

            string sql = "UPDATE ACTIVIDAD SET " +
                "nombre_actividad=:nombre " +
                "id_tipo_actividad=:id_tipo_actividad " +
                "precio_por_persona=:precio " +
                "ap_pat_actividad=:ap_paterno " +
                "ap_mat_actividad=:ap_materno " +
                "id_curso=:id_curso " +
                " WHERE id_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre_actividad", OracleDbType.Varchar2)).Value = this.Actividad.Nombre;
            command.Parameters.Add(new OracleParameter("id_tipo_actividad", OracleDbType.Int32)).Value = this.Actividad.Id_tipo_actividad;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Actividad.Precio;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Actividad.Id_tipo_actividad;

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

            string sql = "UPDATE ACTIVIDAD SET habilitado=:habilitado WHERE id_actividad=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Actividad.Id_tipo_actividad;

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
