using BibliotecaClases;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Facturacion : Form
    {
        Cliente cliente = new Cliente();
        Articulo articulo = new Articulo();
        FormaPago formaPago = new FormaPago();
        Factura factura = new Factura();
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            UtilidadesFormularios.CargarComboBox(cboCliente, cliente.ObtenerClientes(), "Nombre");
            UtilidadesFormularios.CargarComboBox(cboArticulo, articulo.ObtenerArticulos(), "Descripcion");
            UtilidadesFormularios.CargarComboBox(cboFormaPago, formaPago.ObtenerFormaPago(), "Descripcion");

            btnAgregarGrilla.Enabled = false;

            UtilidadesFormularios.ConfigurarGrilla(dtgGrilla);
        }

        private void btnLimpiarTodo_Click(object sender, EventArgs e)
        {
            UtilidadesFormularios.ReestablecerFormulario(cboCliente, cboFormaPago, cboArticulo, dtgGrilla, lblCodigo, lblCondCliente, lblDescripcion, lblPrecioUnitario, txtObservaciones);
        }

        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado (es un objeto Cliente completo)
            Cliente clienteSeleccionado = (Cliente)cboCliente.SelectedItem;

            // Actualizar los labels con los datos del artículo
            lblCondCliente.Text = clienteSeleccionado.ObtenerDescripcionCondicion();
        }


        private void cboArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Obtener el artículo seleccionado (es un objeto Articulo completo)
            Articulo articuloSeleccionado = (Articulo)cboArticulo.SelectedItem;

            // Actualizar los labels con los datos del artículo
            lblCodigo.Text = articuloSeleccionado.IdArticulo.ToString();
            lblDescripcion.Text = articuloSeleccionado.Descripcion;
            lblPrecioUnitario.Text = articuloSeleccionado.PrecioUnitarioSinIva.ToString("C2"); // Formato de moneda
        }


        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int cantidad;
            // Habilitar el botón solo si el txtCantidad tiene un valor válido
            if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0)
            {
                btnAgregarGrilla.Enabled = true;
            }
            else
            {
                btnAgregarGrilla.Enabled = false;
            }
        }


        private void btnAgregarGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un artículo
                if (cboArticulo.SelectedItem != null && int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    // Obtener el artículo seleccionado
                    Articulo articuloSeleccionado = (Articulo)cboArticulo.SelectedItem;

                    // Llamar al método AgregarAGrilla del artículo seleccionado
                    articuloSeleccionado.AgregarAGrilla(dtgGrilla, cantidad);

                    // Limpiar el campo de cantidad para el siguiente artículo
                    txtCantidad.Clear();
                    btnAgregarGrilla.Enabled = false;  // Deshabilitar el botón hasta que se ingrese nueva cantidad
                }
                else
                {
                    MessageBox.Show("Seleccione un artículo y asegúrese de ingresar una cantidad válida.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el producto a la grilla: " + ex.Message);
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado
            Cliente clienteSeleccionado = (Cliente)cboCliente.SelectedItem;
            FormaPago formaPagoSeleccionada = (FormaPago)cboFormaPago.SelectedItem;

            if (cliente.ValidarCliente(clienteSeleccionado) &&
                formaPago.ValidarFormaPago(formaPagoSeleccionada) &&
                articulo.ValidarArticulo(dtgGrilla))
            {
                factura.GenerarFactura(clienteSeleccionado, cboFormaPago, dtgGrilla, txtObservaciones);
                UtilidadesFormularios.ReestablecerFormulario(cboCliente, cboFormaPago, cboArticulo, dtgGrilla, lblCodigo, lblCondCliente, lblDescripcion, lblPrecioUnitario, txtObservaciones);
                // Crear el DataSet
                DataSet dsFactura = new DataSet(); // Reemplaza con el nombre correcto del DataSet

                // Llenar el DataSet usando el TableAdapter
                var adapter = new DataSetTableAdapters.DataTable1TableAdapter();
                dsFactura.EnforceConstraints = false;
                adapter.Fill(dsFactura.DataTable1); // Fill es el método del TableAdapter que ejecuta la consulta

                // Crear instancia del reporte
                ReportDocument report = factura.CargarReporte(factura.Cabecera);

                // Asignar el DataSet al reporte
                report.SetDataSource(dsFactura);

                // Mostrar el reporte en un formulario
                VistaFactura vistaFactura = new VistaFactura();
                vistaFactura.CargarReporte(report); // Este método lo creas para asignar el reporte
                vistaFactura.ShowDialog();

                // Recargar el formulario
                this.Hide(); // Ocultar el formulario actual
                Facturacion nuevaFactura = new Facturacion(); // Crear nueva instancia del formulario
                nuevaFactura.ShowDialog(); // Mostrar el nuevo formulario
                this.Close(); // Cerrar el formulario anterior
            }
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            cboBusquedaCliente.Visible = true;
            label10.Visible = true;
            cboFacturas.Visible = true;

            UtilidadesFormularios.CargarComboBox(cboBusquedaCliente, cliente.ObtenerClientes(), "Nombre");
        }

        private void cboBusquedaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente)cboBusquedaCliente.SelectedItem;

            if (clienteSeleccionado != null)
            {
                Factura factura = new Factura();
                List<FacturaCabecera> facturas = factura.ObtenerFacturasPorCliente(clienteSeleccionado.IdCliente);

                // Limpiar el ComboBox de facturas
                cboFacturas.Items.Clear();
                cboFacturas.Enabled = true;

                // Llenar el ComboBox de facturas con el número y fecha de cada factura
                foreach (var f in facturas)
                {
                    cboFacturas.Items.Add(f);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
            }
        }

        private void cboFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVerFactura.Enabled = true;
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            // Verificar si hay una factura seleccionada
            if (cboFacturas.SelectedItem != null)
            {
                FacturaCabecera facturaSeleccionada = (FacturaCabecera)cboFacturas.SelectedItem;

                DataSet dsFactura = new DataSet(); // Reemplaza con el nombre correcto del DataSet

                // Llenar el DataSet usando tu TableAdapter
                var adapter = new DataSetTableAdapters.DataTable1TableAdapter();
                dsFactura.EnforceConstraints = false;
                adapter.FillById(dsFactura.DataTable1, facturaSeleccionada.IdFactura); // Fill es el método del TableAdapter que ejecuta la consulta

                // Crear instancia del reporte
                ReportDocument report = factura.CargarReporte(facturaSeleccionada);

                // Asignar el DataSet al reporte
                report.SetDataSource(dsFactura);

                // Mostrar el reporte en un formulario
                VistaFactura vistaFactura = new VistaFactura();
                vistaFactura.CargarReporte(report); // Este método lo creas para asignar el reporte
                vistaFactura.ShowDialog();
            }
        }
    }
}
