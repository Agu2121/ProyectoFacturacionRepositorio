using BibliotecaClases_BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class Articulo
    {
        // Atributos privados
        private int _idArticulo;
        private string _descripcion;
        private decimal _precioUnitarioSinIva;

        // Propiedades públicas
        public int IdArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal PrecioUnitarioSinIva
        {
            get { return _precioUnitarioSinIva; }
            set { _precioUnitarioSinIva = value; }
        }

        // MÉTODO PARA OBTENER LA LISTA DE ARTÍCULOS DESDE LA BASE DE DATOS
        public List<Articulo> ObtenerArticulos()
        {
            // Crear una lista vacía de artículos
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                // Usar una conexión a la base de datos
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    // Definir la consulta SQL que trae los artículos
                    string query = "SELECT IdArticulo, Descripcion, PrecioUnitarioSinIva FROM Articulo";

                    // Crear un comando SQL con la consulta y la conexión
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Ejecutar la consulta y obtener los resultados usando un DataReader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Leer cada fila de los resultados
                        while (reader.Read())
                        {
                            // Crear una nueva instancia de Articulo para cada fila
                            Articulo articulo = new Articulo
                            {
                                IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                PrecioUnitarioSinIva = Convert.ToDecimal(reader["PrecioUnitarioSinIva"])
                            };
                            // Agregar el artículo a la lista
                            listaArticulos.Add(articulo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Error al obtener los artículos: " + ex.Message));
            }
            // Retornar la lista de artículos obtenidos
            return listaArticulos;
        }

        // MÉTODO PARA AGREGAR UN ARTÍCULO A UNA GRILLA (DataGridView)
        public void AgregarAGrilla(DataGridView dtgGrilla, int cantidad)
        {
            // Calcular el total (precio unitario * cantidad)
            decimal total = this.PrecioUnitarioSinIva * cantidad;

            // Agregar una fila a la grilla con los valores del articulo
            dtgGrilla.Rows.Add(this.IdArticulo, this.Descripcion, cantidad, total.ToString("C2"));
        }

        // MÉTODO PARA VALIDAR SI HAY ARTÍCULOS AGREGADOS A LA GRILLA
        public bool ValidarArticulo(DataGridView grilla)
        {
            if (grilla.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, agregue al menos un articulo a la grilla.");
                return false;
            }
            return true;
        }
    }
}
