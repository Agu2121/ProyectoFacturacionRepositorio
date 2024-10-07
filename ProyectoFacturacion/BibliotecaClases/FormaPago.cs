using BibliotecaClases_BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class FormaPago
    {
        // Atributos privados
        private int _id;
        private string _descripcion;

        // Propiedad
        public int IdFormaPago
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        // Método para obtener la lista de formas de pago
        public List<FormaPago> ObtenerFormaPago()
        {
            List<FormaPago> listaFormaPago = new List<FormaPago>();
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    miConexion.Open();
                    string consulta = "SELECT IdFormaPago, Descripcion FROM FormaPago";

                    using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FormaPago formaPago = new FormaPago();
                                formaPago.IdFormaPago = Convert.ToInt32(reader["IdFormaPago"]);
                                formaPago.Descripcion = reader["Descripcion"].ToString();

                                listaFormaPago.Add(formaPago);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones
                    System.Windows.Forms.MessageBox.Show("Error al obtener las formas de pago: " + ex.Message);
                }
            }

            return listaFormaPago;
        }

        // Método para validar si la forma de pago ha sido seleccionado
        public bool ValidarFormaPago(FormaPago formaPagoSeleccionada)
        {
            if (formaPagoSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione una forma de pago.");
                return false;
            }
            return true;
        }
    }
}
