using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;
using SIST_VENTAS_01.DATOS;

namespace SIST_VENTAS_01.MODULOS
{
    public partial class Ventas : Form
    {
        //int ArrayList arr = new ArrayList();

        int[] arre = new int[50];
        private int modopago = 0;
        private string usuario = "";
        private int sumaTotalVenta=0;
        string numeroFactura = "";

        Funciones f = new Funciones();


        public void getUsuario(string nombre)
        {

            txtUsuario.Text = nombre;
        }

        public Ventas()
        {
            for (int i = 0; i < 50; i++)
            {
                arre[i] = 0;
            }
            InitializeComponent();



        }




        private void Ventas_Load(object sender, EventArgs e)
        {


            panel5.Visible = false;
            panel2.Visible = false;
            //mostrar();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        public void setNombres(string nombre, string dni, string direccion, string correo, string telefono)
        {
            this.txtnombre.Text = nombre;
            this.txtdni.Text = dni;
            this.txtdireccion.Text = direccion;
            this.txtcorreo.Text = correo;
            this.txttelefono.Text = telefono;
        }

        // AAAAAAAAAAAAAAAAAAAAA
        //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;


        }



        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

            // buscar();



        }




        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistadoproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///RARRARRRRRRRRRRRRRRRRRRRRR

           




        }

        private void datalistadoPRODUCTOS2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datalistado.SelectedCells[1].Value.ToString()









        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.mostrar(datalistadoPRODUCTOS2);
            //mostrar();



            //panel7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistadoproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.datalistadoproductos.Columns["sumar"].Index)
            {



                DataGridViewRow a = datalistadoproductos.Rows[e.RowIndex];
                datalistadoproductos.Columns[5].DefaultCellStyle.Format = "#,#";

                arre[e.RowIndex] = int.Parse(datalistadoproductos.Rows[e.RowIndex].Cells[5].Value.ToString());
                arre[e.RowIndex] = arre[e.RowIndex] + 1;

                a.Cells[5].Value = arre[e.RowIndex];
                a.Cells[6].Value = arre[e.RowIndex] * int.Parse(datalistadoproductos.Rows[e.RowIndex].Cells[2].Value.ToString());


            }
            if (e.ColumnIndex == this.datalistadoproductos.Columns["restar"].Index)
            {
                DataGridViewRow b = datalistadoproductos.Rows[e.RowIndex];
                datalistadoproductos.Columns[5].DefaultCellStyle.Format = "#,#";

                arre[e.RowIndex] = int.Parse(datalistadoproductos.Rows[e.RowIndex].Cells[5].Value.ToString());

                arre[e.RowIndex] = arre[e.RowIndex] - 1;
                b.Cells[5].Value = arre[e.RowIndex];
                b.Cells[6].Value = arre[e.RowIndex] * int.Parse(datalistadoproductos.Rows[e.RowIndex].Cells[2].Value.ToString());
            }


            if (e.ColumnIndex == this.datalistadoproductos.Columns["eliminar"].Index)
            {
                datalistadoproductos.Rows.RemoveAt(datalistadoproductos.CurrentRow.Index);
            }

            


        }


        public int procAlmac(String proced, string valor, string input, string campo)
        {
            var a = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionDB.conexion;
            con.Open();




            //para cliente
            SqlCommand cmd = new SqlCommand(proced, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(valor, input);
            cmd.ExecuteNonQuery();
            SqlDataReader dato = cmd.ExecuteReader();
            if (dato.Read())
            {
                a = Convert.ToInt32(dato[campo].ToString());
            }
            con.Close();
            return a;
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        { 
            var a = "";
            var b = "";
            numeroFactura = DateTime.Now.ToString("G");//// a

            MessageBox.Show(txtUsuario.Text);
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();
                try
                {
                    SqlCommand agregarVenta = new SqlCommand("inserat_factura", con);
                    agregarVenta.CommandType = CommandType.StoredProcedure;


                    agregarVenta.Parameters.AddWithValue("@cliente", procAlmac("buscar_cliente", "@dato", txtdni.Text, "idCliente"));
                    agregarVenta.Parameters.AddWithValue("@usuario", procAlmac("buscar_usuario", "@letra", txtUsuario.Text, "idUsuario"));
                    agregarVenta.Parameters.AddWithValue("@modoPago", this.modopago);
                    agregarVenta.Parameters.AddWithValue("@fecha", "2020-04-13");
                    agregarVenta.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                    agregarVenta.ExecuteNonQuery();
                    MessageBox.Show("incertado");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //MessageBox.Show("este es  " + dato["idCliente"].ToString);

                try
                {
                    //SqlCommand agregardetalle = new SqlCommand("insertar_detalle", con);
                    //agregardetalle.CommandType = CommandType.StoredProcedure;





                    var nfactura = procAlmac("buscar_factura", "@dato", numeroFactura, "idFactura");



                    foreach (DataGridViewRow row in datalistadoproductos.Rows)
                    {



                        SqlCommand agregardetalle = new SqlCommand("insertar_detalle", con);
                        agregardetalle.CommandType = CommandType.StoredProcedure;

                        string Cantidad = datalistadoproductos[5, row.Index].Value.ToString();
                        string precio = datalistadoproductos[2, row.Index].Value.ToString();

                        agregardetalle.Parameters.Add(new SqlParameter("@idProducto", procAlmac("buscar_productos", "@dato",
                                                              datalistadoproductos[0, row.Index].Value.ToString(), "idProducto")));
                        agregardetalle.Parameters.Add(new SqlParameter("@cantidad", Cantidad));
                        agregardetalle.Parameters.Add(new SqlParameter("@precio", precio));
                        agregardetalle.Parameters.Add(new SqlParameter("@idFactura", nfactura));
                        agregardetalle.ExecuteNonQuery();

                        ////////// ACTUALIZAR STOCK DE PRODUCTOS AL MISMO TIEMPO ///////////

                        SqlCommand updateP = new SqlCommand("updateStock", con);
                        updateP.CommandType = CommandType.StoredProcedure;
                        updateP.Parameters.Add(new SqlParameter("@producto", datalistadoproductos[0, row.Index].Value.ToString()));
                        updateP.Parameters.Add(new SqlParameter("@cantidad", Cantidad));
                        updateP.ExecuteNonQuery();


                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        // AAAAAAAAAAAAAAAAAAAAA

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.modopago = 1;
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.modopago = 2;
            panel2.Visible = false;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(this);
            cliente.Show();

        }

        private void datalistadoPRODUCTOS2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in datalistadoPRODUCTOS2.SelectedRows)
            {
                string a, b, c;
                a = this.datalistadoPRODUCTOS2.SelectedCells[1].Value.ToString();
                b = this.datalistadoPRODUCTOS2.SelectedCells[2].Value.ToString();
                c = this.datalistadoPRODUCTOS2.SelectedCells[3].Value.ToString();
                //Ventas dato = new Ventas();

                //  foreach (Form frm in Application.OpenForms)
                //{
                //  if (frm.Name == "Ventas")
                //{
                //dato = (Ventas)frm;
               // int rowId = datalistadoproductos.Rows.Add();
               // DataGridViewRow row2 = datalistadoproductos.Rows[5];

                datalistadoproductos.Rows.Add(a, b, c,null,null,0);
                

                //this.Close();
                //break;
                //}
                // }

            }


            panel5.Visible = false;

        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
            f.buscar(txtbuscarP.Text,datalistadoPRODUCTOS2);
            //buscar();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            //var nfactura = procAlmac("buscar_factura", "@dato", "909909", "idFactura");

            frmComprobante con = new frmComprobante();
            con.idventa = Convert.ToString(numeroFactura);
            con.ShowDialog();
        }

        private void datalistadoproductos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

            


        }

        private void txtTotal_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dat in datalistadoproductos.Rows)
            {
                sumaTotalVenta = sumaTotalVenta + int.Parse(dat.Cells[6].Value.ToString());

            }

            txtTotal.Text = Convert.ToString(sumaTotalVenta);
        }
    }
}
