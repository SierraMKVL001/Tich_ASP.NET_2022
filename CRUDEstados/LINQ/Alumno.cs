using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public struct Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Calificacion { get; set; }
        public int IdEstado { get; set; }
        public int IdEstatus { get; set; }
        public Alumno(int id,string nombre,int calificacion,int idEstado,int idEstatus)
        {
            ID = id;
            Nombre = nombre;
            Calificacion = calificacion;
            IdEstado = idEstado;
            IdEstatus = idEstatus;
        }
    }
}
