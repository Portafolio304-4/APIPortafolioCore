using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Organizacion
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        private int habilitado;
        private int id_comuna;
        private int id_tipo_organizacion;

        public Organizacion()
        {
            
        }

        public Organizacion(int id, string nombre, string direccion, int telefono, int id_comuna, int id_tipo_organizacion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Id_comuna = id_comuna;
            this.Id_tipo_organizacion = id_tipo_organizacion;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80,ErrorMessage = "el nombre puede tener como maximo 80 caracteres")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El la direccion es obligatoria")]
        [StringLength(80, ErrorMessage = "la direccion puede tener como maximo 80 caracteres")]
        public string Direccion { get => direccion; set => direccion = value; }

       
        public int Telefono { get => telefono; set => telefono = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "La comuna es obligatioria")]
        public int Id_comuna { get => id_comuna; set => id_comuna = value; }

        [Required(ErrorMessage = "El tipo de organizacion es obligatiorio")]
        public int Id_tipo_organizacion { get => id_tipo_organizacion; set => id_tipo_organizacion = value; }
    }
}
