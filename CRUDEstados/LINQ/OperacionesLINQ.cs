using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LINQ
{
    internal class OperacionesLINQ
    {
        private ItemISR iSR=new ItemISR();
        private static List<ItemISR> _ISR = new List<ItemISR>();
        private static List<Alumno> _Alm=new List<Alumno>();
        private static List<Estatus> _Estatus=new List<Estatus>();
        private static List<Estado> _Estado=new List<Estado>();
        public static void CargarLists()
        {
            string archivo = @"C:\Users\Tichs\Downloads\Alumnos.json";
            StreamReader jsonStream = new StreamReader(archivo);
            var json = jsonStream.ReadToEnd();
            jsonStream.Close();
            _Alm = JsonConvert.DeserializeObject<List<Alumno>>(json);

            string archivoES = @"C:\Users\Tichs\Downloads\Estados.json";
            StreamReader jsonStreamES = new StreamReader(archivoES);
            var jsonES = jsonStreamES.ReadToEnd();
            jsonStreamES.Close();
            _Estado = JsonConvert.DeserializeObject<List<Estado>>(jsonES);

            string archivoET = @"C:\Users\Tichs\Downloads\Alumnos.json";
            StreamReader jsonStreamET = new StreamReader(archivoET);
            var jsonET = jsonStreamET.ReadToEnd();
            jsonStreamET.Close();
            _Estatus = JsonConvert.DeserializeObject<List<Estatus>>(jsonET);

            string archivoISR = @"C:\Users\Tichs\OneDrive\Escritorio\TablaISR.csv";
            StreamReader sr = new StreamReader(archivoISR);
            while (!sr.EndOfStream)
            {
                string[] vs = sr.ReadLine().Split(',');
                ItemISR ISR=new ItemISR();
                ISR.LimInf = Convert.ToDecimal(vs[0]);
                ISR.LimSup = Convert.ToDecimal(vs[1]);
                ISR.CuotaFija = Convert.ToDecimal(vs[2]);
                ISR.PorExced= Convert.ToDecimal(vs[3]);
                ISR.Subsidio= Convert.ToDecimal(vs[4]);
                _ISR.Add(ISR);
            }
            sr.Close();
        }
        public static void Consultas() 
        {
            ISRResult ISR = new ISRResult();
            ItemISR IISR = new ItemISR();
            IEnumerable<Estado> resultado =from estado in _Estado
                          where estado.Id == 5
                          select estado;
            Console.WriteLine($"ID\tNombre del Estado\t");
            foreach (Estado i in resultado)
            {
                Console.WriteLine($"{i.Id}\t{i.Nombre}");
            }
            var alumVT=from Alumno in _Alm
                       where Alumno.IdEstado>=13&&Alumno.IdEstado<29
                       select Alumno;
            Console.WriteLine($"ID\tNombre del Alumno");
            foreach (var i in alumVT)
            {
                Console.WriteLine($"{i.ID}\t{i.Nombre}");
            }
            var alumDV = from Alumno in _Alm
                         where (Alumno.IdEstado >= 19 && Alumno.IdEstado < 20)&&(Alumno.IdEstatus>=4 && Alumno.IdEstatus<=5)
                         select Alumno;
            Console.WriteLine($"ID\tNombre del Alumno\t\tIdEstatus");
            foreach (var i in alumDV)
            {
                Console.WriteLine($"{i.ID}\t{i.Nombre}\t{i.IdEstatus}");
            }
            var almAp= from alumno in _Alm
                        where alumno.Calificacion >= 6
                        orderby alumno.Calificacion descending
                        select alumno;
            Console.WriteLine($"ID\tNombre del Alumno\tCalificacion");
            foreach (var i in almAp)
            {
                Console.WriteLine($"{i.ID}\t{i.Nombre}\t{i.Calificacion}");
            }
            var pCal = from alumno in _Alm
                        select alumno.Calificacion;
            double CalP = pCal.Average();
            Console.WriteLine($"La calificacion promedio de los Alumnos es: {CalP}");
            ///


            var Alm3 = from alumno in _Alm
                       join estado in _Estado on alumno.IdEstado equals estado.Id
                       where alumno.IdEstatus == 3
                       select new
                       {
                           ID=alumno.ID,
                           nAlumno=alumno.Nombre,
                           nEdo=estado.Nombre
                       };
            Console.WriteLine($"ID\tNombre del Alumno\tNombre del Estado al que pertenece");
            foreach (var i in Alm3)
            {
                Console.WriteLine($"{i.ID}\t{i.nAlumno}\t{i.nEdo}");
            }
            var Alm4 = from alumno in _Alm
                       join estatus in _Estatus on alumno.IdEstatus equals estatus.ID
                       where alumno.IdEstatus == 2
                       orderby alumno.Nombre
                       select new
                       {
                           ID = alumno.ID,
                           nAlumno = alumno.Nombre,
                           nEdo = estatus.Nombre
                       };
            Console.WriteLine($"ID\tNombre del Alumno\tNombre del Estatus al que pertenece");
            foreach (var i in Alm4)
            {
                Console.WriteLine($"{i.ID}\t{i.nAlumno}\t{i.nEdo}");
            }
            var Alm5 = from alumno in _Alm
                       join estados in _Estado on alumno.IdEstado equals estados.Id
                       join estatus in _Estatus on alumno.IdEstatus equals estatus.ID
                       where alumno.IdEstatus == 2
                       orderby estatus.Nombre
                       select new
                       {
                           ID = alumno.ID,
                           nAlumno = alumno.Nombre,
                           nEdo = estados.Nombre,
                           nEst=estatus.Nombre
                       };
            Console.WriteLine($"ID\tNombre del Alumno\tNombre del Estatus al que pertenece\tNombre del Estatus al que pertenece");
            foreach (var i in Alm5)
            {
                Console.WriteLine($"{i.ID}\t{i.nAlumno}\t{i.nEdo}\t{i.nEst}");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Ingrese el Sueldo mensual del trabajador: ");
            string ssldo=Console.ReadLine();
            decimal sldo=Convert.ToDecimal(ssldo);
            decimal sdoQ = sldo / 2;
            IISR=CalcularISR(sldo);
            ISR = Calcular(IISR,sdoQ);
            Console.WriteLine($"Sueldo Quincenal: {sdoQ}");
            Console.WriteLine("Limite Inferior: ");
            Console.WriteLine(IISR.LimInf);
            Console.WriteLine("Limite Superior: ");
            Console.WriteLine(IISR.LimSup);
            Console.WriteLine("Cuota Fija: ");
            Console.WriteLine(IISR.CuotaFija);
            Console.WriteLine("Subsidio para el empleado: ");
            Console.WriteLine(IISR.Subsidio);
            Console.WriteLine("Porcentaje Excedente Limite Inferior: ");
            Console.WriteLine($"{IISR.PorExced}%");
            Console.WriteLine("Excedente: ");
            Console.WriteLine(ISR.Excedente);
            Console.WriteLine("Impuesto: ");
            Console.WriteLine(ISR.Impuesto);
            Console.ReadKey();
        }
        public static ItemISR CalcularISR(decimal sldo)
        {

            decimal liminf = 0, limsup = 0, cuotaf = 0, exedliminf = 0, subsidio = 0;
            decimal sldoq = sldo / 2;
            var datos = from dISR in _ISR
                        select dISR;
            foreach(var l in datos)
            {
                if ((sldoq >= l.LimInf && sldoq <= l.LimSup))
                {
                    liminf = l.LimInf;
                    limsup = l.LimSup;
                    cuotaf = l.CuotaFija;
                    exedliminf = l.PorExced;
                    subsidio = l.Subsidio;
                }
            }
            ItemISR iSR = new ItemISR(liminf, limsup, cuotaf, exedliminf, subsidio);
            return iSR;
            //Calcular(liminf,limsup,cuotaf,exedliminf,subsidio,sldoq);
        }
        public static ISRResult Calcular(ItemISR iSR, decimal sldoQ)
        {

            decimal excedent = ObtenerExcedente(iSR.LimInf, sldoQ, iSR.PorExced);
            decimal impuesto = ObtenerImpuesto(iSR.CuotaFija, excedent, iSR.Subsidio);
            ISRResult isr = new ISRResult(excedent, impuesto);
            return isr;
        }
        public static decimal ObtenerExcedente(decimal limInf, decimal sldoq, decimal exdLimI)
        {
            decimal result = 0;

            result = (sldoq - limInf) * (exdLimI / 100);

            return result;
        }
        public static decimal ObtenerImpuesto(decimal cuFija, decimal excedn, decimal subSid)
        {
            decimal resultado = 0;
            resultado = (cuFija + excedn) + subSid;
            return resultado;
        }
    }
}
