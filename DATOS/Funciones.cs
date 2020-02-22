using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIST_VENTAS_01.DATOS
{
    class Funciones
    {

        public  void mostrar( DataGridView datalistadoPRODUCTOS2)
        {
            try
            {
                DataTable da = new DataTable();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter("mostrar_productos", con);
                ada.Fill(da);
                datalistadoPRODUCTOS2.DataSource = da;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public  void buscar(string dato, DataGridView datalistadoPRODUCTOS2)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter("buscar_productos", con);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@dato", dato);
                DataTable tablaProductos = new DataTable();
                ada.Fill(tablaProductos);
                datalistadoPRODUCTOS2.DataSource = tablaProductos;

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void buscarCliente(string dato, DataGridView datalistado)
        {
            try
            {
                DataTable dataBuscar = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;

                SqlDataAdapter ada = new SqlDataAdapter("buscar_cliente", con);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@dato", dato);


                ada.Fill(dataBuscar);
                datalistado.DataSource = dataBuscar;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void mostrarCliente(DataGridView datalistado)
        {
            try
            {
                DataTable data = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionDB.conexion;
                con.Open();
               
                SqlDataAdapter adap = new SqlDataAdapter("mostrar_cliente", con);
                // adap.SelectCommand = comando;

                adap.Fill(data);
                datalistado.DataSource = data;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
