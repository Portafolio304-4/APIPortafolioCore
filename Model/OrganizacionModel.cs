using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OrganizacionModel
    {
        private Conexion conn;
        private Organizacion organizacion;

        public OrganizacionModel(Organizacion organizacion)
        {
            this.Organizacion = organizacion;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Organizacion Organizacion { get => organizacion; set => organizacion = value; }

        public List<Organizacion> GetOrganizaciones()
        {
            this.Conn = new Conexion();

            List<Organizacion> lista_organizacion = new List<Organizacion>();
            string sql = "SELECT * FROM ORGANIZACION WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                string direccion = reader.GetString(2);
                int telefono = reader.GetInt32(3);
                int id_comuna = reader.GetInt32(4);
                int id_tipo_organizacion = reader.GetInt32(5);
                int habilitado = reader.GetInt32(6);

                Organizacion organizacion = new Organizacion(id, nombre, direccion, telefono, id_comuna, id_tipo_organizacion);
                lista_organizacion.Add(organizacion);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_organizacion;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM ORGANIZACION WHERE id_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Organizacion.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Organizacion.Id = reader.GetInt32(0);
                    this.Organizacion.Nombre = reader.GetString(1);
                    this.Organizacion.Direccion = reader.GetString(2);
                    this.Organizacion.Telefono = reader.GetInt32(3);
                    this.Organizacion.Id_comuna = reader.GetInt32(4);
                    this.Organizacion.Id_tipo_organizacion = reader.GetInt32(5);
                    this.Organizacion.Habilitado = reader.GetInt32(6);
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

            string sql = "INSERT INTO ORGANIZACION " +
                "(nombre_organizacion,direccion_organizacion,telefono_organizacion,id_comuna,id_tipo_organizacion)" +
                " VALUES" +
                "(:nombre,:direccion,:telefono,:id_comuna,:id_tipo_organizacion)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Organizacion.Nombre;
            command.Parameters.Add(new OracleParameter("direccion", OracleDbType.Varchar2)).Value = this.Organizacion.Direccion;
            command.Parameters.Add(new OracleParameter("telefono", OracleDbType.Int32)).Value = this.Organizacion.Telefono;
            command.Parameters.Add(new OracleParameter("id_comuna", OracleDbType.Int32)).Value = this.Organizacion.Id_comuna;
            command.Parameters.Add(new OracleParameter("id_tipo_organizacion", OracleDbType.Int32)).Value = this.Organizacion.Id_tipo_organizacion;

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

            string sql = "UPDATE ORGANIZACION SET " +
                "nombre_organizacion=:nombre " +
                "direccion_organizacion=:direccion " +
                "telefono_organizacion=:telefono " +
                "id_comuna=:id_comuna " +
                "id_tipo_organizacion=:id_tipo_organizacion " +
                " WHERE id_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Organizacion.Nombre;
            command.Parameters.Add(new OracleParameter("direccion", OracleDbType.Varchar2)).Value = this.Organizacion.Direccion;
            command.Parameters.Add(new OracleParameter("telefono", OracleDbType.Int32)).Value = this.Organizacion.Telefono;
            command.Parameters.Add(new OracleParameter("id_comuna", OracleDbType.Int32)).Value = this.Organizacion.Id_comuna;
            command.Parameters.Add(new OracleParameter("id_tipo_organizacion", OracleDbType.Int32)).Value = this.Organizacion.Id_tipo_organizacion;

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

            string sql = "UPDATE ORGANIZACION SET habilitado=:habilitado WHERE id_organizacion=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Organizacion.Id;

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
