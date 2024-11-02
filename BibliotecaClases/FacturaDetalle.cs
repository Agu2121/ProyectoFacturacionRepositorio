using BibliotecaClases_BD;
using System;
using System.Data.SqlClient;

namespace BibliotecaClases
{
    public class FacturaDetalle
    {
        // Atributos privados
        private int _idFactura;
        private int _idArticulo;
        private int _cantidad;
        private decimal _importe;

        // Propiedades públicas
        public int IdFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        public int IdArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }


        // Método para insertar un detalle en la base de datos
        public void InsertarFacturaDetalle()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO FacturaDetalle (IdFactura, IdArticulo, Cantidad, Importe) " +
                                   "VALUES (@IdFactura, @IdArticulo, @Cantidad, @Importe)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdFactura", IdFactura);
                        cmd.Parameters.AddWithValue("@IdArticulo", IdArticulo);
                        cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                        cmd.Parameters.AddWithValue("@Importe", Importe);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el detalle de la factura: " + ex.Message);
            }
        }
    }
}