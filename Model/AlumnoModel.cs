using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AlumnoModel
    {
        private Conexion conn;
        private Alumno alumno;

        public AlumnoModel(Alumno alumno)
        {
            this.Alumno = alumno;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Alumno Alumno { get => alumno; set => alumno = value; }

        public List<Alumno> GetAlumnos()
        {
            this.Conn = new Conexion();

            List<Alumno> lista_alumno = new List<Alumno>();
            string sql = "SELECT * FROM ALUMNO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int rut = reader.GetInt32(0);
                string dv_rut = reader.GetString(1);
                string nombre = reader.GetString(1);
                string apellido_paterno = reader.GetString(2);
                string apellido_materno = reader.GetString(3);
                int id_curso = reader.GetInt32(4);
                int habilitado = reader.GetInt32(5);

                Alumno alumno = new Alumno(rut, dv_rut, nombre, apellido_paterno, apellido_materno, habilitado, id_curso);
                lista_alumno.Add(alumno);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_alumno;
        }

        public List<Alumno> GetAlumnosByCurso()
        {

            this.Conn = new Conexion();

            List<Alumno> lista_alumno = new List<Alumno>();
            string sql = "SELECT * FROM ALUMNO WHERE habilitado=1 AND id_curso=:id_curso";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Alumno.Id_curso;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int rut = reader.GetInt32(0);
                string dv_rut = reader.GetString(1);
                string nombre = reader.GetString(1);
                string apellido_paterno = reader.GetString(2);
                string apellido_materno = reader.GetString(3);
                int id_curso = reader.GetInt32(4);
                int habilitado = reader.GetInt32(5);

                Alumno alumno = new Alumno(rut, dv_rut, nombre, apellido_paterno, apellido_materno, habilitado, id_curso);
                lista_alumno.Add(alumno);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_alumno;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM ALUMNO WHERE rut_alumno=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Alumno.Rut;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Alumno.Rut = reader.GetInt32(0);
                    this.Alumno.Dv_rut = reader.GetString(1);
                    this.Alumno.Nombre = reader.GetString(2);
                    this.Alumno.Ap_paterno = reader.GetString(3);
                    this.Alumno.Ap_materno = reader.GetString(4);
                    this.Alumno.Id_curso = reader.GetInt32(5);
                    this.Alumno.Habilitado = reader.GetInt32(6);

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

            string sql = "INSERT INTO ALUMNO " +
                "(rut_alumno,rut_dv_alumno,nombre_alumno,ap_pat_alumno,ap_mat_alumno,id_curso)" +
                " VALUES" +
                "(:rut,:dv_rut,:nombre,:ap_paterno,:ap_materno,:id_curso)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Varchar2)).Value = this.Alumno.Rut;
            command.Parameters.Add(new OracleParameter("dv_rut", OracleDbType.Varchar2)).Value = this.Alumno.Dv_rut;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Alumno.Nombre;
            command.Parameters.Add(new OracleParameter("ap_paterno", OracleDbType.Varchar2)).Value = this.Alumno.Ap_paterno;
            command.Parameters.Add(new OracleParameter("ap_materno", OracleDbType.Varchar2)).Value = this.Alumno.Ap_materno;
            command.Parameters.Add(new OracleParameter("id_curso", OracleDbType.Varchar2)).Value = this.Alumno.Id_curso;

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

            string sql = "UPDATE ALUMNO SET " +
                "rut_alumno=:rut " +
                "rut_dv_alumno=:dv_rut " +
                "nombre_alumno=:nombre " +
                "ap_pat_alumno=:ap_paterno " +
                "ap_mat_alumno=:ap_materno " +
                "id_curso=:id_curso " +
                " WHERE rut_alumno=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Varchar2)).Value = this.Alumno.Rut;
            command.Parameters.Add(new OracleParameter("dv_rut", OracleDbType.Varchar2)).Value = this.Alumno.Dv_rut;
            command.Parameters.Add(new OracleParameter("nombre", OracleDbType.Varchar2)).Value = this.Alumno.Nombre;
            command.Parameters.Add(new OracleParameter("ap_paterno", OracleDbType.Varchar2)).Value = this.Alumno.Ap_paterno;
            command.Parameters.Add(new OracleParameter("ap_materno", OracleDbType.Varchar2)).Value = this.Alumno.Ap_materno;
            command.Parameters.Add(new OracleParameter("id_curso", OracleDbType.Varchar2)).Value = this.Alumno.Id_curso;

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

            string sql = "UPDATE ALUMNO SET habilitado=:habilitado WHERE rut_alumno=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Alumno.Rut;

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
