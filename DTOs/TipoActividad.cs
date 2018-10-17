using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class TipoActividad
    {
        private int id;
        private string nombre;
        private int habilitado;

        public TipoActividad()
        {
            this.id = -1;
            this.nombre = "";
            this.habilitado = 0;
        }

        public TipoActividad(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = 1;
        }

        public TipoActividad(int id, string nombre, int habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El nombre es obligatiorio")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "el nombre debe tener entre 5 y 80 caracteres")]
        public string Nombre { get => nombre; set => nombre = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }
    }
}
