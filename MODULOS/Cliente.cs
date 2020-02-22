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
using SIST_VENTAS_01.DATOS;

namespace SIST_VENTAS_01.MODULOS
{
    public partial class Cliente : Form
    {
        private Ventas ventas;

        Funciones func = new Funciones();
        public Cliente(Ventas ventas)
        {
            this.ventas = ventas;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        //DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

           if(txtnombre.Text!="")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexion.ConexionDB.conexion;
                    con.Open();

                    SqlCommand comand = new SqlCommand("insertar_cliente", con);
                    comand.CommandType = CommandType.StoredProcedure;

                    comand.Parameters.AddWithValue("@nombres", txtnombre.Text);
                    comand.Parameters.AddWithValue("@dni", txtdni.Text);
                    comand.Parameters.AddWithValue("@correo", txtcorreo.Text);
                    comand.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                    comand.Parameters.AddWithValue("@telefono", txttelefono.Text);
                    comand.Parameters.AddWithValue("@estado", "Activo");


                    comand.ExecuteNonQuery();
                    con.Close();
                    
                    func.mostrarCliente(datalistado);
                    panel5.Visible = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }






        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            func.mostrarCliente(datalistado);
            panel5.Visible = false;

           
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataListadoCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataListadoCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            txtnombre.Text = "";
            txttelefono.Text = "";
            txtdni.Text = "";
            txtcorreo.Text= "";
            txtdireccion.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel5.Visible = false;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
             

        }

        private void datalistadoCliente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*nombre = datalistado.SelectedCells[1].Value.ToString();
            //dni= datalistado.SelectedCells[2].Value.ToString();
            txtcorreo.Text = datalistado.SelectedCells[3].Value.ToString();
            txtdireccion.Text = datalistado.SelectedCells[4].Value.ToString();
            txttelefono.Text = datalistado.SelectedCells[5].Value.ToString();*/



            //panel5.Visible = true;

           // btnGuardar.Visible =true;

           
            ventas.setNombres(datalistado.SelectedCells[2].Value.ToString(),
                 datalistado.SelectedCells[3].Value.ToString(),
                 datalistado.SelectedCells[4].Value.ToString(),
                 datalistado.SelectedCells[5].Value.ToString(),
                 datalistado.SelectedCells[6].Value.ToString());
            ventas.Visible = true;

            Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            func.buscarCliente(txtbuscar.Text, datalistado);
            


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            panel5.Visible = true;


        }
    }
}
;