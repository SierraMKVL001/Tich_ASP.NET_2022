using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public struct Estatus
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Estatus(int id,string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
    }
}
