using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PuntoVenta
{
    internal class GenVentas
    {
        private static List<Articulo> _Articulo = new List<Articulo>();
        private static List<ItemBase> _ItemsVNT = new List<ItemBase>();
        private static List<ItemBase> _ItemsVNTCat = new List<ItemBase>();


        public static void CargarItems()
        {
            string archivoET = @"C:\Users\Tichs\Downloads\Articulos.json";
            StreamReader jsonStreamET = new StreamReader(archivoET);
            var jsonET = jsonStreamET.ReadToEnd();
            jsonStreamET.Close();
            _Articulo = JsonConvert.DeserializeObject<List<Articulo>>(jsonET);
            Console.WriteLine($"ID\tNombre\t\tPrecio\tTipo\t");
            foreach (Articulo articulo in _Articulo)
            {
                Console.WriteLine($"{articulo.ID}\t{articulo.Nombre}\t\t{articulo.Precio}\t{articulo.Tipo}");
            }
        }
        public static void NuevaVenta()
        {
            Articulo artiDo = new Articulo();
            string Opcion = "";
            do {
                Console.Clear();
                CargarItems();
                Console.WriteLine($"Ingrese el ID del Articulo:");
                string Sid = Console.ReadLine();
                int Nid = Convert.ToInt32(Sid);
                Console.WriteLine($"Ingrese la Cantidad del Articulo:");
                string SCant = Console.ReadLine();
                int NCant = Convert.ToInt32(SCant);
                artiDo = ObtenArt(Nid);
                if (artiDo.Tipo==1)
                {
                    AgregarIT1(artiDo,NCant);
                }else if (artiDo.Tipo==2)
                {
                    AgregarIT2(artiDo,NCant);
                }else if (artiDo.Tipo == 3)
                {
                    AgregarIT3(artiDo,NCant);
                }
                Console.WriteLine("Dese Ingresar un Nuevo Articulo? (TV=NO)");
                Opcion = Console.ReadLine();
            } while (Opcion.ToUpper()!="TV");
            ImpArticulos();
            _ItemsVNTCat.Clear();
            

        }
        public static Articulo ObtenArt(int idO)
        {

            decimal Precio = 0;
            string nombre = "";
            int tipo=0;

            var datos = from dART in _Articulo
                        select dART;
            foreach (var l in datos)
            {
                if ((l.ID==idO))
                {
                    Precio = l.Precio;
                    nombre = l.Nombre;
                    tipo = l.Tipo;
                }
            }
            Articulo iArt = new Articulo(idO,nombre,Precio,tipo);
            return iArt;
        }
        public static void AgregarIT1(Articulo art,int cant)
        {
            Item item=new Item(art.ID,art.Nombre,art.Precio,cant);
            _ItemsVNT.Add(item);
            _ItemsVNTCat.Add(item);
        }
        public static void AgregarIT2(Articulo art,int cant)
        {
            Console.WriteLine($"Ingrese el descuente que se realizara :");
            string Sdes = Console.ReadLine();
            decimal NDes=Convert.ToDecimal(Sdes);
            ItemDescuento descuento=new ItemDescuento(art.ID, art.Nombre, art.Precio, cant,NDes);
            _ItemsVNT.Add(descuento);
            _ItemsVNTCat.Add(descuento);
        }
        public static void AgregarIT3(Articulo art,int cant)
        {
            Console.WriteLine($"Ingrese el Numero del Telefono:");
            string Ntel = Console.ReadLine();
            Console.WriteLine($"Ingrese la Compañia telefonica:");
            string Ncomp = Console.ReadLine();
            ItemTA itemTA = new ItemTA(art.ID, art.Nombre, art.Precio,cant,Ntel,Ncomp);
            _ItemsVNT.Add(itemTA);
            _ItemsVNTCat.Add(itemTA);
        }
        public static void ImpArticulos()
        {
            decimal N = 0;
            foreach (var item in _ItemsVNTCat)
            {
                Console.WriteLine($"{item.Imprimir()}");
                N = N + item.Total();
            }
            Console.WriteLine($"Total a pagar: {N}");
        }
        public static void ImpArtAll()
        {
            decimal N = 0;
            foreach (var item in _ItemsVNT)
            {
                Console.WriteLine($"{item.Imprimir()}");
                N =N+ item.Total();
            }
            Console.WriteLine($"Total de ingresos del Dia: {N}");
        }
    }
}
