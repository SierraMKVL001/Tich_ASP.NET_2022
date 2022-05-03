using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    public class MetEstados
    {
        private static Dictionary<int,string> _EstadosMaxico=new Dictionary<int, string>();
        //private static void CargarDatos(Estados estados)
        //{
        //        _EstadosMaxico[estados.ID]= $"{estados.Estado} con la clave {estados.Clave}";
        //}
        public static void ConsultAll(Estados estados)
        {
            //CargarDatos(estados);
            foreach (KeyValuePair<int,string>kvp in _EstadosMaxico)
            {
                Console.WriteLine($"La ID: {kvp.Key} corresponde al estado de {kvp.Value}");
            }
        }
        public static void ConstltEdo(Estados estados)
        {
            //CargarDatos(estados);
            Console.WriteLine("Ingrese el ID del estado que desea consultar");
            string termino=Console.ReadLine();
            int iTermino=Convert.ToInt32(termino);
            try
            {
                string definicion = _EstadosMaxico[iTermino];
                Console.WriteLine($"EL estado que corresponde al ID: {iTermino} es {definicion}");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Id no Encontrada dentro del Diccioario");
            }
        }
        public static void AgregarEdo(Estados estados)
        {
            //CargarDatos(estados);
            Console.WriteLine("Ingrese el ID del estado que desea Agergar");
            string idS = Console.ReadLine();
            estados.ID = Convert.ToInt32(idS);
            Console.WriteLine("Ingrese el Estado perteneciente al ID");
            estados.Estado = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Estado");
            estados.Clave = Console.ReadLine();
            try
            {
                _EstadosMaxico.Add(estados.ID, $"{estados.Estado} con la clave {estados.Clave}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void ActualizarEdo(Estados estados)
        {
            //CargarDatos(estados);
            Console.WriteLine("Ingrese el ID del estado que desea Editar");
            string idS = Console.ReadLine();
            estados.ID = Convert.ToInt32(idS);
            Console.WriteLine("Ingrese el Estado perteneciente al ID");
            estados.Estado = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Estado");
            estados.Clave = Console.ReadLine();

            _EstadosMaxico[estados.ID] = $"{estados.Estado} con la clave {estados.Clave}";

        }
        public static void EliminEdo(Estados estados)
        {
            //CargarDatos(estados);
            Console.WriteLine("Ingrese el ID del estado que desea borrar");
            string termino = Console.ReadLine();
            int iTermino = Convert.ToInt32(termino);
            if (!_EstadosMaxico.ContainsKey(iTermino))
            {
                Console.WriteLine("ID no encontrado");
            }
            else 
            { 
                _EstadosMaxico.Remove(iTermino); 
            }
        }
    }
}
