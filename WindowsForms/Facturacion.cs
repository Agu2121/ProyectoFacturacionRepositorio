using BibliotecaClases;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Facturacion : Form
    {
        // Creacion de objetos globalmente
        Cliente cliente = new Cliente();
        Articulo articulo = new Articulo();
        FormaPago formaPago = new FormaPago();
        Factura factura = new Factura();
        DataSet dsFactura = new DataSet();
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            // Metodo que carga en cada combobox pasado por parametro los datos traidos de la base de datos
            UtilidadesFormularios.CargarComboBox(cboCliente, cliente.ObtenerClientes(), "Nombre");
            UtilidadesFormularios.CargarComboBox(cboArticulo, articulo.ObtenerArticulos(), "Descripcion");
            UtilidadesFormularios.CargarComboBox(cboFormaPago, formaPago.ObtenerFormaPago(), "Descripcion");

            // Metodo estatico que configura toda la grilla
            UtilidadesFormularios.ConfigurarGrilla(dtgGrilla);
        }

        private void btnLimpiarTodo_Click(object sender, EventArgs e)
        {
            UtilidadesFormularios.ReestablecerFormulario(cboCliente, cboFormaPago, cboArticulo, articulo, dtgGrilla, lblCodigo, lblCondCliente, lblDescripcion, lblPrecioUnitario, txtObservaciones);
        }

        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado en el combobox(es un objeto Cliente completo)
            Cliente clienteSeleccionado = (Cliente)cboCliente.SelectedItem;

            // Actualizar el lblCondCliente segun el cliente que haya sido seleccionado
            lblCondCliente.Text = clienteSeleccionado.ObtenerDescripcionCondicion();
        }

        private void cboArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Obtener el artículo seleccionado (es un objeto Articulo completo)
            Articulo articuloSeleccionado = (Articulo)cboArticulo.SelectedItem;

            // Actualizar los labels con los datos del artículo seleccionado
            lblCodigo.Text = articuloSeleccionado.IdArticulo.ToString();
            lblDescripcion.Text = articuloSeleccionado.Descripcion;
            // El método ToString convierte el valor numérico de PrecioUnitarioSinIva a una cadena
            // que represente un valor de tipo moneda ("C") con 2 decimales ("2").
            lblPrecioUnitario.Text = articuloSeleccionado.PrecioUnitarioSinIva.ToString("C2");
        }

        private void btnAgregarGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que su cantidad sea valida y almacenarla en la variable cantidad si así lo es
                if (int.TryParse(txtCantidad.Text, out int cantidad) && (cantidad > 0))
                {
                    // Obtener el artículo seleccionado
                    Articulo articuloSeleccionado = (Articulo)cboArticulo.SelectedItem;

                    // Llamar al método AgregarAGrilla del artículo seleccionado
                    articuloSeleccionado.AgregarAGrilla(dtgGrilla, cantidad);

                    // Limpiar el campo de cantidad para el siguiente artículo
                    txtCantidad.Clear();

                    // Eliminar el artículo del ComboBox para evitar que se vuelva a agregar
                    cboArticulo.Items.Remove(articuloSeleccionado);
                }
                else
                {
                    MessageBox.Show("Seleccione un artículo y asegúrese de ingresar una cantidad válida.");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al agregar el producto a la grilla, asegurese de haber seleccionado un articulo");
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado y la forma de pago seleccionada de sus combobox
            Cliente clienteSeleccionado = (Cliente)cboCliente.SelectedItem;
            FormaPago formaPagoSeleccionada = (FormaPago)cboFormaPago.SelectedItem;

            if (cliente.ValidarCliente(clienteSeleccionado) &&
                formaPago.ValidarFormaPago(formaPagoSeleccionada) &&
                articulo.ValidarArticulo(dtgGrilla))
            {
                factura.GenerarFactura(clienteSeleccionado, cboFormaPago, dtgGrilla, txtObservaciones);
                UtilidadesFormularios.ReestablecerFormulario(cboCliente, cboFormaPago, cboArticulo, articulo, dtgGrilla, lblCodigo, lblCondCliente, lblDescripcion, lblPrecioUnitario, txtObservaciones);

                // Llenar el DataSet usando el TableAdapter
                var adapter = new DataSetTableAdapters.DataTable1TableAdapter();
                adapter.Fill(dsFactura.DataTable1); // Fill es el método del TableAdapter que ejecuta la consulta

                // Crear instancia del reporte
                ReportDocument report = factura.CargarReporte(factura.Cabecera, dsFactura);

                AbrirVistaFactura(report);

                // Recargar el formulario de facturacion actual
                this.Hide(); // Ocultar el formulario actual
                Facturacion nuevaFactura = new Facturacion(); // Crear nueva instancia del formulario
                nuevaFactura.ShowDialog(); // Mostrar el nuevo formulario
                this.Close(); // Cerrar el formulario anterior
            }
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            lblSeleccioneCliente.Visible = true;
            cboBusquedaCliente.Visible = true;
            cboFacturas.Visible = true;

            UtilidadesFormularios.CargarComboBox(cboBusquedaCliente, cliente.ObtenerClientes(), "Nombre");
        }

        private void cboBusquedaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente)cboBusquedaCliente.SelectedItem;

            if (clienteSeleccionado != null)
            {
                Factura factura = new Factura();
                List<FacturaCabecera> cabeceras = factura.ObtenerFacturasPorCliente(clienteSeleccionado.IdCliente);

                // Limpiar el ComboBox de facturas
                cboFacturas.Items.Clear();
                cboFacturas.Enabled = true;

                // Llenar el ComboBox de facturas con el número y fecha de cada factura
                foreach (var c in cabeceras)
                {
                    // El ComboBox llama automáticamente al método ToString() sobreescrito de facturaCabecera
                    cboFacturas.Items.Add(c);
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

                // Llenar el DataSet usando tu TableAdapter
                var adapter = new DataSetTableAdapters.DataTable1TableAdapter();
                adapter.FillById(dsFactura.DataTable1, facturaSeleccionada.IdFactura); // Fill es el método del TableAdapter que ejecuta la consulta

                // Crear instancia del reporte
                ReportDocument report = factura.CargarReporte(facturaSeleccionada, dsFactura);

                AbrirVistaFactura(report);
            }
        }

        // Metodo estatico que se encarga de abrir el formular vistaFactura y solicita como parametro el reporte a mostrar
        private static void AbrirVistaFactura(ReportDocument report)
        {
            VistaFactura vistaFactura = new VistaFactura();
            vistaFactura.AsignarReporte(report); // Este método se crea para asignar el reporte
            vistaFactura.ShowDialog();
        }
    }
}
