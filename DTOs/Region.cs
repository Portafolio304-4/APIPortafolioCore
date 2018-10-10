﻿using Newtonsoft.Json;
using System;

namespace DTOs
{
    public class Region
    {
        private int id;
        private string nombre;
        private int habilitado;

        public Region()
        {
            this.id = -1;
            this.nombre = "";
            this.habilitado = 0;
        }

        public Region(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = 1;
        }

        public Region(int id, string nombre, int habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }

        [JsonRequired]
        public string Nombre { get => nombre; set => nombre = value; }
        
        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }
    }
}