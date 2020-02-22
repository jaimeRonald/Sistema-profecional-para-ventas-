using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIST_VENTAS_01.Conexion
{
    class tamaño_Automatico_de_datatables
    {

        public static void Multilinea(ref DataGridView list)
        {
            list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            list.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            list.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            list.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            list.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styleCabeceras = new DataGridViewCellStyle();
            styleCabeceras.BackColor = System.Drawing.Color.White;
            styleCabeceras.ForeColor = System.Drawing.Color.Black;
            styleCabeceras.Font = new Font("segoe UI", 10, FontStyle.Bold);
            list.ColumnHeadersDefaultCellStyle = styleCabeceras;

        }
    }
}
