using BibliotecaClases_BD;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public class Factura
    {
        public FacturaCabecera Cabecera { get; set; }
        public List<FacturaDetalle> Detalles { get; set; }

        public Factura()
        {
            Cabecera = new FacturaCabecera();
            Detalles = new List<FacturaDetalle>();
        }

        // Método para crear la cabecera de la factura
        public void CrearCabecera(Cliente clienteSeleccionado, ComboBox cboFormaPago, DataGridView dtgGrilla, TextBox txtObservaciones)
        {
            Cabecera.NumeroFactura = Cabecera.GenerarNumeroFactura(3);
            Cabecera.Fecha = DateTime.Now;
            Cabecera.IdCliente = clienteSeleccionado.IdCliente;
            Cabecera.IdEmpresa = 1;
            Cabecera.IdFormaPago = Convert.ToInt32(cboFormaPago.SelectedIndex) + 1;
            Cabecera.TipoFactura = clienteSeleccionado.IdCondicionIva == 1 ? "A" : "B";
            Cabecera.CAE = Cabecera.GenerarCAE();
            Cabecera.FechaVencimientoCAE = Cabecera.GenerarFechaVencimientoCAE();
            Cabecera.SubTotal = Cabecera.CalcularTotalFactura(dtgGrilla);
            Cabecera.Iva = Cabecera.SubTotal * 0.21m;
            Cabecera.Total = Cabecera.SubTotal + Cabecera.Iva;
            Cabecera.Observaciones = txtObservaciones.Text;

            // Insertar la cabecera en la base de datos
            Cabecera.InsertarFacturaCabecera();
        }

        // Método para agregar detalles a la factura
        public void AgregarDetalles(DataGridView dtgGrilla)
        {
            foreach (DataGridViewRow row in dtgGrilla.Rows)
            {
                FacturaDetalle detalle = new FacturaDetalle
                {
                    IdFactura = Cabecera.ObtenerIdFacturaCabecera(),
                    IdArticulo = Convert.ToInt32(row.Cells["Codigo"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    Importe = Convert.ToDecimal(row.Cells["Total"].Value.ToString().Replace("$", ""))
                };

                // Insertar el detalle en la base de datos
                detalle.InsertarFacturaDetalle();

                // Agregar detalle a la lista de detalles
                Detalles.Add(detalle);
            }
        }

        // Método para generar la factura completa
        public void GenerarFactura(Cliente clienteSeleccionado, ComboBox cboFormaPago, DataGridView dtgGrilla, TextBox txtObservaciones)
        {
            Cliente cliente = new Cliente();

            // Crear la cabecera e insertar en la base de datos
            CrearCabecera(clienteSeleccionado, cboFormaPago, dtgGrilla, txtObservaciones);

            // Agregar los detalles e insertar en la base de datos
            AgregarDetalles(dtgGrilla);

            MessageBox.Show("Factura generada exitosamente.");
        }

        // Método para obtener todas las facturas de un cliente
        public List<FacturaCabecera> ObtenerFacturasPorCliente(int idCliente)
        {
            string query = "SELECT IdFactura, NumeroFactura, Fecha, TipoFactura FROM FacturaCabecera WHERE IdCliente = @IdCliente";

            List<FacturaCabecera> facturas = new List<FacturaCabecera>();

            try
            {
                using (SqlConnection connection = Conexion.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCliente", idCliente);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FacturaCabecera factura = new FacturaCabecera
                        {
                            IdFactura = reader.GetInt32(0),
                            NumeroFactura = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            TipoFactura = reader.GetString(3)
                        };

                        facturas.Add(factura);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas: " + ex.Message);
            }

            return facturas;
        }

        // Método para cargar el reporte dependiendo del tipo de factura
        public ReportDocument CargarReporte(FacturaCabecera facturaSeleccionada)
        {
            ReportDocument report = new ReportDocument(); // Crear una nueva instancia del reporte

            // Cargar el reporte según el tipo de factura
            if (facturaSeleccionada.TipoFactura == "A")
            {
                report.Load(@"C:\Users\agoro\OneDrive\Escritorio\Segundo año ISP\Programacion 1\Soluciones\ProyectoFacturacion\WindowsForms\FacturaA.rpt");
            }
            else if (facturaSeleccionada.TipoFactura == "B")
            {
                report.Load(@"C:\Users\agoro\OneDrive\Escritorio\Segundo año ISP\Programacion 1\Soluciones\ProyectoFacturacion\WindowsForms\FacturaB.rpt");
            }

            return report; // Retornar el reporte cargado
        }

    }
}
