using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Apoderado
    {
        private int rut;
        private string dv_rut;
        private string nombre;
        private string ap_paterno;
        private string ap_materno;
        private string email;
        private int telefono;
        private int habilitado;

        public Apoderado()
        {
        }

        public Apoderado(int rut, string dv_rut, string nombre, string ap_paterno, string ap_materno, string email, int telefono, int habilitado)
        {
            this.Rut = rut;
            this.Dv_rut = dv_rut;
            this.Nombre = nombre;
            this.Ap_paterno = ap_paterno;
            this.Ap_materno = ap_materno;
            this.Email = email;
            this.Telefono = telefono;
            this.Habilitado = habilitado;
        }


        [Required(ErrorMessage = "El rut es obligatorio")]
        public int Rut { get => rut; set => rut = value; }

        [Required(ErrorMessage = "El digito verificador es obligatorio")]
        public string Dv_rut { get => dv_rut; set => dv_rut = value; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        public string Ap_paterno { get => ap_paterno; set => ap_paterno = value; }

        [Required(ErrorMessage = "El el apellido materno es obligatorio")]
        public string Ap_materno { get => ap_materno; set => ap_materno = value; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get => email; set => email = value; }

        public int Telefono { get => telefono; set => telefono = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }
    }
}
