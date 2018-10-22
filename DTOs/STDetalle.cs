using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class STDetalle
    {
        private int id;
        private int id_actividad;
        private int id_servicio_turistico;
        private int id_transporte;
        private int id_estadia;
        private int id_seguro_viaje;

        public STDetalle()
        {
        }

        public STDetalle(int id, int id_actividad, int id_servicio_turistico, int id_transporte, int id_estadia, int id_seguro_viaje)
        {
            this.Id = id;
            this.Id_actividad = id_actividad;
            this.Id_servicio_turistico = id_servicio_turistico;
            this.Id_transporte = id_transporte;
            this.Id_estadia = id_estadia;
            this.Id_seguro_viaje = id_seguro_viaje;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "La actividad es obligatoria")]
        public int Id_actividad { get => id_actividad; set => id_actividad = value; }

        [Required(ErrorMessage = "El servicio turistico es obligatorio")]
        public int Id_servicio_turistico { get => id_servicio_turistico; set => id_servicio_turistico = value; }

        [Required(ErrorMessage = "El transporte obligatorio")]
        public int Id_transporte { get => id_transporte; set => id_transporte = value; }

        [Required(ErrorMessage = "La estadia es obligatoria")]
        public int Id_estadia { get => id_estadia; set => id_estadia = value; }

        public int Id_seguro_viaje { get => id_seguro_viaje; set => id_seguro_viaje = value; }
    }
}
