using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SQLEstausAlumnos
{
    public class MetSQL
    {

        private static List<Estatus> _Estatus = new List<Estatus>();
        public static void ConsultAll()
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from EstatusAlumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader= comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                        new Estatus()
                        {
                            Id= Convert.ToInt32(reader["ID"]),
                            Clave=reader["Clave"].ToString(),
                            Nombre=reader["Nombre"].ToString()
                        });
                }
                conn.Close();
            }
            
            Console.WriteLine($"ID\t\tNombre\t\t\tClave\t\t");
            foreach (var oEstatus in _Estatus)
            {
                Console.WriteLine($"{oEstatus.Id}\t\t{oEstatus.Nombre}\t\t{oEstatus.Clave}");
            }
            _Estatus.Clear();
        }
        public static void ConstltEdo()
        {
            Console.WriteLine("Ingrese el ID del Estatus que desea consultar");
            string termino = Console.ReadLine();
            int nID=Convert.ToInt32(termino);
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"select * from EstatusAlumnos where id={nID}";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                        new Estatus()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        });
                }
                conn.Close();
            }

            Console.WriteLine($"ID\t\tNombre\t\t\tClave\t\t");
            foreach (var oEstatus in _Estatus)
            {
                Console.WriteLine($"{oEstatus.Id}\t\t{oEstatus.Nombre}\t\t{oEstatus.Clave}");
            }
            _Estatus.Clear();
        }
        public static void AgregarEdo()
        {
            int idEdoN;
            Console.WriteLine("Ingrese el Nombre del Curso");
            string nNombre = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Curso");
            string nClave = Console.ReadLine();

            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"insert into EstatusAlumnos (Clave,Nombre) values ('{nClave}','{nNombre}')";

            using(SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand sqlCommand=new SqlCommand(query, conn);
                sqlCommand.CommandType=CommandType.Text;
                conn.Open();
                idEdoN=(Int32)sqlCommand.ExecuteScalar();
                conn.Close();
            }
            Console.WriteLine($"El ID del curso agregado es {idEdoN}");
        }
        public static void ActualizarEdo()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del estado que desea Editar");
            string idS = Console.ReadLine();
            int nID = Convert.ToInt32(idS);
            Console.WriteLine("Ingrese el Nuevo Estatus");
            string nEdo = Console.ReadLine();
            Console.WriteLine("Ingrese la Clave del Estado");
            string NCla = Console.ReadLine();

            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"update EstatusAlumnos set Clave='{NCla}', Nombre='{nEdo}' where id={nID}";

            using (SqlConnection sqlConn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query,sqlConn);
                cmd.CommandType=CommandType.Text;
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
        public static void EliminEdo()
        {
            Console.WriteLine("Ingrese el ID del Estatus que desea Eliminar");
            string idS = Console.ReadLine();
            int nid = Convert.ToInt32(idS);

            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"delete EstatusAlumnos where id={nid}";

            using (SqlConnection sqlConn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.CommandType = CommandType.Text;
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
    }
}
    



