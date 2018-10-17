using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class Curso
    {
        private int id;
        private string letra_curso;
        private int habilitado;
        private int id_organizacion;

        public Curso()
        {
            
        }

        public Curso(int id, string letra_curso, int id_organizacion)
        {
            this.Id = id;
            this.Letra_curso = letra_curso;
            this.Id_organizacion = id_organizacion;
        }

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "la sigla del curso es obligatioria")]
        public string Letra_curso { get => letra_curso; set => letra_curso = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }

        [Required(ErrorMessage = "el tipo de organizacion es obligatorio")]
        public int Id_organizacion { get => id_organizacion; set => id_organizacion = value; }
    }
}
