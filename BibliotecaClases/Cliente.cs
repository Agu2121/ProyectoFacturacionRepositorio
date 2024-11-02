using BibliotecaClases_BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class Cliente
    {
        // Atributos privados
        private int _idCliente;
        private string _nombre;
        private string _cuit_cuil;
        private string _direccion;
        private int _idCiudad;
        private int _idCondicionIva;

        // Propiedades públicas
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Cuit_Cuil
        {
            get { return _cuit_cuil; }
            set { _cuit_cuil = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }

        public int IdCondicionIva
        {
            get { return _idCondicionIva; }
            set { _idCondicionIva = value; }
        }

        // MÉTODO PARA OBTENER LA LISTA DE CLIENTES DESDE LA BASE DE DATOS
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            // Usar la conexión a la base de datos mediante la clase de conexión
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    miConexion.Open();
                    // Definir la consulta SQL para obtener los clientes
                    string consulta = "SELECT IdCliente, Nombre, Cuit_Cuil, Direccion, IdCiudad, IdCondicionIva FROM Cliente";

                    // Crear un comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                    {
                        // Ejecutar la consulta y obtener los resultados usando un DataReader
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // Leer cada fila de los resultados
                            while (reader.Read())
                            {
                                // Crear un nuevo objeto Cliente para cada fila
                                Cliente cliente = new Cliente
                                {
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Cuit_Cuil = reader["Cuit_Cuil"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    IdCiudad = (int)Convert.ToInt64(reader["IdCiudad"]),
                                    IdCondicionIva = (int)Convert.ToInt64(reader["IdCondicionIva"])
                                };
                                // Agregar el cliente a la lista de clientes
                                listaClientes.Add(cliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones
                    MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                }
            }
            // Retornar la lista de clientes obtenida
            return listaClientes;
        }

        // MÉTODO PARA OBTENER LA DESCRIPCIÓN DE LA CONDICIÓN IVA SEGÚN SU ID
        public string ObtenerDescripcionCondicion()
        {
            // Evaluar el valor del IdCondicionIva y retornar la descripción correspondiente
            switch (IdCondicionIva)
            {
                case 1:
                    return "Responsable Inscripto";
                case 2:
                    return "Monotributista";
                case 3:
                    return "Consumidor final";
                case 4:
                    return "Exento";
                default:
                    return "Desconocido"; // En caso de que el valor no esté definido
            }
        }

        // MÉTODO PARA VALIDAR SI UN CLIENTE HA SIDO SELECCIONADO
        public bool ValidarCliente(Cliente clienteSeleccionado)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
                return false;
            }
            return true;
        }

    }
}
