using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Transporte
    {
        private int id;
        private string origen;
        private string destino;
        private string nombre_compañia;
        private int precio_por_persona;
        private int habilitado;
        private int id_tipo_transporte;

        public Transporte()
        {
        }

        public Transporte(int id, string origen, string destino, string nombre_compañia, int precio_por_persona, int habilitado, int id_tipo_transporte)
        {
            this.Id = id;
            this.Origen = origen;
            this.Destino = destino;
            this.Nombre_compañia = nombre_compañia;
            this.Precio_por_persona = precio_por_persona;
            this.Habilitado = habilitado;
            this.Id_tipo_transporte = id_tipo_transporte;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El origen es obligatorio")]
        public string Origen { get => origen; set => origen = value; }

        [Required(ErrorMessage = "El destino es obligatorio")]
        public string Destino { get => destino; set => destino = value; }

        [Required(ErrorMessage = "El nombre de compañia es obligatorio")]
        public string Nombre_compañia { get => nombre_compañia; set => nombre_compañia = value; }

        [Required(ErrorMessage = "El precio por persona es obligatorio")]
        public int Precio_por_persona { get => precio_por_persona; set => precio_por_persona = value; }

        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "El tipo de transporte es obligatorio")]
        public int Id_tipo_transporte { get => id_tipo_transporte; set => id_tipo_transporte = value; }
    }
}
