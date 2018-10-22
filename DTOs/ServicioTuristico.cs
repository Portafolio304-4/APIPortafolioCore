using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class ServicioTuristico
    {
        private int id;
        private int precio;
        private string nombre;
        private string descripcion;

        public ServicioTuristico()
        {
            
        }

        public ServicioTuristico(int id, string nombre, string descripcion)
        {
            this.Id = id;
            this.Precio = 0;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public int Precio { get => precio; set => precio = value; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
