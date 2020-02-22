using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIST_VENTAS_01
{
    public partial class frmComprobante : Form
    {
        private  string _idventa;

        public string idventa
        {
            get { return _idventa; }
            set { _idventa = value; }
        }
        
        public frmComprobante()
        {
            InitializeComponent();
        }

        private void frmComprobante_Load(object sender, EventArgs e)
        {
            this.comporbantePTableAdapter.Fill(this.bASE_SIST_VENT_CDataSet.comporbanteP,idventa);
            
            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
