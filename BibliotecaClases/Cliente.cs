using BibliotecaClases_BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class Cliente
    {
        // Atributos
        private int _idCliente;
        private string _nombre;
        private string _cuit_cuil;
        private string _direccion;
        private int _idCiudad;
        private int _idCondicionIva;

        // Propiedades
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

        // Método para obtener la lista de clientes
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    miConexion.Open();
                    string consulta = "SELECT IdCliente, Nombre, Cuit_Cuil, Direccion, IdCiudad, IdCondicionIva FROM Cliente";

                    using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cliente cliente = new Cliente
                                {
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Cuit_Cuil = reader["Cuit_Cuil"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    IdCiudad = (int)Convert.ToInt64(reader["IdCiudad"]),
                                    IdCondicionIva = (int)Convert.ToInt64(reader["IdCondicionIva"])
                                };
                                listaClientes.Add(cliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones
                    System.Windows.Forms.MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                }
            }

            return listaClientes;
        }

        public string ObtenerDescripcionCondicion()
        {
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

        // Método para validar si el cliente ha sido seleccionado
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
