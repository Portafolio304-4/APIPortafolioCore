using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "El nombre de usuario es obligatiorio")]
        [StringLength(80,MinimumLength = 5, ErrorMessage = "el nombre de usuario debe tener entre 5 y 80 caracteres")]
        public string Username { get => username; set => username = value; }

        [Required(ErrorMessage = "El email es obligatiorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato valido")]
        [StringLength(120, ErrorMessage = "El email es obligatiorio")]
        public string Email { get => email; set => email = value; }

        [JsonIgnore]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(80, ErrorMessage = "La contraseña puede tener como maximo 80 caracteres")]
        public string Contrasena { get => contrasena; set => contrasena = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "el tipo de usuario es obligatorio")]
        [Range(0,999, ErrorMessage = "El tipo de usuario es invalido")]
        public int Id_tipo_usuario { get => id_tipo_usuario; set => id_tipo_usuario = value; }

    }
}
