using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CursoModel
    {
        private Conexion conn;
        private Curso curso;

        public CursoModel( Curso curso)
        {
            this.Curso = curso;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Curso Curso { get => curso; set => curso = value; }

        public List<Curso> GetCursos()
        {
            this.Conn = new Conexion();

            List<Curso> lista_curso = new List<Curso>();
            string sql = "SELECT * FROM CURSO WHERE habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string letra_curso = reader.GetString(1);
                int id_organizacion = reader.GetInt32(2);
                int habilitado = reader.GetInt32(3);

                Curso curso = new Curso(id, letra_curso, id_organizacion);
                lista_curso.Add(curso);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_curso;
        }

        public List<Curso> GetCursosByOrganizacion()
        {
            
            this.Conn = new Conexion();

            List<Curso> lista_curso = new List<Curso>();
            string sql = "SELECT * FROM CURSO WHERE habilitado=1 AND id_organizacion=:id_organizacion";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Curso.Id_organizacion;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string letra_curso = reader.GetString(1);
                int id_organizacion = reader.GetInt32(2);
                int habilitado = reader.GetInt32(3);

                Curso curso = new Curso(id, letra_curso, id_organizacion);
                lista_curso.Add(curso);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_curso;
        }

        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM CURSO WHERE id_curso=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.Curso.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.Curso.Id = reader.GetInt32(0);
                    this.Curso.Letra_curso = reader.GetString(1);
                    this.Curso.Id_organizacion = reader.GetInt32(2);
                    this.Curso.Habilitado = reader.GetInt32(3);

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

            string sql = "INSERT INTO CURSO " +
                "(letra_curso,id_organizacion)" +
                " VALUES" +
                "(:letra_curso,:id_organizacion)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("letra_curso", OracleDbType.Varchar2)).Value = this.Curso.Letra_curso;
            command.Parameters.Add(new OracleParameter("id_organizacion", OracleDbType.Varchar2)).Value = this.Curso.Id_organizacion;

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

            string sql = "UPDATE CURSO SET " +
                "letra_curso=:letra_curso " +
                "id_organizacion=:id_organizacion " +
                " WHERE id_curso=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("letra_curso", OracleDbType.Varchar2)).Value = this.Curso.Letra_curso;
            command.Parameters.Add(new OracleParameter("id_organizacion", OracleDbType.Varchar2)).Value = this.Curso.Id_organizacion;

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

            string sql = "UPDATE CURSO SET habilitado=:habilitado WHERE id_curso=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter(":habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = this.Curso.Id;

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
