using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLEstausAlumnos
{
    public class MenuP
    {
        public static void Presentacion()
        {
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
                        MetSQL.ConsultAll();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        MetSQL.ConstltEdo();
                        Console.ReadKey();

                        break;
                    case "3":
                        Console.Clear();
                        MetSQL.AgregarEdo();
                        Console.ReadKey();

                        break;
                    case "4":
                        Console.Clear();
                        MetSQL.ActualizarEdo();
                        Console.ReadKey();

                        break;
                    case "5":
                        Console.Clear();
                        MetSQL.EliminEdo();
                        Console.ReadKey();

                        break;
                }
            } while (Opcion != "6");
        }
    }
}
