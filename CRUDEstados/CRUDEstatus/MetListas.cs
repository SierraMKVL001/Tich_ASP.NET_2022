using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class MetListas
    {
        private static List<EstatusAlumnos> _Estatus = new List<EstatusAlumnos>();
        public static void ConsultAll(EstatusAlumnos estados)
        {
            Console.WriteLine($"ID\t\tNombre\t\tClave\t\t");
            foreach (var oEstatus in _Estatus)
            {
                Console.WriteLine($"{oEstatus.ID}\t\t{oEstatus.Nombre}\t\t{oEstatus.Clave}");
            }
        }
        public static void ConstltEdo(EstatusAlumnos estados)
        {
            Console.WriteLine("Ingrese el ID del Estatus que desea consultar");
            string termino = Console.ReadLine();
            estados.ID = Convert.ToInt32(termino);
            Console.WriteLine($"ID\t\tNombre\t\tClave\t\t");
            try
            {
                var element = _Estatus.FirstOrDefault(i => i.ID == estados.ID);
                Console.WriteLine($"{element.ID}\t\t{element.Nombre}\t\t{element.Clave}");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Id no Encontrada dentro del Diccioario");
            }
        }
        public static void AgregarEdo(EstatusAlumnos estados)
        {
            Console.WriteLine("Ingrese el ID del Curso que desea Agergar");
            string idS = Console.ReadLine();
            estados.ID = Convert.ToInt32(idS);
            Console.WriteLine("Ingrese el Nombre del Curso");
            estados.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Curso");
            estados.Clave = Console.ReadLine();
            _Estatus.Add(estados);

        }
        public static void ActualizarEdo(EstatusAlumnos estados)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del estado que desea Editar");
            string idS = Console.ReadLine();
            int nID = Convert.ToInt32(idS);
            Console.WriteLine("Ingrese el Nuevo Estatus");
            string nEdo = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Estado");
            string NCla = Console.ReadLine();
            var replaceItem = new EstatusAlumnos { ID=nID, Nombre=nEdo,Clave=NCla};
            var element = _Estatus.FirstOrDefault(i => i.ID == replaceItem.ID);
            _Estatus.Remove(element);
            _Estatus.Add(replaceItem);

        }
        public static void EliminEdo(EstatusAlumnos estados)
        {
            Console.WriteLine("Ingrese el ID del Estatus que desea Eliminar");
            string idS = Console.ReadLine();
            estados.ID = Convert.ToInt32(idS);
            _Estatus.RemoveAt(estados.ID-1);
        }
    }

}
