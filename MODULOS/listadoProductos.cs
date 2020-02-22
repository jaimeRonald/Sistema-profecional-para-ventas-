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
    public partial class listadoProductos : Form
    {
        Funciones fun = new Funciones();
        public listadoProductos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fun.mostrar(datalistadoPRODUCTOS2);
        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
            fun.buscar(txtbuscarP.Text, datalistadoPRODUCTOS2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
