using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UsuarioModel
    {
        // agregar conexion como atributo
        private Conexion conn;
        // agregar objeto de plantilla
        private Usuario usuario;

        public UsuarioModel(Usuario usuario)
        {
            this.Usuario = usuario;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }

        public List<Usuario> GetUsuarios()
        {
            // Crear lista de objetos a devolver
            List<Usuario> lista_usuarios = new List<Usuario>();
            // inicializar conexion
            this.Conn = new Conexion();
            // definir query
            string sql = "SELECT * FROM USUARIO WHERE habilitado=1";
            // definir objeto que ejecutara el comando
            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            // definir objeto de lectura para el retorno de la query
            OracleDataReader reader = command.ExecuteReader();
            // recorrer reader
            while (reader.Read())
            {
                string username = reader.GetString(0);
                string contrasena = reader.GetString(1);
                int id_tipo_usuario = reader.GetInt32(2);
                int habilitado = reader.GetInt32(3);
                int id_usuario = reader.GetInt32(4);
                string email = reader.GetString(5);

                Usuario usuario = new Usuario(id_usuario, username, email, contrasena, habilitado, id_tipo_usuario);

                lista_usuarios.Add(usuario);
            }

            return lista_usuarios;
        }

        public bool ReadById()
        {
            bool found = false;
            // generar conexion
            this.Conn = new Conexion();
            // definir query con parametros variables
            string sql = "SELECT * FROM USUARIO WHERE id_usuario=:id";
            // generar objeto de comando
            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            // rellenar parametros variables de la query
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = usuario.Id;
            OracleDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                found = true;
                while (reader.Read())
                {
                    
                    usuario.Username = reader.GetString(0);
                    usuario.Contrasena = reader.GetString(1);
                    usuario.Id_tipo_usuario = reader.GetInt32(2);
                    usuario.Habilitado = reader.GetInt32(3);
                    usuario.Id = reader.GetInt32(4);
                    usuario.Email = reader.GetString(5);

                }
            }
            
            return found;
        }

        public bool ReadByUsername()
        {
            bool found = false;
            // generar conexion
            this.Conn = new Conexion();
            // definir query con parametros variables
            string sql = "SELECT * FROM USUARIO WHERE username=:username AND habilitado=1";
            // generar objeto de comando
            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            // rellenar parametros variables de la query
            command.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = usuario.Username;
            OracleDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                found = true;
                while (reader.Read())
                {

                    usuario.Username = reader.GetString(0);
                    usuario.Contrasena = reader.GetString(1);
                    usuario.Id_tipo_usuario = reader.GetInt32(2);
                    usuario.Habilitado = reader.GetInt32(3);
                    usuario.Id = reader.GetInt32(4);
                    usuario.Email = reader.GetString(5);

                }
            }

            return found;
        }

        public bool Create()
        {
            bool created = false;
            // generar conexion
            this.Conn = new Conexion();
            // definir query con parametros variables

            if (!this.ReadByUsername())
            {

                string sql = "INSERT INTO USUARIO(username,contrasena,id_tipo_usuario,email)" +
                    " VALUES(:username,:contrasena,:id_tipo_usuario,:email)";
                // generar objeto de comando
                OracleCommand command = new OracleCommand(sql, this.Conn.Connection);

                // encyptar contraseña
                usuario.Contrasena = Seguridad.Encriptar(usuario.Contrasena);

                // rellenar parametros variables de la query
                command.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = usuario.Username;
                command.Parameters.Add(new OracleParameter("contrasena", OracleDbType.Varchar2)).Value = usuario.Contrasena;
                command.Parameters.Add(new OracleParameter("id_tipo_usuario", OracleDbType.Int32)).Value = usuario.Id_tipo_usuario;
                command.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2)).Value = usuario.Email;

                try
                {
                    int rowsUpdate = command.ExecuteNonQuery();
                    if (rowsUpdate > 0)
                        created = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return created;
        }

        public bool Update()
        {
            bool updated = false;
            // generar conexion
            this.Conn = new Conexion();
            // definir query con parametros variables
            string sql = "UPDATE USUARIO SET contrasena=:contrasena WHERE id_usuario=:id AND habilitado=1";
            // generar objeto de comando
            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);

            // encyptar contraseña
            usuario.Contrasena = Seguridad.Encriptar(usuario.Contrasena);

            // rellenar parametros variables de la query
            command.Parameters.Add(new OracleParameter("contrasena", OracleDbType.Varchar2)).Value = usuario.Contrasena;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = usuario.Id;

            try
            {
                int rowsUpdate = command.ExecuteNonQuery();
                if (rowsUpdate > 0)
                    updated = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return updated;
        }

        public bool Delete()
        {
            bool deleted = false;
            // generar conexion
            this.Conn = new Conexion();
            // definir query con parametros variables
            string sql = "UPDATE USUARIO SET habilitado=:habilitado WHERE id_usuario=:id";
            // generar objeto de comando
            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            // rellenar parametros variables de la query
            command.Parameters.Add(new OracleParameter("habilitado", OracleDbType.Int32)).Value = 0;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = usuario.Id;

            try
            {
                int rowsUpdate = command.ExecuteNonQuery();
                if (rowsUpdate > 0)
                    deleted = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return deleted;
        }

    }
}
