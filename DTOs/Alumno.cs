using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Alumno
    {
        private int rut;
        private string dv_rut;
        private string nombre;
        private string ap_paterno;
        private string ap_materno;
        private int habilitado;
        private int id_curso;

        public Alumno()
        {
        }

        public Alumno(int rut, string dv_rut, string nombre, string ap_paterno, string ap_materno, int habilitado, int id_curso)
        {
            this.Rut = rut;
            this.Dv_rut = dv_rut;
            this.Nombre = nombre;
            this.Ap_paterno = ap_paterno;
            this.Ap_materno = ap_materno;
            this.Habilitado = habilitado;
            this.Id_curso = id_curso;
        }

        [Required(ErrorMessage = "el rut es obligatorio")]
        public int Rut { get => rut; set => rut = value; }

        [Required(ErrorMessage = "el digito verificador es obligatorio")]
        public string Dv_rut { get => dv_rut; set => dv_rut = value; }

        [Required(ErrorMessage = "el nombre es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "el apellido paterno es obligatorio")]
        public string Ap_paterno { get => ap_paterno; set => ap_paterno = value; }

        [Required(ErrorMessage = "el apellido materno es obligatorio")]
        public string Ap_materno { get => ap_materno; set => ap_materno = value; }

        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "el curso es obligatorio")]
        public int Id_curso { get => id_curso; set => id_curso = value; }
    }
}
