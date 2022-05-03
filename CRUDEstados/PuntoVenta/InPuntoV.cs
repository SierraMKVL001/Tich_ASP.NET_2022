using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class InPuntoV
    {
        public static void Presentacion()
        {
            string Opcion = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese la Opcion que desea realizar: ");
                Console.WriteLine("V.- Iniciar Nueva Venta\nT.- Terminar\n");
                Opcion = Console.ReadLine();
                switch (Opcion.ToUpper())
                {
                    case "V":
                        Console.Clear();
                        GenVentas.NuevaVenta();
                        Console.ReadKey();
                        break;
                    case "T":
                        Console.Clear();
                        GenVentas.ImpArtAll();
                        Console.ReadKey();
                        break;
                }
            } while (Opcion.ToUpper() != "T");
        }
    }
}
