using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public struct Articulo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Tipo { get; set; }
        public Articulo(int id,string nombre,decimal precio,int tipo)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Tipo = tipo;
        }
    }
}
