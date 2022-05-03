using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        //public IFigura[,] Figura;
        static void Main(string[] mklv)
        {
            IFigura[] figuras = new IFigura[2] { new Cuadrado(5), new Triangulo(2,5) };
            foreach (var item in figuras)
            {
                Console.WriteLine(item.Area()+" "+item.Perimetro());
                
            }
            Console.ReadKey();
        }
    }
}
