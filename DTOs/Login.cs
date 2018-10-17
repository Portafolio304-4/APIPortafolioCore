using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class Login
    {
        private string username;
        private string contrasena;

        public Login(string username, string contrasena)
        {
            this.Username = username;
            this.Contrasena = contrasena;
        }

        public string Username { get => username; set => username = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
