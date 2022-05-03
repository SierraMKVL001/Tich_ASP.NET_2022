using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    public struct Estados {
        public int ID { get; set; }
        public string Estado { get; set; }
        public string Clave { get; set; }
        public Estados(int id,string estado,string clave) {
            ID = id;
            Estado = estado;
            Clave = clave;
        }
    }

}
