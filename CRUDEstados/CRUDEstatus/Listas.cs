using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Listas
    {
        public static void Presentacion()
        {
            EstatusAlumnos estados = new EstatusAlumnos();
            string Opcion = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese la Opcion que desea realizar: ");
                Console.WriteLine("1.- Consultar Todos\n2.- Consultar Solo uno\n" +
                "3.- Agregar\n4.- Actualizar\n5.- Eliminar\n6.- Terminar");
                Opcion = Console.ReadLine();
                switch (Opcion)
                {
                    case "1":
                        Console.Clear();
                        MetListas.ConsultAll(estados);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        MetListas.ConstltEdo(estados);
                        Console.ReadKey();

                        break;
                    case "3":
                        Console.Clear();
                        MetListas.AgregarEdo(estados);
                        Console.ReadKey();

                        break;
                    case "4":
                        Console.Clear();
                        MetListas.ActualizarEdo(estados);
                        Console.ReadKey();

                        break;
                    case "5":
                        Console.Clear();
                        MetListas.EliminEdo(estados);
                        Console.ReadKey();

                        break;
                }
            } while (Opcion != "6");
        }
    }
}
