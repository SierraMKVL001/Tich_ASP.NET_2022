using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Triangulo : IFigura
    {
        public double Base { get; set; }
        public double Lado { get; set; }
        public Triangulo(double base1,double lado)
        {
            Base = base1;
            Lado = lado;
        }


        public string Area()
        {
            double Altura = ((Math.Pow(Lado,2))-((Math.Pow(Base,2)/4)));
            double Area = 0.5 * Base*Altura;
            string sA=$"El Area del rectangulo es {Area}";
            return sA;
        }

        public string Perimetro()
        {
            double Perimetro=(Lado*2)+Base;
            string sP=$"El perimetro del rectangulo es {Perimetro}";
            return sP;
        }
    }
}
