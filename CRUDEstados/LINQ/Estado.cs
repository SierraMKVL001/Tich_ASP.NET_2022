﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public struct Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estado(int id,string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
