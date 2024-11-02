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

        // Propiedadades publicas
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

        // Método para obtener la lista de formas de pago desde la base de datos
        public List<FormaPago> ObtenerFormaPago()
        {
            // Crear una lista vacía de formas de pago
            List<FormaPago> listaFormaPago = new List<FormaPago>();

            // Se usa una conexión a la base de datos utilizando la clase Conexion
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    miConexion.Open();
                    // Definir la consulta SQL que trae el ID y la Descripción de las formas de pago
                    string consulta = "SELECT IdFormaPago, Descripcion FROM FormaPago";

                    // Crear un comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                    {
                        // Ejecutar la consulta y obtener un DataReader para leer los resultados
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Leer cada fila de los resultados
                            while (reader.Read())
                            {
                                // Crear una nueva instancia de FormaPago para cada fila
                                FormaPago formaPago = new FormaPago();

                                // Asignar los valores obtenidos de la base de datos a los atributos de la instancia
                                formaPago.IdFormaPago = Convert.ToInt32(reader["IdFormaPago"]);
                                formaPago.Descripcion = reader["Descripcion"].ToString();

                                // Agregar la instancia de FormaPago a la lista
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

        // MÉTODO PARA VALIDAR SI UNA FORMA DE PAGO HA SIDO SELECCIONADA
        public bool ValidarFormaPago(FormaPago formaPagoSeleccionada)
        {
            // Verificar si la forma de pago seleccionada es nula
            if (formaPagoSeleccionada == null)
            {
                // Si no se ha seleccionado una forma de pago, mostrar un mensaje al usuario
                MessageBox.Show("Por favor, seleccione una forma de pago.");
                return false; // Retornar false indicando que la validación falló
            }
            return true; // Retornar true si se seleccionó correctamente una forma de pago
        }
    }
}
