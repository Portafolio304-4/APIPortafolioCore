﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class TipoPago
    {
        private int id;
        private string nombre;
        private int habilitado;

        public TipoPago()
        {
            this.id = -1;
            this.nombre = "";
            this.habilitado = 0;
        }

        public TipoPago(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = 1;
        }

        public TipoPago(int id, string nombre, int habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        [JsonIgnore]
        public int Habilitado { get => habilitado; set => habilitado = value; }
    }
}