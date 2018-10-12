using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class Usuario
    {
        private int id;
        private string username;
        private string email;
        private string contrasena;
        private int habilitado;
        private int id_tipo_usuario;

        public Usuario()
        {
            this.Id = -1;
            this.Username = "";
            this.Email = "";
            this.Contrasena = "";
            this.Habilitado = 0;
            this.Id_tipo_usuario = -1;
        }

        public Usuario(int id, string username, string email, string contrasena, int id_tipo_usuario)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Contrasena = contrasena;
            this.Habilitado = 1;
            this.Id_tipo_usuario = id_tipo_usuario;
        }

        public Usuario(int id, string username, string email, string contrasena, int habilitado, int id_tipo_usuario)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Contrasena = contrasena;
            this.Habilitado = habilitado;
            this.Id_tipo_usuario = id_tipo_usuario;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int Habilitado { get => habilitado; set => habilitado = value; }
        public int Id_tipo_usuario { get => id_tipo_usuario; set => id_tipo_usuario = value; }
    }
}
