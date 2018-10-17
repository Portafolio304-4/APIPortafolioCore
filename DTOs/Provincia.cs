using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Provincia
    {
        private int id;
        private string nombre;
        private int habilitado;
        private int id_region;


        public Provincia()
        {
            this.Id = -1;
            this.Nombre = "";
            this.Habilitado = 0;
            this.Id_region = -1;
        }

        public Provincia(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;

        }

        public Provincia(int id, string nombre, int habilitado, int id_region)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Id_region = id_region;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El nombre es obligatiorio")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "el nombre debe tener entre 5 y 80 caracteres")]
        public string Nombre { get => nombre; set => nombre = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }

        [JsonIgnore]
        public int Id_region { get => id_region; set => id_region = value; }
    }
}
