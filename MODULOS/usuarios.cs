using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace SIST_VENTAS_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void USUARIOS_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            lbleligeIcono.Visible = true;
            txtnombres.Text = "";
            txtcontraseña.Text = "";
            txtusuario.Text = "";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public bool validar_Email(String email)
        {
              return Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
           /// FALTA VALIDAR EMAIL ANTES FALTA AGREGAR TABLA EN BASE DE DATOS 
        }

        public void Cargar_EstadoIcono()
        {
            try
            {
                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    try
                    {
                        String icono = Convert.ToString(row.Cells["Nombre_icono"].Value);

                        if(icono=="1")
                        {
                            pictureBox3.Visible = false;
                        }
                        else if(icono=="2")
                        {
                            pictureBox4.Visible = false;

                        }
                        else if(icono=="3")
                        {
                            pictureBox5.Visible = false;
                        }
                        else if(icono=="4")
                        {
                            pictureBox5.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                    }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //if(validar_Email())

            if (txtnombres.Text != "")
            {
                try
                {

                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("incertar_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nombre", txtnombres.Text);
                cmd.Parameters.AddWithValue("@login", txtusuario.Text);
                cmd.Parameters.AddWithValue("@password", txtcontraseña.Text);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                picIcono.Image.Save(ms, picIcono.Image.RawFormat);

                cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@nombre_icono", lbnumeroIcono.Text);
                cmd.Parameters.AddWithValue("@Rol", cmbtipoUsuario.Text);
                cmd.Parameters.AddWithValue("@Estado", "Activo");

                cmd.ExecuteNonQuery();
                con.Close();
                mostrar();
                panel5.Visible = false;
                }catch(Exception ex)
                {
                    MessageBox.Show("holi "+ ex.Message);
                }

            }



        }


        private void mostrar()
        {
            try
            {


                DataTable dt = new DataTable();
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible=false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           // Conexion.tamaño_Automatico_de_datatables.Multilinea(ref datalistado);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cargar_EstadoIcono();
            panelIcono.Visible = true;

        }

        private void panelIcono_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*,jgp;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "mis imagenes";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                picIcono.BackgroundImage = null;
                picIcono.Image = new Bitmap(dlg.FileName);
                picIcono.SizeMode = PictureBoxSizeMode.Zoom;
                lbnumeroIcono.Text = Path.GetFileName(dlg.FileName);
                lbleligeIcono.Visible = false;
                panelIcono.Visible = false;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIDUsuario.Text = datalistado.SelectedCells[1].Value.ToString() ;
            txtnombres.Text=datalistado.SelectedCells[2].Value.ToString();
             txtusuario.Text = datalistado.SelectedCells[3].Value.ToString();
            txtcontraseña.Text = datalistado.SelectedCells[4].Value.ToString();

            picIcono.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
            MemoryStream ms =new System.IO.MemoryStream(b);
            picIcono.Image = Image.FromStream(ms);
            lbleligeIcono.Visible = false;

            lbnumeroIcono.Text = datalistado.SelectedCells[6].Value.ToString();
            cmbtipoUsuario.Text = datalistado.SelectedCells[7].Value.ToString();

            panel5.Visible = true;

            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox3.Image;
            lbnumeroIcono.Text = "1";
            lbleligeIcono.Visible = false;
            panelIcono.Visible = false;
                
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox4.Image;
            lbnumeroIcono.Text = "2";
            lbleligeIcono.Visible = false;
            panelIcono.Visible = false;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox5.Image;
            lbnumeroIcono.Text = "3";
            lbleligeIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox6.Image;
            lbnumeroIcono.Text = "4";
            lbleligeIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            panel5.Visible = false;
            panelIcono.Visible = false;
            mostrar();

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtnombres.Text != "")
            {
                try
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexion.ConexionDB.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("editar_usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", lblIDUsuario.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtnombres.Text);
                    cmd.Parameters.AddWithValue("@login", txtusuario.Text);
                    cmd.Parameters.AddWithValue("@password", txtcontraseña.Text);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    picIcono.Image.Save(ms, picIcono.Image.RawFormat);



                    cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@nombre_icono", lbnumeroIcono.Text);

                    cmd.Parameters.AddWithValue("@Rol", cmbtipoUsuario.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                    panel5.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== this.datalistado.Columns["eli"].Index)
            {
                DialogResult resul;
                
                resul = MessageBox.Show("desea eliminar realmente el usuario ? ", "Eliminado registros ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(resul==DialogResult.OK)
                {
                    SqlCommand cmd;

                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            String usuario = Convert.ToString(row.Cells["login"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = Conexion.ConexionDB.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_usuario", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@idUsuario", onekey);
                                    cmd.Parameters.AddWithValue("@login", usuario);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        mostrar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        public void Buscar()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_usuario", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra",txtBuscar.Text);
               // Console.WriteLine("hola "+ a);

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public void Valida_Contraseña(System.Windows.Forms.TextBox cajaTexto ,System.Windows.Forms.KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            Valida_Contraseña(txtBuscar, e);
        }

        private void picIcono_Click(object sender, EventArgs e)
        {
            Cargar_EstadoIcono();
            panelIcono.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
