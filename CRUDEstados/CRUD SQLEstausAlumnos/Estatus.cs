using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLEstausAlumnos
{
    public struct Estatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public Estatus(int id,string nombre,string clave)
        {
            Id = id;
            Nombre = nombre;
            Clave = clave;
        }
    }
}
