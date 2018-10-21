using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TransporteModel
    {
        private Conexion conn;
        private Transporte transporte;

        public TransporteModel(Transporte transporte)
        {
            this.Transporte = transporte;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Transporte Transporte { get => transporte; set => transporte = value; }

        public List<Transporte> GetTransportes()
        {
            this.Conn = new Conexion();

            List<Transporte> lista_transporte = new List<Transporte>();
            string sql = "SELECT * FROM TRANSPORTE WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string origen = reader.GetString(1);
                string destino = reader.GetString(2);
                string nombre_compañia = reader.GetString(3);
                int id_tipo_transporte = reader.GetInt32(4);
                int precio_por_persona = reader.GetInt32(5);
                int habilitado = reader.GetInt32(6);


                Transporte transporte = new Transporte(id, origen, destino, nombre_compañia, precio_por_persona, habilitado, id_tipo_transporte);
                lista_transporte.Add(transporte);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_transporte;
        }


        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM TRANSPORTE WHERE id_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Transporte.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Transporte.Id = reader.GetInt32(0);
                    this.Transporte.Origen = reader.GetString(1);
                    this.Transporte.Destino = reader.GetString(2);
                    this.Transporte.Nombre_compañia = reader.GetString(3);
                    this.Transporte.Id_tipo_transporte = reader.GetInt32(4);
                    this.Transporte.Precio_por_persona = reader.GetInt32(5);
                    this.Transporte.Habilitado = reader.GetInt32(6);



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

            string sql = "INSERT INTO TRANSPORTE " +
                "(origen_transporte,destino_transporte,nombre_compania_transporte,id_tipo_transporte,precio_por_persona)" +
                " VALUES" +
                "(:origen,:destino,:nombre,:id_tipo,:precio)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Transporte.Origen;
            command.Parameters.Add(new OracleParameter("pais", OracleDbType.Varchar2)).Value = this.Transporte.Destino;
            command.Parameters.Add(new OracleParameter("ciudad", OracleDbType.Varchar2)).Value = this.Transporte.Nombre_compañia;
            command.Parameters.Add(new OracleParameter("id_tipo", OracleDbType.Int32)).Value = this.Transporte.Id_tipo_transporte;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Transporte.Precio_por_persona;

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

            string sql = "UPDATE TRANSPORTE SET " +
                "origen_transporte=:origen " +
                "destino_transporte=:destino " +
                "nombre_compania_transporte=:nombre " +
                "id_tipo_transporte=:id_tipo " +
                "precio_por_persona=:precio " +
                " WHERE id_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("origen", OracleDbType.Varchar2)).Value = this.Transporte.Origen;
            command.Parameters.Add(new OracleParameter("destino", OracleDbType.Varchar2)).Value = this.Transporte.Destino;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Transporte.Nombre_compañia;
            command.Parameters.Add(new OracleParameter("id_tipo", OracleDbType.Int32)).Value = this.Transporte.Id_tipo_transporte;
            command.Parameters.Add(new OracleParameter("precio", OracleDbType.Int32)).Value = this.Transporte.Precio_por_persona;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Transporte.Id;

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

            string sql = "UPDATE TRANSPORTE SET habilitado=:habilitado WHERE id_transporte=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Transporte.Id_tipo_transporte;

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
