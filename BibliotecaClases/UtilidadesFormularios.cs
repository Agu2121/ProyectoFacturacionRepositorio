using System.Collections.Generic;
using System.Windows.Forms;

namespace BibliotecaClases
{
    // CLASE ESTATICA, ES DECIR QUE NO NECESITA SER INSTANCIADA PARA SER USADA
    public static class UtilidadesFormularios
    {
        // MÉTODO PARA CONFIGURAR EL DataGridView (GRILLA)
        public static void ConfigurarGrilla(DataGridView dtgGrilla)
        {
            // Configuración del DataGridView
            dtgGrilla.ReadOnly = true; // Solo lectura, el usuario no puede editar las celdas directamente
            dtgGrilla.AllowUserToAddRows = false; // No permitir agregar filas manualmente
            dtgGrilla.AllowUserToDeleteRows = false; // No prmitir eliminar filas manualmente
            dtgGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar el tamaño de las columnas automáticamente para llenar el espacio disponible

            // Limpiar columnas existentes en la grilla, si es que hay
            dtgGrilla.Columns.Clear();

            // Definir las columnas de la grilla
            dtgGrilla.Columns.Add("Codigo", "Código");
            dtgGrilla.Columns.Add("Descripcion", "Descripción");
            dtgGrilla.Columns.Add("Cantidad", "Cantidad");
            dtgGrilla.Columns.Add("Total", "Total sin IVA");

            // Ajustar alineaciones y formato                          //Centra el texto de esa columna
            dtgGrilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGrilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGrilla.Columns["Total"].DefaultCellStyle.Format = "C2"; // Formato de moneda con 2 decimales para el total
        }


        // MÉTODO PARA RESTABLECER LOS VALORES DEL FORMULARIO A SU ESTADO INICIAL
        public static void ReestablecerFormulario(ComboBox cboCliente, ComboBox cboFormaPago, ComboBox cboArticulo, Articulo articulo, DataGridView dtgGrilla, Label lblCodigo, Label lblCondCliente, Label lblDescripcion, Label lblPrecioUnitario, TextBox txtObservaciones)
        {
            // Restablecer los valores de los ComboBox
            cboCliente.ResetText();
            cboFormaPago.ResetText();
            cboArticulo.ResetText();

            // Recargar los artículos en el ComboBox de artículos ya que se eliminan cuando se agregan a la grilla
            // y ahora los debe volver a mostrar
            CargarComboBox(cboArticulo, articulo.ObtenerArticulos(), "Descripcion");

            // Limpiar la grilla
            dtgGrilla.Rows.Clear();

            // Restablecer las etiquetas a sus valores predeterminados
            lblCodigo.Text = "-";
            lblCondCliente.Text = "-";
            lblDescripcion.Text = "-";
            lblPrecioUnitario.Text = "-";

            // Vaciar el TextBox de observaciones
            txtObservaciones.Text = "";
        }


        // MÉTODO PARA CARGAR ELEMENTOS EN CUALQUIER ComboBox
        public static void CargarComboBox<T>(ComboBox comboBox, List<T> items, string displayMember)
        {
            // Limpiar los elementos actuales del ComboBox
            comboBox.Items.Clear();

            // Establecer qué propiedad del objeto se mostrará en el ComboBox
            comboBox.DisplayMember = displayMember;

            // Añadir los elementos a la lista del ComboBox
            foreach (var item in items)
            {
                comboBox.Items.Add(item); // Agregar cada elemento a la lista
            }
        }
    }
}
