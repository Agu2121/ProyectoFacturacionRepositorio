using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliotecaClases
{
    public static class UtilidadesFormularios
    {
        public static void ConfigurarGrilla(DataGridView dtgGrilla)
        {
            // Configuración del DataGridView
            dtgGrilla.ReadOnly = true; // Solo lectura, el usuario no puede editar las celdas directamente
            dtgGrilla.AllowUserToAddRows = false; // No permitir agregar filas manualmente
            dtgGrilla.AllowUserToDeleteRows = false; // No prmitir eliminar filas manualmente
            dtgGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar el tamaño de las columnas automáticamente para llenar el espacio disponible

            // Limpiar y agregar columnas
            dtgGrilla.Columns.Clear();

            // Definir las columnas de la grilla
            dtgGrilla.Columns.Add("Codigo", "Código");
            dtgGrilla.Columns.Add("Descripcion", "Descripción");
            dtgGrilla.Columns.Add("Cantidad", "Cantidad");
            dtgGrilla.Columns.Add("Total", "Total");

            // Ajustar alineaciones y formato
            dtgGrilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGrilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGrilla.Columns["Total"].DefaultCellStyle.Format = "C2"; // Formato de moneda para el total
        }


        // Restablecer cualquier formulario (asume que los componentes tienen nombres comunes)
        public static void ReestablecerFormulario(ComboBox cboCliente, ComboBox cboFormaPago, ComboBox cboArticulo, DataGridView dtgGrilla, Label lblCodigo, Label lblCondCliente, Label lblDescripcion, Label lblPrecioUnitario, TextBox txtObservaciones)
        {
            cboCliente.ResetText();
            cboFormaPago.ResetText();
            cboArticulo.ResetText();
            dtgGrilla.Rows.Clear();
            lblCodigo.Text = "-";
            lblCondCliente.Text = "-";
            lblDescripcion.Text = "-";
            lblPrecioUnitario.Text = "-";
            txtObservaciones.Text = "";
        }


        // Procedimiento para traer los datos a cualquier combobox
        public static void CargarComboBox<T>(ComboBox comboBox, List<T> items, string displayMember)
        {
            comboBox.Items.Clear();
            comboBox.DisplayMember = displayMember;
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
        }
    }
}
