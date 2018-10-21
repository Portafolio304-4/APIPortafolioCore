using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Actividad
    {
        private int id;
        private string nombre;
        private int precio;
        private int habilitado;
        private int id_tipo_actividad;

        public Actividad()
        {
        }

        public Actividad(int id, string nombre, int precio, int habilitado, int id_tipo_actividad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Habilitado = habilitado;
            this.Id_tipo_actividad = id_tipo_actividad;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public int Precio { get => precio; set => precio = value; }

        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "El tipo de actividad es obligatorio")]
        public int Id_tipo_actividad { get => id_tipo_actividad; set => id_tipo_actividad = value; }
    }
}
