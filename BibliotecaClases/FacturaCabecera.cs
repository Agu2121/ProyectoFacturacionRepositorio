using BibliotecaClases_BD;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class FacturaCabecera
{
    // Atributos privados
    private int _idFactura;
    private string _numeroFactura;
    private DateTime _fecha;
    private int _idCliente;
    private int _idEmpresa;
    private int _idFormaPago;
    private string _tipoFactura;
    private string _cae;
    private DateTime _fechaVencimientoCAE;
    private decimal _subTotal;
    private decimal _iva;
    private decimal _total;
    private string _observaciones;

    // Propiedades públicas
    public int IdFactura
    {
        get { return _idFactura; }
        set { _idFactura = value; }
    }

    public string NumeroFactura
    {
        get { return _numeroFactura; }
        set { _numeroFactura = value; }
    }

    public DateTime Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }

    public int IdCliente
    {
        get { return _idCliente; }
        set { _idCliente = value; }
    }

    public int IdEmpresa
    {
        get { return _idEmpresa; }
        set { _idEmpresa = value; }
    }

    public int IdFormaPago
    {
        get { return _idFormaPago; }
        set { _idFormaPago = value; }
    }

    public string TipoFactura
    {
        get { return _tipoFactura; }
        set { _tipoFactura = value; }
    }

    public string CAE
    {
        get { return _cae; }
        set { _cae = value; }
    }

    public DateTime FechaVencimientoCAE
    {
        get { return _fechaVencimientoCAE; }
        set { _fechaVencimientoCAE = value; }
    }

    public decimal SubTotal
    {
        get { return _subTotal; }
        set { _subTotal = value; }
    }

    public decimal Iva
    {
        get { return _iva; }
        set { _iva = value; }
    }

    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
    }

    public string Observaciones
    {
        get { return _observaciones; }
        set { _observaciones = value; }
    }

    // Método para insertar los datos de la cabecera de la factura en la base de datos
    public void InsertarFacturaCabecera()
    {
        try
        {
            // Conexión a la base de datos
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                // Query SQL para insertar los datos en la tabla FacturaCabecera
                string query = @"INSERT INTO FacturaCabecera 
                                 (NumeroFactura, Fecha, IdCliente, IdEmpresa, IdFormaPago, TipoFactura, CAE, FechaVencimientoCAE, SubTotal, Iva, Total, Observaciones) 
                                 VALUES (@NumeroFactura, @Fecha, @IdCliente, @IdEmpresa, @IdFormaPago, @TipoFactura, @CAE, @FechaVencimientoCAE, @SubTotal, @Iva, @Total, @Observaciones)";
                // Preparar el comando con los parámetros
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumeroFactura", NumeroFactura);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                    cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    cmd.Parameters.AddWithValue("@IdFormaPago", IdFormaPago);
                    cmd.Parameters.AddWithValue("@TipoFactura", TipoFactura);
                    cmd.Parameters.AddWithValue("@CAE", CAE);
                    cmd.Parameters.AddWithValue("@FechaVencimientoCAE", FechaVencimientoCAE);
                    cmd.Parameters.AddWithValue("@SubTotal", SubTotal);
                    cmd.Parameters.AddWithValue("@Iva", Iva);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    // Si las observaciones son nulas, se coloca DBNull.Value
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery(); // Ejecutar la query
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al insertar la cabecera de la factura: " + ex.Message);
        }
    }

    // Método para calcular el total de la factura recorriendo el DataGridView de los artículos
    public decimal CalcularTotalFactura(DataGridView dtgGrilla)
    {
        decimal totalFactura = 0;

        foreach (DataGridViewRow row in dtgGrilla.Rows)
        {
            // Si el valor de la celda "Total" no es nulo, lo suma al total
            if (row.Cells["Total"].Value != null)
            {
                totalFactura += Convert.ToDecimal(row.Cells["Total"].Value.ToString().Replace("$", ""));
            }
        }

        return totalFactura; // Retorna el total calculado
    }

    // Método para obtener el último ID insertado de la tabla FacturaCabecera
    public int ObtenerIdFacturaCabecera()
    {
        int nuevoIdFactura = 1; // Valor inicial por defecto

        // Consulta SQL para obtener el mayor ID de la tabla FacturaCabecera
        string query = "SELECT ISNULL(MAX(IdFactura), 0) FROM FacturaCabecera";

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                nuevoIdFactura = (int)cmd.ExecuteScalar(); // Obtener el ID de la factura
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID de factura: " + ex.Message);
            }
        }

        return nuevoIdFactura; // Retornar el nuevo ID
    }

    // Método para generar el número de factura y retornarlo
    public string GenerarNumeroFactura(int puntoVenta)
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1, 99999999);
        NumeroFactura = $"{puntoVenta.ToString("00000")}-{numeroAleatorio.ToString("00000000")}";
        return NumeroFactura;  // Retorna el número de factura generado
    }

    // Método para generar y retornar el CAE
    public string GenerarCAE()
    {
        Random random = new Random();
        string cae = "";
        // Generar un CAE aleatorio de 14 dígitos
        for (int i = 0; i < 14; i++)
        {
            cae += random.Next(0, 9).ToString();
        }
        CAE = cae;
        return CAE;  // Retorna el CAE generado
    }

    // Método para generar y retornar la fecha de vencimiento del CAE
    public DateTime GenerarFechaVencimientoCAE()
    {
        FechaVencimientoCAE = Fecha.AddDays(15);
        return FechaVencimientoCAE;  // Retorna la fecha de vencimiento del CAE
    }

    // Sobrescribir el método ToString para mostrar el número y la fecha
    public override string ToString()
    {
        // Formatear la representación de la factura con el número y la fecha
        return $"Factura N° {NumeroFactura} - {Fecha.ToShortDateString()}"; // Esto se muestra en el combobox de busqueda
    }
}
