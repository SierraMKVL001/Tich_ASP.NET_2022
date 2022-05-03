using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    public struct EstatusAlumnos
    {
        public int ID { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        EstatusAlumnos(int id,string clave,string nombre)
        {
            ID = id; 
            Clave = clave; 
            Nombre = nombre; 
        }
    }
}
