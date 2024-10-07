using BibliotecaClases_BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class Articulo
    {
        // Atributos
        private int _idArticulo;
        private string _descripcion;
        private decimal _precioUnitarioSinIva;

        // Propiedades
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

        // Método para obtener la lista de artículos desde la base de datos
        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT IdArticulo, Descripcion, PrecioUnitarioSinIva FROM Articulo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Articulo articulo = new Articulo
                            {
                                IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                PrecioUnitarioSinIva = Convert.ToDecimal(reader["PrecioUnitarioSinIva"])
                            };
                            listaArticulos.Add(articulo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los artículos: " + ex.Message);
                throw;
            }

            return listaArticulos;
        }

        public void AgregarAGrilla(DataGridView dtgGrilla, int cantidad)
        {
            // Calcular el total (precio unitario * cantidad)
            decimal total = this.PrecioUnitarioSinIva * cantidad;

            // Agregar una fila a la grilla con los valores
            dtgGrilla.Rows.Add(this.IdArticulo, this.Descripcion, cantidad, total.ToString("C2"));
        }

        // Método para validar si al menos 1 articulo ya ha sido agregado a la grilla
        public bool ValidarArticulo(DataGridView grilla)
        {
            if (grilla.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, agregue a la grilla al menos un articulo.");
                return false;
            }
            return true;
        }
    }
}
