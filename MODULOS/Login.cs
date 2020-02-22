using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIST_VENTAS_01.MODULOS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if(txtpassword.Text=="PASSWORD")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.LightGray;
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.LightGray;
            }
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.DimGray;
            }

        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "PASSWORD";
                txtpassword.ForeColor = Color.DimGray;
                txtpassword.UseSystemPasswordChar =false;
            }
        }

        private void txtolvidado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtusuario.Text!="" && txtpassword.Text!="")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexion.ConexionDB.conexion;
                    con.Open();

                    SqlCommand com = new SqlCommand("validarUsuario",con);
                    com.CommandType= CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@login", txtusuario.Text);
                    com.Parameters.AddWithValue("@password", txtpassword.Text);

                    com.ExecuteNonQuery();

                    Menu v = new Menu();
                    SqlDataReader leer = com.ExecuteReader();
                    if (leer.Read())
                    {
                        v.intoUsuario(leer["nombres"].ToString());
                        v.Show();
                        
                    }

                    //Form1 a = new Form1();
                    //a.Show();

                    //Close(); // CERRAMOS ESTA VENTANA 
                    con.Close();

                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
