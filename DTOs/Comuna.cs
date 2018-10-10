using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class Comuna
    {
        private int id;
        private string nombre;
        private int habilitado;
        private int id_provincia;

        public Comuna()
        {
            this.Id = -1;
            this.Nombre = "";
            this.Habilitado = 0;
            this.Id_provincia = -1;
        }

        public Comuna(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;

        }

        public Comuna(int id, string nombre, int habilitado, int id_provincia)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Id_provincia = id_provincia;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }

        [JsonIgnore]
        public int Id_provincia { get => id_provincia; set => id_provincia = value; }
    }
}
