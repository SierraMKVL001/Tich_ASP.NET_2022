using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public struct ISRResult
    {
        public decimal Excedente { get; set; }
        public decimal Impuesto { get; set; }

        public ISRResult(decimal excedente,decimal impuesto)
        {
            Excedente = excedente;
            Impuesto = impuesto;
        }
    }
}
