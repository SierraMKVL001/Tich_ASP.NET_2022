using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Cuadrado : IFigura
    {
        
        public double Lado { get; set; }
        public Cuadrado(double lado)
        {
            Lado = lado;
        }
        public string Area()
        {
            double Area = Lado*Lado;
            string sA = $"El Area del rectangulo es {Area}";
            return sA;
        }

        public string Perimetro()
        {
            double Perimetro = (Lado * 4);
            string sP = $"El perimetro del rectangulo es {Perimetro}";
            return sP;
        }
    }
}
