using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FormularioEstatuAlumno
{
    public partial class Form1 : Form,ICRUD
    {
        private static List<EstatusAlumnos> _Estatus = new List<EstatusAlumnos>();
        EstatusAlumnos estatus = new EstatusAlumnos();
        public Form1()
        {
            InitializeComponent();
            LlenarDataGV();
        }

        private void LlenarDataGV()
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from EstatusAlumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                        new EstatusAlumnos()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        });
                }
                conn.Close();
            }
            dgvEstatusAlumnos.AutoGenerateColumns = true;
            dgvEstatusAlumnos.DataSource = _Estatus;
        }

        public void Actualizar(EstatusAlumnos estatus)
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"update EstatusAlumnos set Clave='{estatus.Clave}', Nombre='{estatus.Nombre}' where id={estatus.ID}";

            using (SqlConnection sqlConn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.CommandType = CommandType.Text;
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public int Agregar(EstatusAlumnos estatus)
        {
            int idEstatus=0;
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"insert into EstatusAlumnos (Clave,Nombre) values ('{estatus.Clave}','{estatus.Nombre}')";

            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = CommandType.Text;
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                //idEstatus = (Int32)sqlCommand.ExecuteScalar();
                conn.Close();
            }
            return idEstatus;
        }

        public List<EstatusAlumnos> Consultar()
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from EstatusAlumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                        new EstatusAlumnos()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        });
                }
                conn.Close();
            }
            return _Estatus;
        }

        public EstatusAlumnos Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"delete EstatusAlumnos where id={id}";

            using (SqlConnection sqlConn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.CommandType = CommandType.Text;
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtClave.Enabled = true;
            txtNombre.Enabled = true;
            btnAgr.Enabled = false;
            btnEdit.Enabled = false;
            btnEliminar.Enabled = false;
            btnSave.Visible = true;
            btnSaveGrd.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Enabled=false;
            txtNombre.Clear();
            txtClave.Enabled=false;
            txtClave.Clear();
            pnlDatos.Enabled=false;
            btnEliminar.Enabled = true;
            btnEdit.Enabled = true;
            btnAgr.Enabled = true;
            btnSave.Visible = true;
            btnSaveGrd.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            estatus=new EstatusAlumnos(1,txtNombre.Text,txtClave.Text);
            try
            {
                int date= Agregar(estatus);
                MessageBox.Show($"Datos Guardados Correctamente\nEl nuevo id es: {date}");
                LlenarDataGV();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Los datos no se pudieron guardar por: "+ex.Message);
            }
            txtID.Clear();
            txtNombre.Enabled = false;
            txtNombre.Clear();
            txtClave.Enabled = false;
            txtClave.Clear();
            pnlDatos.Enabled = false;
            btnEliminar.Enabled = true;
            btnEdit.Enabled = true;
            btnAgr.Enabled = true;
            btnSave.Visible = true;
            btnSaveGrd.Visible = false;
            LlenarDataGV();
        }

        private void btnSaveGrd_Click(object sender, EventArgs e)
        {
            estatus =new EstatusAlumnos(Convert.ToInt32(txtID.Text),txtNombre.Text,txtClave.Text);
            Actualizar(estatus);
            LlenarDataGV();
            txtID.Clear();
            txtNombre.Enabled = false;
            txtNombre.Clear();
            txtClave.Enabled = false;
            txtClave.Clear();
            pnlDatos.Enabled = false;
            btnEliminar.Enabled = true;
            btnEdit.Enabled = true;
            btnAgr.Enabled = true;
            btnSave.Visible = true;
            btnSaveGrd.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtClave.Enabled = true;
            txtNombre.Enabled = true;
            btnAgr.Enabled = false;
            btnEdit.Enabled = false;
            btnEliminar.Enabled = false;
            btnSave.Visible = false;
            btnSaveGrd.Visible = true;

            txtID.Text=dgvEstatusAlumnos.CurrentRow.Cells[0].Value.ToString();
            txtClave.Text=dgvEstatusAlumnos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text=dgvEstatusAlumnos.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int elimID=Convert.ToInt32(dgvEstatusAlumnos.CurrentRow.Cells[0].Value.ToString());
            Eliminar(elimID);
            LlenarDataGV();
        }
    }
}
