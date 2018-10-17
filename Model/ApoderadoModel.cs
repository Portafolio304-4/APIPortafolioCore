using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApoderadoModel
    {
        private Conexion conn;
        private Apoderado apoderado;

        public ApoderadoModel(Apoderado apoderado)
        { 
            this.Apoderado = apoderado;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Apoderado Apoderado { get => apoderado; set => apoderado = value; }

        public List<Apoderado> GetApoderados()
        {
            this.Conn = new Conexion();

            List<Apoderado> lista_apoderado = new List<Apoderado>();
            string sql = "SELECT * FROM APODERADO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int rut = reader.GetInt32(0);
                string dv_rut = reader.GetString(1);
                string nombre = reader.GetString(2);
                string ap_paterno = reader.GetString(3);
                string ap_materno = reader.GetString(4);
                string email = reader.GetString(5);
                int telefono = reader.GetInt32(6);
                int habilitado = reader.GetInt32(7);

                Apoderado apoderado = new Apoderado(rut,dv_rut,nombre,ap_materno,ap_materno,email,telefono,habilitado);
                lista_apoderado.Add(apoderado);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_apoderado;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM APODERADO WHERE rut_apoderado=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Apoderado.Rut;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Apoderado.Rut = reader.GetInt32(0);
                    this.Apoderado.Dv_rut = reader.GetString(1);
                    this.Apoderado.Nombre = reader.GetString(2);
                    this.Apoderado.Ap_paterno = reader.GetString(3);
                    this.Apoderado.Ap_materno = reader.GetString(4);
                    this.Apoderado.Email = reader.GetString(5);
                    this.Apoderado.Telefono = reader.GetInt32(6);
                    this.Apoderado.Habilitado = reader.GetInt32(7);

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

            string sql = "INSERT INTO APODERADO " +
                "(rut_apoderado,rut_dv_apoderado,nombre_apoderado,ap_pat_apoderado,ap_mat_apoderado,email_apoderado,telefono_apoderado)" +
                " VALUES" +
                "(:rut,:rut_dv,:nombre,:ap_paterno,:ap_materno,:email,:telefono)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Varchar2)).Value = this.Apoderado.Rut;
            command.Parameters.Add(new OracleParameter("rut_dv", OracleDbType.Varchar2)).Value = this.Apoderado.Dv_rut;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Apoderado.Nombre;
            command.Parameters.Add(new OracleParameter("ap_paterno", OracleDbType.Varchar2)).Value = this.Apoderado.Ap_paterno;
            command.Parameters.Add(new OracleParameter("ap_materno", OracleDbType.Varchar2)).Value = this.Apoderado.Ap_materno;
            command.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2)).Value = this.Apoderado.Email;
            command.Parameters.Add(new OracleParameter("telefono", OracleDbType.Varchar2)).Value = this.Apoderado.Telefono;

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

            string sql = "UPDATE APODERADO SET " +
                "rut_apoderado=:rut " +
                "rut_dv_apoderado=:rut_dv " +
                "nombre_apoderado=:nombre " +
                "ap_pat_apoderado=:ap_paterno " +
                "ap_mat_apoderado=:ap_materno " +
                "email_apoderado=:email " +
                "telefono_apoderado=:telefono " +
                " WHERE rut_apoderado=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Varchar2)).Value = this.Apoderado.Rut;
            command.Parameters.Add(new OracleParameter("rut_dv", OracleDbType.Varchar2)).Value = this.Apoderado.Dv_rut;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Apoderado.Nombre;
            command.Parameters.Add(new OracleParameter("ap_paterno", OracleDbType.Varchar2)).Value = this.Apoderado.Ap_paterno;
            command.Parameters.Add(new OracleParameter("ap_materno", OracleDbType.Varchar2)).Value = this.Apoderado.Ap_materno;
            command.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2)).Value = this.Apoderado.Email;
            command.Parameters.Add(new OracleParameter("telefono", OracleDbType.Varchar2)).Value = this.Apoderado.Telefono;
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

            string sql = "UPDATE APODERADO SET habilitado=:habilitado WHERE rut_apoderado=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Apoderado.Rut;

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
