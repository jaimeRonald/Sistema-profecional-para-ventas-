using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIST_VENTAS_01.DATOS;

namespace SIST_VENTAS_01.MODULOS
{
    public partial class listadoCliente : Form
    {
        Funciones fun = new Funciones();
        public listadoCliente()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fun.mostrarCliente(datalistadoClientes);
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            fun.buscarCliente(txtCliente.Text,datalistadoClientes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
