using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    public class Diccionario
    {
        public static void Presentacion()
        {
            Dictionary<int, string> _EstadosMaxico = new Dictionary<int, string>();
            _EstadosMaxico.Add(1,"Aguascalientes");
            Estados estados = new Estados();
            MetEstados met=new MetEstados();
            string Opcion = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese la Opcion que desea realizar: ");
                Console.WriteLine("1.- Consultar todos los Estados dentro del Diccionario\n2.- Consultar un solo diccionario\n" +
                "3.- Agregar un nuevo Estado\n4.- Actualizar un Estado\n5.- Eliminar un Estado\n6.- Terminar");
                Opcion = Console.ReadLine();
                switch (Opcion)
                {
                    case "1":
                        Console.Clear();
                        MetEstados.ConsultAll(estados);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        MetEstados.ConstltEdo(estados);
                        Console.ReadKey();

                        break;
                    case "3":
                        Console.Clear();
                        MetEstados.AgregarEdo(estados);
                        Console.ReadKey();

                        break;
                    case "4":
                        Console.Clear();
                        MetEstados.ActualizarEdo(estados);
                        Console.ReadKey();

                        break;
                    case "5":
                        Console.Clear();
                        MetEstados.EliminEdo(estados);
                        Console.ReadKey();

                        break;
                }
            } while (Opcion!="6");
            
        }
    }
}
