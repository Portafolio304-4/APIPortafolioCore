using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Estadia
    {
        private int id;
        private string nombre;
        private string pais_estadia;
        private string ciudad_estadia;
        private int precio_por_persona;
        private int habilitado;
        private int id_tipo_estadia;

        public Estadia()
        {
        }

        public Estadia(int id, string nombre, string pais_estadia, string ciudad_estadia, int precio_por_persona, int habilitado, int id_tipo_estadia)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Pais_estadia = pais_estadia;
            this.Ciudad_estadia = ciudad_estadia;
            this.Precio_por_persona = precio_por_persona;
            this.Habilitado = habilitado;
            this.Id_tipo_estadia = id_tipo_estadia;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El pais es obligatorio")]
        public string Pais_estadia { get => pais_estadia; set => pais_estadia = value; }

        [Required(ErrorMessage = "la ciudad es obligatoria")]
        public string Ciudad_estadia { get => ciudad_estadia; set => ciudad_estadia = value; }

        [Required(ErrorMessage = "El precio por persona es obligatorio")]
        public int Precio_por_persona { get => precio_por_persona; set => precio_por_persona = value; }

        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "El tipo de estadia es obligatorio")]
        public int Id_tipo_estadia { get => id_tipo_estadia; set => id_tipo_estadia = value; }
    }
}
