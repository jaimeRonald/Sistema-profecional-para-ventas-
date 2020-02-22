using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using SIST_VENTAS_01.DATOS;

namespace SIST_VENTAS_01.MODULOS
{
    public partial class Menu : Form
    {

        Funciones f = new Funciones();
        public void intoUsuario(string usuario)
        {
            txtUsuarioPrincipal.Text = usuario;
        }
        public Menu()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCpture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int wmsg, int wparam, int lparam);


        private void btnMenu_Click(object sender, EventArgs e)
        {

            if(menuVertical.Width==200)
            {
                menuVertical.Width = 70;
            }
            else
            {
                menuVertical.Width = 200;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCpture();
            SendMessage(this.Handle, 0X112, 0XF012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //panel5.Show();
            //panelcliente.Hide();
            abrrirform(new listadoProductos());
         }

        private void abrrirform(object hija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form frm= hija as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frm);
            this.panelContenedor.Tag = frm;
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.getUsuario(txtUsuarioPrincipal.Text);
            ven.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //panel5.Visible = false;
            
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //panel5.Visible = false;
            //panelcliente.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //f.mostrar(datalistadoPRODUCTOS2);

        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
       //     f.buscar(txtbuscarP.Text, datalistadoPRODUCTOS2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // panelcliente.Show();
            //panel5.Hide();
            abrrirform(new listadoCliente());
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         //   f.buscarCliente(txtCliente.Text, datalistadoClientes);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // f.mostrarCliente(datalistadoClientes);
        }

         

        private void button7_Click_1(object sender, EventArgs e)
        {
            //panelcliente.Visible = false;
        }
    }
}
